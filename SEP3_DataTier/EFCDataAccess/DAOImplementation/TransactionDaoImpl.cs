using EFCDataAccess.DAOInterface;
using Entity;
using Entity;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFCDataAccess.DAOImplementation;

/// <summary>
/// Implementation of the <see cref="ITransactionDao"/> interface for managing transactions in a database.
/// </summary>
public class TransactionDaoImpl : ITransactionDao
{
    private readonly CanPayDbAccess context;
    private ITransactionDao transactionDaoImplementation;

    public TransactionDaoImpl(CanPayDbAccess context)
    {
        this.context = context;
    }


    /// <summary>
    /// Creates a new transaction in the database.
    /// </summary>
    /// <param name="transaction">The transaction entity to create.</param>
    /// <returns>The created transaction entity.</returns>
    public async Task<TransactionEntity?> CreateTransactionAsync(TransactionEntity? transaction)
    {
        try
        {
            // Attach the sender and receiver entities to the context if they are not already attached
            if (!context.Users.Local.Contains(transaction.Sender))
            {
                context.Users.Attach(transaction.Sender);
                context.Cards.Attach(transaction.Sender!.Card);
            }

            if (!context.Users.Local.Contains(transaction.Receiver))
            {
                context.Users.Attach(transaction.Receiver);
                context.Cards.Attach(transaction.Receiver!.Card);
            }


            EntityEntry<TransactionEntity> createdTransaction = (await context.Transactions.AddAsync(transaction))!;
            await context.SaveChangesAsync();

            return createdTransaction.Entity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception($"Cannot Create Transaction. Try Again!");
        }
    }


    /// <summary>
    /// Fetches all transactions involving a given user from the database.
    /// </summary>
    /// <param name="username">The username of the user to filter transactions by.</param>
    /// <returns>A collection of transaction entities involving the given user.</returns>
    public async Task<ICollection<TransactionEntity>> FetchAlLTransactionsInvolvingUserAsync(string username)
    {
        ICollection<TransactionEntity?> transactions = await context.Transactions
            .AsNoTracking()
            .Include(entity => entity.Sender).Include(entity => entity.Receiver)
            .Where(entity => entity.Receiver.Username.Equals(username) || entity.Sender.Username.Equals(username))
            .ToListAsync();

        return transactions;
    }


}