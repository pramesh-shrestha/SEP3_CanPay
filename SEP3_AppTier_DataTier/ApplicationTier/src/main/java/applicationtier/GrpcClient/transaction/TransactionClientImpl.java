package applicationtier.GrpcClient.transaction;

import applicationtier.GrpcClient.ManagedChannelProvider;
import applicationtier.GrpcClient.user.UserClientImpl;
import applicationtier.entity.TransactionEntity;
import applicationtier.protobuf.Transaction;
import applicationtier.protobuf.TransactionProtoServiceGrpc;
import com.google.protobuf.Int32Value;
import com.google.protobuf.Int64Value;
import com.google.protobuf.StringValue;
import io.grpc.ManagedChannel;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;

@Service
    public class TransactionClientImpl implements ITransactionClient {

    private TransactionProtoServiceGrpc.TransactionProtoServiceBlockingStub transactionBlockingStub;

    /**
     * Retrieves the TransactionProtoServiceBlockingStub instance.
     *
     * @return The TransactionProtoServiceBlockingStub instance.
     */
    private TransactionProtoServiceGrpc.TransactionProtoServiceBlockingStub getTransactionBlockingStub() {
        if (transactionBlockingStub == null) {
            ManagedChannel channel = ManagedChannelProvider.getChannel();
            transactionBlockingStub = TransactionProtoServiceGrpc.newBlockingStub(channel);
        }
        return transactionBlockingStub;
    }

    /**
     * Creates a new transaction.
     *
     * @param transaction The TransactionEntity object representing the transaction to create.
     * @return The created TransactionEntity object.
     * @throws RuntimeException If an exception occurs during the creation process.
     */
    @Override
    public TransactionEntity createTransaction(TransactionEntity transaction) {
        try {
            Transaction.TransactionProtoObj transactionProtoObj = fromEntityToProtoObj(transaction);

            Transaction.TransactionProtoObj protoObj = getTransactionBlockingStub().
                createTransactionAsync(transactionProtoObj);
            return fromProtoObjToEntity(protoObj);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    /**
     * Fetches a transaction by its ID.
     *
     * @param id The ID of the transaction to fetch.
     * @return The TransactionEntity object representing the fetched transaction.
     * @throws RuntimeException If an exception occurs during the fetch process.
     */
    /*@Override
    public TransactionEntity fetchTransactionById(Long id) {
        try {
            Transaction.TransactionProtoObj transactionProtoObj = getTransactionBlockingStub().fetchTransactionByIdAsync(Int64Value.of(id));
            return fromProtoObjToEntity(transactionProtoObj);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }*/

    /**
     * Fetches all transactions by sender username.
     *
     * @param senderUsername The username of the sender.
     * @return A list of TransactionEntity objects representing all the transactions sent by the sender.
     * @throws RuntimeException If an exception occurs during the fetch process.
     */
    /*@Override
    public List<TransactionEntity> fetchAlLTransactionsBySender(String senderUsername) {
        try {
            List<Transaction.TransactionProtoObj> allTransactionsList = getTransactionBlockingStub().fetchAlLTransactionsBySenderAsync(StringValue.of(senderUsername)).getAllTransactionsList();
            List<TransactionEntity> transactionEntities = new ArrayList<>();
            for (Transaction.TransactionProtoObj transactionProtoObj : allTransactionsList) {
                transactionEntities.add(fromProtoObjToEntity(transactionProtoObj));

            }
            return transactionEntities;
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }*/


    /**
     * Fetches all transactions by receiver username.
     *
     * @param receiverUsername The username of the receiver.
     * @return A list of TransactionEntity objects representing all the transactions received by the receiver.
     * @throws RuntimeException If an exception occurs during the fetch process.
     */
    /*@Override
    public List<TransactionEntity> fetchAllTransactionByReceiver(String receiverUsername) {
        try {
            List<Transaction.TransactionProtoObj> allTransactionsList = getTransactionBlockingStub().fetchAllTransactionsByReceiverAsync(StringValue.of(receiverUsername)).getAllTransactionsList();
            List<TransactionEntity> transactionEntities = new ArrayList<>();
            for (Transaction.TransactionProtoObj transactionProtoObj : allTransactionsList) {
                transactionEntities.add(fromProtoObjToEntity(transactionProtoObj));
            }
            return transactionEntities;
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }*/


    /**
     * Fetches all transactions involving a user.
     *
     * @param username The username of the user.
     * @return A list of TransactionEntity objects representing all the transactions involving the user.
     * @throws RuntimeException If an exception occurs during the fetch process.
     */
    @Override
    public List<TransactionEntity> fetchAllTransactionInvolvingUser(String username) {
        try {
            List<Transaction.TransactionProtoObj> allTransactionsList = getTransactionBlockingStub().fetchAlLTransactionsInvolvingUserAsync(StringValue.of(username)).getAllTransactionsList();
            List<TransactionEntity> transactionEntities = new ArrayList<>();
            for (Transaction.TransactionProtoObj transactionProtoObj : allTransactionsList) {
                transactionEntities.add(fromProtoObjToEntity(transactionProtoObj));
            }
            return transactionEntities;
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    /**
     * Fetches transactions by date.
     *
     * @param date The date of the transactions to fetch.
     * @return A list of TransactionEntity objects representing the transactions on the specified date.
     * @throws RuntimeException If an exception occurs during the fetch process.
     */
    /*@Override
    public List<TransactionEntity> fetchTransactionByDate(String date) {
        try {
            List<Transaction.TransactionProtoObj> transactionsList1 = getTransactionBlockingStub().
                    fetchTransactionsByDateAsync(StringValue.of(date)).getAllTransactionsList();
            List<TransactionEntity> transactionEntities = new ArrayList<>();
            for (Transaction.TransactionProtoObj transactionProtoObj : transactionsList1) {
                transactionEntities.add(fromProtoObjToEntity(transactionProtoObj));
            }
            return transactionEntities;
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }*/

    /**
     * Fetches transactions by date and username.
     *
     * @param date     The date of the transactions to fetch.
     * @param username The username of the user involved in the transactions.
     * @return A list of TransactionEntity objects representing the transactions on the specified date involving the user.
     * @throws RuntimeException If an exception occurs during the fetch process.
     */
    /*@Override
    public List<TransactionEntity> fetchTransactionByDateAndUsername(String date, String username) {
        try {
            List<Transaction.TransactionProtoObj> transactionsList = getTransactionBlockingStub()
                    .fetchTransactionsByRecipientAndDate(Transaction.FilterByUserAndDateProtoObj.newBuilder()
                            .setDate(StringValue.of(date))
                            .setUsername(StringValue.of(username))
                            .build())
                    .getAllTransactionsList();
            List<TransactionEntity> transactionEntities = new ArrayList<>();
            for (Transaction.TransactionProtoObj transactionProtoObj : transactionsList) {
                transactionEntities.add(fromProtoObjToEntity(transactionProtoObj));
            }
            return transactionEntities;
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }*/



    /**
     * Deletes a transaction by its ID.
     *
     * @param id The ID of the transaction to delete.
     * @return true if the transaction was successfully deleted, false otherwise.
     * @throws RuntimeException If an exception occurs during the delete process.
     */
    /*@Override
    public boolean deleteTransaction(Long id) {
        try {
            BoolValue transactionProtoObj = getTransactionBlockingStub().deleteTransactionAsync(Int64Value.of(id));
            return transactionProtoObj.toBuilder().getValue();
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }*/


    /**
     * Converts a Transaction.TransactionProtoObj object to a TransactionEntity object.
     *
     * @param transactionProtoObj The Transaction.TransactionProtoObj object to convert.
     * @return The converted TransactionEntity object.
     */
    public static TransactionEntity fromProtoObjToEntity(Transaction.TransactionProtoObj transactionProtoObj) {
        TransactionEntity transaction = new TransactionEntity();
        transaction.setReceiver(UserClientImpl.fromProtoObjToEntity(transactionProtoObj.getReceiverUser()));
        transaction.setSender(UserClientImpl.fromProtoObjToEntity(transactionProtoObj.getSenderUser()));
        transaction.setAmount(transactionProtoObj.getAmount().getValue());
        transaction.setDate(transactionProtoObj.getDate().getValue());
        transaction.setTransactionId(transactionProtoObj.getTransactionId().getValue());
        transaction.setComment(transactionProtoObj.getComment().getValue());

        return transaction;
    }

    /**
     * Converts a TransactionEntity object to a Transaction.TransactionProtoObj object.
     *
     * @param transaction The TransactionEntity object to convert.
     * @return The converted Transaction.TransactionProtoObj object.
     */
    public static Transaction.TransactionProtoObj fromEntityToProtoObj(TransactionEntity transaction) {
        Transaction.TransactionProtoObj.Builder transactionBuilder = Transaction.TransactionProtoObj.newBuilder()
                .setReceiverUser(UserClientImpl.fromEntityToProtoObj(transaction.getReceiver()))
                .setSenderUser(UserClientImpl.fromEntityToProtoObj(transaction.getSender()))
                .setDate(StringValue.of(transaction.getDate()))
                .setAmount(Int32Value.of(transaction.getAmount()))
                .setComment(StringValue.of(transaction.getComment()));


        if (transaction.getTransactionId() != null || transaction.getTransactionId() != 0) {
            transactionBuilder.setTransactionId(Int64Value.of(transaction.getTransactionId()));
        }

        return transactionBuilder.build();
    }
}
