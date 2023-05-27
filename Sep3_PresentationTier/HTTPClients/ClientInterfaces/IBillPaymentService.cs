using Domains.Entity;

namespace HTTPClients.ClientInterfaces;

public interface IBillPaymentService
{
    Task<BillPaymentEntity> CreateAsync(BillPaymentEntity? billPaymentEntity);
    Task<ICollection<BillPaymentEntity>> FetchAllTransactionsInvolvingUser(string? username);
    
}
