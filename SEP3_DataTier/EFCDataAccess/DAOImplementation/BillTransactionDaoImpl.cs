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
    
    /// <summary>
    /// Creates a new bill transaction in the database.
    /// </summary>
    /// <param name="billTransaction">The bill transaction to be created.</param>
    /// <returns>The created bill transaction entity.</returns>
    public async Task<BillTransactionEntity?> CreateBillTransactionAsync(BillTransactionEntity? billTransaction)
    {
        try
        {
            if (!context.Users.Local.Contains(billTransaction!.Payer))
            {
                context.Users.Attach(billTransaction.Payer);
                context.Cards.Attach(billTransaction.Payer!.Card);
            }

            EntityEntry<BillTransactionEntity> createdBillTransaction = (await context.BillTransactions.AddAsync(billTransaction))!;
            await context.SaveChangesAsync();

            Console.WriteLine("dao"+billTransaction.Payer);
            Console.WriteLine("dao"+billTransaction.AccountNumber);
            return createdBillTransaction.Entity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception($"Cannot create bill transaction. Please try again!");
        }
    }
    
    /// <summary>
    /// Fetches a bill transaction by its ID from the database.
    /// </summary>
    /// <param name="id">The ID of the bill transaction to fetch.</param>
    /// <returns>The bill transaction entity, or null if not found.</returns>
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
    
    /// <summary>
    /// Fetches all bill transactions associated with a specific payer from the database.
    /// </summary>
    /// <param name="payerUsername">The username of the payer.</param>
    /// <returns>A collection of bill transaction entities.</returns>
    public async Task<ICollection<BillTransactionEntity>> FetchAllBillTransactionsByPayerAsync(string payerUsername)
    {
        ICollection<BillTransactionEntity> billTransactions = await context.BillTransactions.Include(bt => bt.Payer)
            .Include(entity => entity.Payee)
            .Where(bt => bt.Payer.Username.Equals(payerUsername)).ToListAsync();
        return billTransactions;
    }
    
    /// <summary>
    /// Fetches all bill transactions involving a specific user from the database.
    /// </summary>
    /// <param name="username">The username of the user.</param>
    /// <returns>A collection of bill transaction entities.</returns>
    public async Task<ICollection<BillTransactionEntity>> FetchAllBillTransactionsInvolvingUserAsync(string username)
    {
        ICollection<BillTransactionEntity> transactions = await context.BillTransactions
            .AsNoTracking()
            .Include(entity => entity.Payer)
            .Where(entity => entity.Payee.Equals(username) || entity.Payer.Username.Equals(username))
            .ToListAsync();
    
        return transactions;
    }

    /// <summary>
    /// Fetches all bill transactions on a specific date from the database.
    /// </summary>
    /// <param name="date">The date of the bill transactions to fetch.</param>
    /// <returns>A collection of bill transaction entities.</returns>
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
    
    /// <summary>
    /// Deletes a bill transaction from the database.
    /// </summary>
    /// <param name="id">The ID of the bill transaction to delete.</param>
    /// <returns>True if the bill transaction is successfully deleted, otherwise false.</returns>
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