package applicationtier.service.serviceImplementations;

import applicationtier.GrpcClient.transaction.ITransactionClient;
import applicationtier.entity.TransactionEntity;
import applicationtier.service.serviceInterfaces.ITransactionService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class TransactionServiceImplementation implements ITransactionService {

    private ITransactionClient transactionClient;

    @Autowired
    public TransactionServiceImplementation(ITransactionClient transactionClient) {
        this.transactionClient = transactionClient;
    }

    @Override
    public TransactionEntity createTransaction(TransactionEntity transaction) {
        try {
            return transactionClient.createTransaction(transaction);
        }
        catch (Exception e){
            throw new RuntimeException(e.getMessage());
        }
    }

    @Override
    public TransactionEntity fetchTransactionById(Long id) {
        try {
            return transactionClient.fetchTransactionById(id);
        }
        catch (Exception e){
            throw new RuntimeException(e.getMessage());
        }
    }

    @Override
    public List<TransactionEntity> fetchAlLTransactionsBySender(String senderUsername) {
        try {
            return transactionClient.fetchAlLTransactionsBySender(senderUsername);
        }
        catch (Exception e){
            throw new RuntimeException(e.getMessage());
        }
    }

    @Override
    public List<TransactionEntity> fetchAllTransactionByReceiver(String receiverUsername) {
        try{
            return transactionClient.fetchAllTransactionByReceiver(receiverUsername);
        }
        catch (Exception e){
            throw new RuntimeException(e.getMessage());
        }
    }

    @Override
    public List<TransactionEntity> fetchAllTransactionInvolvingUser(String username) {
        try{
            return transactionClient.fetchAllTransactionInvolvingUser(username);
        }
        catch (Exception e){
            throw new RuntimeException(e.getMessage());
        }
    }

    @Override
    public List<TransactionEntity> fetchTransactionByDate(String date) {
        try{
            return transactionClient.fetchTransactionByDate(date);
        }
        catch (Exception e){
            throw new RuntimeException(e.getMessage());
        }
    }

    @Override
    public boolean deleteTransaction(Long id) {
        try {
            return transactionClient.deleteTransaction(id);
        }
        catch (Exception e){
            throw new RuntimeException(e.getMessage());
        }
    }
}
