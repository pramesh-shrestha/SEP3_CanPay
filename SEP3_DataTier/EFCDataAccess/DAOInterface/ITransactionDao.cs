using Entity.Model;

namespace EFCDataAccess.DAOInterface;

public interface ITransactionDao
{
    Task<TransactionEntity> CreateTransactionAsync(TransactionEntity transaction);
    Task<TransactionEntity?> FetchTransactionByIdAsync(long id);
    Task<ICollection<TransactionEntity>> FetchAlLTransactionsBySenderAsync(string senderUsername);
    Task<ICollection<TransactionEntity>> FetchAllTransactionsByReceiverAsync(string receiverUsername);
    Task<ICollection<TransactionEntity>> FetchAlLTransactionsInvolvingUserAsync(string username);
    Task<ICollection<TransactionEntity>> FetchTransactionsByDateAsync(string date);
    Task<bool> DeleteTransactionAsync(long id);
}