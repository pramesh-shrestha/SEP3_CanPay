namespace EFCDataAccess.DAOInterface;

using Entity.Model;

public interface IBillTransactionDao
{
    Task<BillTransactionEntity?> CreateBillTransactionAsync(BillTransactionEntity? transaction);

    Task<ICollection<BillTransactionEntity>> FetchAllBillTransactionsInvolvingUserAsync(string username);

}

