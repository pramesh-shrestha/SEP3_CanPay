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
            
            return createdBillTransaction.Entity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception($"Cannot create bill transaction. Please try again!");
        }
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
            .Where(entity => entity.Payer.Username.Equals(username))
            .ToListAsync();
    
        return transactions;
    }
    
}