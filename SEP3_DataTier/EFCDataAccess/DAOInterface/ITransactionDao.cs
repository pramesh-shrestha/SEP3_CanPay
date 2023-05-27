using Entity;
using Entity;
using Entity.Model;

namespace EFCDataAccess.DAOInterface;

public interface ITransactionDao
{
    Task<TransactionEntity?> CreateTransactionAsync(TransactionEntity? transaction);

    Task<ICollection<TransactionEntity>> FetchAlLTransactionsInvolvingUserAsync(string username);
}