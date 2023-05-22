using Domains.Entity;

namespace HTTPClients.ClientInterfaces;

public interface ITransactionService
{
    Task<TransactionEntity> CreateTransactionAsync(TransactionEntity transactionEntity);
    Task<ICollection<TransactionEntity>> FetchAllTransactionInvolvingUserAsync(string? username);
}