using EFCDataAccess.DAOInterface;
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

    public TransactionDaoImpl(CanPayDbAccess context)
    {
        this.context = context;
    }


    /// <summary>
    /// Creates a new transaction in the database.
    /// </summary>
    /// <param name="transaction">The transaction entity to create.</param>
    /// <returns>The created transaction entity.</returns>
    public async Task<TransactionEntity> CreateTransactionAsync(TransactionEntity transaction)
    {
        try
        {
            EntityEntry<TransactionEntity> createdTransaction = await context.Transactions.AddAsync(transaction);
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
    /// Fetches a transaction by its unique identifier from the database.
    /// </summary>
    /// <param name="id">The unique identifier of the transaction to fetch.</param>
    /// <returns>The transaction entity, or null if it does not exist.</returns>
    public async Task<TransactionEntity?> FetchTransactionByIdAsync(long id)
    {
        try
        {
            TransactionEntity? transaction = await context.Transactions.FirstOrDefaultAsync(t => t.Id == id);
            return transaction;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception($"Transaction with {id} not found!!");
        }
    }


    /// <summary>
    /// Fetches all transactions sent by a given user from the database.
    /// </summary>
    /// <param name="senderUsername">The username of the sender to filter transactions by.</param>
    /// <returns>A collection of transaction entities sent by the given user.</returns>
    public async Task<ICollection<TransactionEntity>> FetchAlLTransactionsBySenderAsync(string senderUsername)
    {
        // should include information about sender and receiver user
        ICollection<TransactionEntity> transactionBySender = await context.Transactions.Include(t => t.Sender)
            .Include(entity => entity.Receiver)
            .Where(te => te.Sender.Username.Equals(senderUsername)).ToListAsync();

        if (transactionBySender.Count == 0)
        {
            throw new Exception($"No Transactions Sent By {senderUsername}");
        }

        return transactionBySender;
    }


    /// <summary>
    /// Fetches all transactions received by a given user from the database.
    /// </summary>
    /// <param name="receiverUsername">The username of the receiver to filter transactions by.</param>
    /// <returns>A collection of transaction entities received by the given user.</returns>
    public async Task<ICollection<TransactionEntity>> FetchAllTransactionsByReceiverAsync(string receiverUsername)
    {
        // should include information about sender and receiver user
        ICollection<TransactionEntity> transactionByReceiver = await context.Transactions.Include(t => t.Sender)
            .Include(entity => entity.Receiver)
            .Where(entity => entity.Receiver.Equals(receiverUsername)).ToListAsync();

        if (transactionByReceiver.Count == 0)
        {
            throw new Exception($"No Transaction Received By {receiverUsername}");
        }

        return transactionByReceiver;
    }


    /// <summary>
    /// Fetches all transactions involving a given user from the database.
    /// </summary>
    /// <param name="username">The username of the user to filter transactions by.</param>
    /// <returns>A collection of transaction entities involving the given user.</returns>
    public async Task<ICollection<TransactionEntity>> FetchAlLTransactionsInvolvingUserAsync(string username)
    {
        // Get transactions where the user is sender
        ICollection<TransactionEntity> sentTransaction = await FetchAlLTransactionsBySenderAsync(username);

        // Get transactions where the user is receiver
        ICollection<TransactionEntity> receivedTransaction = await FetchAllTransactionsByReceiverAsync(username);

        ICollection<TransactionEntity> transactions = sentTransaction.Concat(receivedTransaction).ToList();

        if (transactions.Count == 0)
        {
            throw new Exception($"No Transaction Involving {username}");
        }

        return transactions;
    }


    /// <summary>
    /// Fetches all transactions made on a specific date from the database.
    /// </summary>
    /// <param name="date">The date to filter transactions by.</param>
    /// <returns>A collection of transaction entities made on the given date.</returns>
    public async Task<ICollection<TransactionEntity>> FetchTransactionsByDateAsync(string date)
    {
        List<TransactionEntity> transactionByDate =
            await context.Transactions.Where(entity => entity.Date.Equals(date)).ToListAsync();

        if (transactionByDate.Count == 0)
        {
            throw new Exception($"No Transaction Made on {date}");
        }

        return transactionByDate;
    }


    /// <summary>
    /// Deletes a transaction from the database.
    /// </summary>
    /// <param name="id">The unique identifier of the transaction to delete.</param>
    /// <returns>A boolean indicating whether the transaction was successfully deleted.</returns>
    public async Task<bool> DeleteTransactionAsync(long id)
    {
        TransactionEntity? byIdAsync = await FetchTransactionByIdAsync(id);

        if (byIdAsync == null)
        {
            throw new Exception($"No Transaction with id {id} found");
        }


        context.Transactions.Remove(byIdAsync);
        await context.SaveChangesAsync();
        return true;
    }
}