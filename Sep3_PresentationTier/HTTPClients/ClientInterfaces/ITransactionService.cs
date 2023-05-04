using Domains.Entity;

namespace HTTPClients.ClientInterfaces; 

public interface ITransactionService {
    Task<TransactionEntity> CreateTransactionAsync(TransactionEntity transactionEntity);
    Task<TransactionEntity> FetchTransactionByIdAsync(long id);
    Task<TransactionEntity> FetchAllTransactionBySender(string username);
    Task<TransactionEntity> FetchAllTransactionByReceiver(string username);
    Task<TransactionEntity> FetchAllTransactionInvolvingBothUsers(string username);
    
    
}