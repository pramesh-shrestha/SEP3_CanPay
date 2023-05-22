package applicationtier.service.serviceImplementations;

import applicationtier.GrpcClient.transaction.ITransactionClient;
import applicationtier.GrpcClient.user.IUserClient;
import applicationtier.entity.TransactionEntity;
import applicationtier.entity.UserEntity;
import applicationtier.service.serviceInterfaces.ITransactionService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class TransactionServiceImplementation implements ITransactionService {

    private final ITransactionClient transactionClient;
    private final IUserClient userClient;

    @Autowired
    public TransactionServiceImplementation(ITransactionClient transactionClient
            , IUserClient userClient) {
        this.transactionClient = transactionClient;
        this.userClient = userClient;
    }

    /**
     * Creates a new transaction.
     *
     * @param transaction The transaction entity to create.
     * @return The created transaction entity.
     * @throws RuntimeException If an error occurs during the creation process or if the sender has insufficient balance.
     */
    @Override
    public TransactionEntity createTransaction(TransactionEntity transaction) {
        try {
            UserEntity receiver = transaction.getReceiver();
            UserEntity sender = transaction.getSender();
            int amount = transaction.getAmount();


            if (sender.getBalance() < amount || sender.getBalance() == 0) {
                throw new Exception("Insufficient balance");
            }
            //set balance of sender and receiver after transaction
            sender.setBalance(sender.getBalance() - amount);
            receiver.setBalance(receiver.getBalance() + amount);

            //update user
            userClient.updateUser(sender);
            userClient.updateUser(receiver);

//            System.out.println("TransactionServiceImpl : " + transaction.getReceiver());

            //create transaction
            return transactionClient.createTransaction(transaction);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }

    /**
     * Fetches all transactions involving a specific user (as sender or receiver).
     *
     * @param username The username of the user.
     * @return The list of fetched transaction entities.
     * @throws RuntimeException If an error occurs during the fetching process.
     */
    @Override
    public List<TransactionEntity> fetchAllTransactionInvolvingUser(String username) {
        try {
            return transactionClient.fetchAllTransactionInvolvingUser(username);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }

    /**
     * Fetches a transaction by its ID.
     *
     * @param id The ID of the transaction to fetch.
     * @return The fetched transaction entity.
     * @throws RuntimeException If an error occurs during the fetching process.
     */
    /*@Override
    public TransactionEntity fetchTransactionById(Long id) {
        try {
            return transactionClient.fetchTransactionById(id);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }*/

    /**
     * Fetches all transactions sent by a specific sender.
     *
     * @param senderUsername The username of the sender.
     * @return The list of fetched transaction entities.
     * @throws RuntimeException If an error occurs during the fetching process.
     */
    /*@Override
    public List<TransactionEntity> fetchAlLTransactionsBySender(String senderUsername) {
        try {
            return transactionClient.fetchAlLTransactionsBySender(senderUsername);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }*/

    /**
     * Fetches all transactions received by a specific receiver.
     *
     * @param receiverUsername The username of the receiver.
     * @return The list of fetched transaction entities.
     * @throws RuntimeException If an error occurs during the fetching process.
     */
   /* @Override
    public List<TransactionEntity> fetchAllTransactionByReceiver(String receiverUsername) {
        try {
            return transactionClient.fetchAllTransactionByReceiver(receiverUsername);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }*/


    /**
     * Fetches all transactions that occurred on a specific date.
     *
     * @param date The date of the transactions.
     * @return The list of fetched transaction entities.
     * @throws RuntimeException If an error occurs during the fetching process.
     */
    /*@Override
    public List<TransactionEntity> fetchTransactionByDate(String date) {
        try {
            return transactionClient.fetchTransactionByDate(date);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }*/

    /**
     * Fetches all transactions that occurred on a specific date and involving a specific user.
     *
     * @param filterDto The filter criteria containing the date and username.
     * @return The list of fetched transaction entities.
     * @throws RuntimeException If an error occurs during the fetching process.
     */
   /* @Override
    public List<TransactionEntity> fetchTransactionByDateAndUsername(FilterDto filterDto) {
        try {
            return transactionClient.fetchTransactionByDateAndUsername(filterDto.getDate(), filterDto.getUsername());
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }*/


    /**
     * Deletes a transaction by its ID.
     *
     * @param id The ID of the transaction to delete.
     * @return True if the deletion is successful, false otherwise.
     * @throws RuntimeException If an error occurs during the deletion process.
     */
    /*@Override
    public boolean deleteTransaction(Long id) {
        try {
            return transactionClient.deleteTransaction(id);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }*/


}
