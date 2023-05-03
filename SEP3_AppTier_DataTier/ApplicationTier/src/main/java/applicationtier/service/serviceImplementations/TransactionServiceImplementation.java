package applicationtier.service.serviceImplementations;

import applicationtier.entity.TransactionEntity;
import applicationtier.service.serviceInterfaces.ITransactionService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class TransactionServiceImplementation implements ITransactionService {

    private ITransactionService transactionService;

    @Autowired
    public TransactionServiceImplementation(ITransactionService transactionService) {
        this.transactionService = transactionService;
    }

    @Override
    public TransactionEntity createTransaction(TransactionEntity transaction) {
        try {
            return transactionService.createTransaction(transaction);
        }
        catch (Exception e){
            throw new RuntimeException(e.getMessage());
        }
    }

    @Override
    public TransactionEntity fetchTransactionById(Long id) {
        try {
            return transactionService.fetchTransactionById(id);
        }
        catch (Exception e){
            throw new RuntimeException(e.getMessage());
        }
    }

    @Override
    public List<TransactionEntity> fetchAlLTransactionsBySender(String senderUsername) {
        try {
            return transactionService.fetchAlLTransactionsBySender(senderUsername);
        }
        catch (Exception e){
            throw new RuntimeException(e.getMessage());
        }
    }

    @Override
    public List<TransactionEntity> fetchAllTransactionByReceiver(String receiverUsername) {
        try{
            return transactionService.fetchAllTransactionByReceiver(receiverUsername);
        }
        catch (Exception e){
            throw new RuntimeException(e.getMessage());
        }
    }

    @Override
    public List<TransactionEntity> fetchAllTransactionInvolvingUser(String username) {
        try{
            return transactionService.fetchAllTransactionInvolvingUser(username);
        }
        catch (Exception e){
            throw new RuntimeException(e.getMessage());
        }
    }

    @Override
    public List<TransactionEntity> fetchTransactionByDate(String date) {
        try{
            return transactionService.fetchTransactionByDate(date);
        }
        catch (Exception e){
            throw new RuntimeException(e.getMessage());
        }
    }

    @Override
    public boolean deleteTransaction(Long id) {
        try {
            return transactionService.deleteTransaction(id);
        }
        catch (Exception e){
            throw new RuntimeException(e.getMessage());
        }
    }
}
