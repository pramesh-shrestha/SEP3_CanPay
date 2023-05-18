package applicationtier.GrpcClient.transaction;

import applicationtier.GrpcClient.ManagedChannelProvider;
import applicationtier.GrpcClient.user.UserClientImpl;
import applicationtier.entity.TransactionEntity;
import applicationtier.protobuf.Transaction;
import applicationtier.protobuf.TransactionProtoServiceGrpc;
import com.google.protobuf.BoolValue;
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

    private TransactionProtoServiceGrpc.TransactionProtoServiceBlockingStub getTransactionBlockingStub() {
        if (transactionBlockingStub == null) {
            ManagedChannel channel = ManagedChannelProvider.getChannel();
            transactionBlockingStub = TransactionProtoServiceGrpc.newBlockingStub(channel);
        }
        return transactionBlockingStub;
    }

    @Override
    public TransactionEntity createTransaction(TransactionEntity transaction) {
        try {
            Transaction.TransactionProtoObj transactionProtoObj = fromEntityToProtoObj(transaction);

            Transaction.TransactionProtoObj protoObj = getTransactionBlockingStub().createTransactionAsync(transactionProtoObj);
            return fromProtoObjToEntity(protoObj);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    @Override
    public TransactionEntity fetchTransactionById(Long id) {
        try {
            Transaction.TransactionProtoObj transactionProtoObj = getTransactionBlockingStub().fetchTransactionByIdAsync(Int64Value.of(id));
            return fromProtoObjToEntity(transactionProtoObj);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    @Override
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
    }


    @Override
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
    }


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

    @Override
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
    }
    /*@Override
    public List<TransactionEntity> fetchTransactionByDateAndUsername(String date, String username) {
        try {
            List<Transaction.TransactionProtoObj> transactionsList = getTransactionBlockingStub()
                    .fetchTransactionsByRecipientAndDate(Transaction.TransactionProtoObj.newBuilder()
                            .setDate(StringValue.of(date))
                            .setReceiverUser(StringValue.of(username))
                            //.setSenderUser(StringValue.of(username))
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
    @Override
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
    }



    @Override
    public boolean deleteTransaction(Long id) {
        try {
            BoolValue transactionProtoObj = getTransactionBlockingStub().deleteTransactionAsync(Int64Value.of(id));
            return transactionProtoObj.toBuilder().getValue();
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }


    //from proto to entity
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

    //from entity to proto
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
