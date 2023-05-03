package applicationtier.GrpcClient.transaction;

import applicationtier.entity.TransactionEntity;

import java.util.List;

public class TransactionClientImpl implements ITransactionClient{
    @Override
    public TransactionEntity createTransaction(TransactionEntity transaction) {
        return null;
    }

    @Override
    public TransactionEntity fetchTransactionById(Long id) {
        return null;
    }

    @Override
    public List<TransactionEntity> fetchAlLTransactionsBySender(String senderUsername) {
        return null;
    }

    @Override
    public List<TransactionEntity> fetchAllTransactionByReceiver(String receiverUsername) {
        return null;
    }

    @Override
    public List<TransactionEntity> fetchAllTransactionInvolvingUser(String username) {
        return null;
    }

    @Override
    public List<TransactionEntity> fetchTransactionByDate(String date) {
        return null;
    }

    @Override
    public boolean deleteTransaction(Long id) {
        return false;
    }
}
