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

import java.util.List;

@Service
public class TransactionClientImpl implements ITransactionClient{

    private TransactionProtoServiceGrpc.TransactionProtoServiceBlockingStub transactionBlockingStub;

    private TransactionProtoServiceGrpc.TransactionProtoServiceBlockingStub getTransactionBlockingStub(){
        if (transactionBlockingStub==null){
            ManagedChannel channel= ManagedChannelProvider.getChannel();
            transactionBlockingStub=TransactionProtoServiceGrpc.newBlockingStub(channel);
        }
        return transactionBlockingStub;
    }

    @Override
    public TransactionEntity createTransaction(TransactionEntity transaction) {
        try {
            Transaction.TransactionProtoObj transactionProtoObj=fromEntityToProtoObj(transaction);
            Transaction.TransactionProtoObj protoObj=getTransactionBlockingStub().createTransactionAsync(transactionProtoObj);
            return fromProtoObjToEntity(protoObj);
        } catch (Exception e){
            throw new RuntimeException(e);
        }
    }

    @Override
    public TransactionEntity fetchTransactionById(Long id) {
        try {
            Transaction.TransactionProtoObj transactionProtoObj=getTransactionBlockingStub().fetchTransactionByIdAsync(Int64Value.of(id));
            return fromProtoObjToEntity(transactionProtoObj);
        }catch (Exception e){
            throw new RuntimeException(e);
        }
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
        try {
            BoolValue transactionProtoObj= getTransactionBlockingStub().deleteTransactionAsync(Int64Value.of(id));
            return transactionProtoObj.toBuilder().getValue();
        }
        catch (Exception e){
            throw new RuntimeException(e);
        }
    }

    public static TransactionEntity fromProtoObjToEntity(Transaction.TransactionProtoObj transactionProtoObj){
        TransactionEntity transaction=new TransactionEntity();
        transaction.setReceiver(UserClientImpl.fromProtoObjToEntity(transactionProtoObj.getReceiverUser()));
        transaction.setSender(UserClientImpl.fromProtoObjToEntity(transactionProtoObj.getSenderUser()));
        transaction.setAmount(transactionProtoObj.getAmount().getValue());
        transaction.setDate(transactionProtoObj.getDate().getValue());
        return transaction;
    }

    public static Transaction.TransactionProtoObj fromEntityToProtoObj(TransactionEntity transaction){
        Transaction.TransactionProtoObj.Builder transactionBuilder=Transaction.TransactionProtoObj.newBuilder()
                .setReceiverUser(UserClientImpl.fromEntityToProtoObj(transaction.getReceiver()))
                .setSenderUser(UserClientImpl.fromEntityToProtoObj(transaction.getSender()))
                .setDate(StringValue.of(transaction.getDate()))
                .setAmount(Int32Value.of(transaction.getAmount()));
        return transactionBuilder.build();
    }
}
