package applicationtier.GrpcClient.transaction;

import applicationtier.entity.TransactionEntity;

import java.util.List;

public interface ITransactionClient {

    TransactionEntity createTransaction(TransactionEntity transaction);
    TransactionEntity fetchTransactionById(Long id);
    List<TransactionEntity> fetchAlLTransactionsBySender(String senderUsername);
    List<TransactionEntity> fetchAllTransactionByReceiver(String receiverUsername);
    List<TransactionEntity> fetchAllTransactionInvolvingUser(String username);
    List<TransactionEntity> fetchTransactionByDate(String date);
    boolean deleteTransaction(Long id);

    List<TransactionEntity> fetchTransactionByDateAndUsername(String date, String username);

}
