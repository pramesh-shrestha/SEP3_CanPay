using EFCDataAccess.DAOInterface;
using Entity;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace EFCDataAccess.DAOImplementation;

/// <summary>
/// Implementation of the <see cref="IBillTransactionDao"/> interface for managing bill payment transactions in a database.
/// </summary>
public class BillTransactionDaoImpl : IBillTransactionDao {
    private readonly CanPayDbAccess context;

    public BillTransactionDaoImpl(CanPayDbAccess context)
    {
        this.context = context;
    }


    public async Task<BillTransactionEntity?> CreateBillTransactionAsync(BillTransactionEntity? billTransaction)
    {
        try
        {
            if (!context.Users.Local.Contains(billTransaction.Payer))
            {
                context.Users.Attach(billTransaction.Payer);
                context.Cards.Attach(billTransaction.Payer!.Card);
            }

            EntityEntry<BillTransactionEntity> createdBillTransaction = (await context.BillTransactions.AddAsync(billTransaction))!;
            await context.SaveChangesAsync();

            return createdBillTransaction.Entity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception($"Cannot create bill transaction. Please try again!");
        }
    }
    
    public async Task<BillTransactionEntity?> FetchBillTransactionByIdAsync(long id)
    {
        try
        {
            BillTransactionEntity? billTransaction = await context.BillTransactions.FirstOrDefaultAsync(bt => bt.Id == id);
            return billTransaction;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception($"Bill transaction with id {id} not found!");
        }
    }
    
    public async Task<ICollection<BillTransactionEntity>> FetchAllBillTransactionsByPayerAsync(string payerUsername)
    {
        ICollection<BillTransactionEntity> billTransactions = await context.BillTransactions.Include(bt => bt.Payer)
            .Include(entity => entity.Payee)
            .Where(bt => bt.Payer.Username.Equals(payerUsername)).ToListAsync();
        return billTransactions;
    }
    
    public async Task<ICollection<BillTransactionEntity>> FetchAllBillTransactionsInvolvingUserAsync(string username)
    {
        ICollection<BillTransactionEntity> transactions = await context.BillTransactions
            .AsNoTracking()
            .Include(entity => entity.Payer)
            .Where(entity => entity.Payee.Equals(username) || entity.Payer.Username.Equals(username))
            .ToListAsync();
    
        return transactions;
    }

    public async Task<ICollection<BillTransactionEntity>> FetchBillTransactionsByDateAsync(string date)
    {
        List<BillTransactionEntity> billTransactionsByDate = await context.BillTransactions
            // .Where(bt => bt.Date.Equals(date))
            // .ToListAsync();
            .Where(entity => entity.Date.Equals(date))
            .ToListAsync();
        
        if (billTransactionsByDate.Count == 0)
        {
            throw new Exception($"No bill transactions made on {date}");
        }
        return billTransactionsByDate;
    }
    
    
    public async Task<bool> DeleteBillTransactionAsync(long id)
    {
        BillTransactionEntity? billTransaction = await FetchBillTransactionByIdAsync(id);

        if (billTransaction == null)
        {
            throw new Exception($"No bill transaction with id {id} found");
        }

        context.BillTransactions.Remove(billTransaction);
        await context.SaveChangesAsync();

        return true;
    }

}