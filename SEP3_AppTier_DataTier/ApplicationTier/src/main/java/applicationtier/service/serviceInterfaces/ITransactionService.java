package applicationtier.service.serviceInterfaces;

import applicationtier.entity.TransactionEntity;

import java.util.List;

public interface ITransactionService {

    TransactionEntity createTransaction(TransactionEntity transaction);
    List<TransactionEntity> fetchAllTransactionInvolvingUser(String username);


}
