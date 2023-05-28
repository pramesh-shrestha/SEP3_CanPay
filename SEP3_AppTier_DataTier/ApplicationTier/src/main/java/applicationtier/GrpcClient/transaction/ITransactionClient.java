package applicationtier.GrpcClient.transaction;

import applicationtier.entity.TransactionEntity;

import java.util.List;

public interface ITransactionClient {

    TransactionEntity createTransaction(TransactionEntity transaction);
    List<TransactionEntity> fetchAllTransactionInvolvingUser(String username);


}
