using Domains.Entity;

namespace HTTPClients.ClientInterfaces;

public interface ITransactionService
{
    Task<TransactionEntity> CreateTransactionAsync(TransactionEntity transactionEntity);
    Task<TransactionEntity> FetchTransactionByIdAsync(long id);
    Task<ICollection<TransactionEntity>> FetchAllTransactionBySenderAsync(string username);
    Task<ICollection<TransactionEntity>> FetchAllTransactionByReceiverAsync(string username);
    Task<ICollection<TransactionEntity>> FetchAllTransactionInvolvingUserAsync(string username);
    Task<ICollection<TransactionEntity>> FetchTransactionByDateAsync(string date);
    Task DeleteTransactionAsync(long id);
}