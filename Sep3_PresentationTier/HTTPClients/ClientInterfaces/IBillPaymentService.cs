using Domains.Entity;

namespace HTTPClients.ClientInterfaces;

public interface IBillPaymentService
{
    Task<BillPaymentEntity> CreateAsync(BillPaymentEntity billPaymentEntity);
    Task<BillPaymentEntity> FetchBillPaymentsById(long id);
    Task<ICollection<BillPaymentEntity>> FetchAllTransactionsInvolvingUser(string? username);
    
}
