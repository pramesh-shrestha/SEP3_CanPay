package applicationtier.GrpcClient.transaction;

import applicationtier.entity.TransactionEntity;

import java.util.List;

public interface ITransactionClient {

    TransactionEntity createTransaction(TransactionEntity transaction);
    List<TransactionEntity> fetchAllTransactionInvolvingUser(String username);

   /* TransactionEntity fetchTransactionById(Long id);
    List<TransactionEntity> fetchAlLTransactionsBySender(String senderUsername);
    List<TransactionEntity> fetchAllTransactionByReceiver(String receiverUsername);
    List<TransactionEntity> fetchTransactionByDate(String date);
    boolean deleteTransaction(Long id);

    List<TransactionEntity> fetchTransactionByDateAndUsername(String date, String username);
*/
}
