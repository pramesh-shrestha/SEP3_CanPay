namespace EFCDataAccess.DAOInterface;

using Entity.Model;

public interface IBillTransactionDao
{
    Task<BillTransactionEntity?> CreateBillTransactionAsync(BillTransactionEntity? transaction);

    // Task<BillTransactionEntity?> FetchBillTransactionByIdAsync(long id);

    // Task<ICollection<BillTransactionEntity>> FetchAllBillTransactionsByPayerAsync(string payerUsername);

    // Task<ICollection<BillTransactionEntity>> FetchAllBillTransactionsByPayeeAsync(string payeeUsername);  Not needed

    Task<ICollection<BillTransactionEntity>> FetchAllBillTransactionsInvolvingUserAsync(string username);

    // Task<ICollection<BillTransactionEntity?>> FetchBillTransactionsByDateAsync(string date);

    // Task<bool> DeleteBillTransactionAsync(long id);
}

