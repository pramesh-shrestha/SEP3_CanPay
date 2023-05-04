using Domains.Entity;

namespace HTTPClients.ClientInterfaces; 

public interface ITransactionService {
    Task<TransactionEntity> CreateTransactionAsync(TransactionEntity transactionEntity);
    Task<TransactionEntity> FetchTransactionByIdAsync(long id);
    Task<TransactionEntity> FetchAllTransactionBySenderAsync(string username);
    Task<TransactionEntity> FetchAllTransactionByReceiverAsync(string username);
    Task<TransactionEntity> FetchAllTransactionInvolvingBothUsersAsync(string username);
    Task<TransactionEntity> FetchTransactionByDateAsync(string date);
    Task DeleteTransactionAsync(long id);


}