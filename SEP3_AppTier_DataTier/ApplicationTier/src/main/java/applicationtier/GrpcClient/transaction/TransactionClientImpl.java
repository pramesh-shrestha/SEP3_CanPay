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
