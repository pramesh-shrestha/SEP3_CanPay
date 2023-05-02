using EFCDataAccess.DAOInterface;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFCDataAccess.DAOImplementation;

public class TransactionDaoImpl : ITransactionDao
{
    private readonly CanPayDbAccess context;

    public TransactionDaoImpl(CanPayDbAccess context)
    {
        this.context = context;
    }

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

    public async Task<TransactionEntity?> FetchTransactionByIdAsync(int id)
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

    public async Task<ICollection<TransactionEntity>> FetchAlLTransactionsBySenderAsync(string senderUsername)
    {
        // should include information about sender and receiver user
        ICollection<TransactionEntity> transactionBySender = await context.Transactions.Include(t => t.Sender)
            .Include(entity => entity.Receiver)
            .Where(te => te.Sender.Username.Equals(senderUsername)).ToListAsync();

        if (transactionBySender == null)
        {
            throw new Exception($"No Transactions Sent By {senderUsername}");
        }

        return transactionBySender;
    }

    public async Task<ICollection<TransactionEntity>> FetchAllTransactionsByReceiverAsync(string receiverUsername)
    {
        // should include information about sender and receiver user
        ICollection<TransactionEntity> transactionByReceiver = await context.Transactions.Include(t => t.Sender)
            .Include(entity => entity.Receiver)
            .Where(entity => entity.Receiver.Equals(receiverUsername)).ToListAsync();

        if (transactionByReceiver == null)
        {
            throw new Exception($"No Transaction Received By {receiverUsername}");
        }

        return transactionByReceiver;
    }

    public async Task<ICollection<TransactionEntity>> FetchAlLTransactionsInvolvingUserAsync(string username)
    {
        ICollection<TransactionEntity> transactions = new List<TransactionEntity>();

        // Get transactions where the user is sender
        ICollection<TransactionEntity> sentTransaction = await FetchAlLTransactionsBySenderAsync(username);
        foreach (var transactionEntity in sentTransaction) transactions.Add(transactionEntity);

        // Get transactions where the user is receiver
        ICollection<TransactionEntity> receivedTransaction = await FetchAllTransactionsByReceiverAsync(username);
        foreach (var transactionEntity in receivedTransaction) transactions.Add(transactionEntity);

        if (transactions == null)
        {
            throw new Exception($"No Transaction Involving {username}");
        }

        return transactions;
    }

    public async Task<ICollection<TransactionEntity>> FetchTransactionsByDateAsync(string date)
    {
        List<TransactionEntity> transactionByDate =
            await context.Transactions.Where(entity => entity.Date.Equals(date)).ToListAsync();

        if (transactionByDate == null)
        {
            throw new Exception($"No Transaction Made on {date}");
        }

        return transactionByDate;
    }

    public async Task<bool> DeleteTransactionAsync(int id)
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