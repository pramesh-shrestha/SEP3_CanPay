package applicationtier.GrpcClient.billPayment;

import applicationtier.GrpcClient.ManagedChannelProvider;
import applicationtier.GrpcClient.user.UserClientImpl;
import applicationtier.entity.BillPaymentEntity;
import applicationtier.protobuf.BillPaymentProtoServiceGrpc;
import applicationtier.protobuf.BillTransaction;
import com.google.protobuf.BoolValue;
import com.google.protobuf.Int32Value;
import com.google.protobuf.Int64Value;
import com.google.protobuf.StringValue;
import io.grpc.ManagedChannel;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;

@Service
public class BillPaymentClientImpl implements IBillPaymentClient {

    private BillPaymentProtoServiceGrpc.BillPaymentProtoServiceBlockingStub billPaymentBlockingStub;

    private BillPaymentProtoServiceGrpc.BillPaymentProtoServiceBlockingStub getBillPaymentBlockingStub() {
        if (billPaymentBlockingStub == null) {
            ManagedChannel channel = ManagedChannelProvider.getChannel();
            billPaymentBlockingStub = BillPaymentProtoServiceGrpc.newBlockingStub(channel);
        }
        return billPaymentBlockingStub;
    }

    @Override
    public BillPaymentEntity createBillPayment(BillPaymentEntity billPayment) {
        try {
            BillTransaction.BillPaymentProtoObj billPaymentProtoObj = fromEntityToProtoObj(billPayment);

            BillTransaction.BillPaymentProtoObj protoObj = getBillPaymentBlockingStub().createBillPaymentAsync(billPaymentProtoObj);
            return fromProtoObjToEntity(protoObj);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    @Override
    public BillPaymentEntity fetchBillPaymentById(Long id) {
        try {
            BillTransaction.BillPaymentProtoObj billPaymentProtoObj = getBillPaymentBlockingStub().fetchBillPaymentByIdAsync(Int64Value.of(id));
            return fromProtoObjToEntity(billPaymentProtoObj);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    @Override
    public List<BillPaymentEntity> fetchAlLBillPaymentsBySender(String senderUsername) {
        try {
            List<BillTransaction.BillPaymentProtoObj> allBillPaymentsList = getBillPaymentBlockingStub().fetchAlLBillPaymentsBySenderAsync(StringValue.of(senderUsername)).getAllBillPaymentsList();
            List<BillPaymentEntity> billPaymentEntities = new ArrayList<>();
            for (BillTransaction.BillPaymentProtoObj billPaymentProtoObj : allBillPaymentsList) {
                billPaymentEntities.add(fromProtoObjToEntity(billPaymentProtoObj));

            }
            return billPaymentEntities;
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }


    @Override
    public List<BillPaymentEntity> fetchAllBillPaymentByReceiver(String payeeName) {
        try {
            List<BillTransaction.BillPaymentProtoObj> allBillPaymentsList = getBillPaymentBlockingStub().fetchAllBillPaymentsByReceiverAsync(StringValue.of(payeeName)).getAllBillPaymentsList();
            List<BillPaymentEntity> billPaymentEntities = new ArrayList<>();
            for (BillTransaction.BillPaymentProtoObj billPaymentProtoObj : allBillPaymentsList) {
                billPaymentEntities.add(fromProtoObjToEntity(billPaymentProtoObj));
            }
            return billPaymentEntities;
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }


    @Override
    public List<BillPaymentEntity> fetchAllBillPaymentInvolvingUser(String username) {
        try {
            List<BillTransaction.BillPaymentProtoObj> allBillPaymentsList = getBillPaymentBlockingStub().fetchAlLBillPaymentsInvolvingUserAsync(StringValue.of(username)).getAllBillPaymentsList();
            List<BillPaymentEntity> billPaymentEntities = new ArrayList<>();
            for (BillTransaction.BillPaymentProtoObj billPaymentProtoObj : allBillPaymentsList) {
                billPaymentEntities.add(fromProtoObjToEntity(billPaymentProtoObj));
            }
            return billPaymentEntities;
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    @Override
    public List<BillPaymentEntity> fetchBillPaymentByDate(String date) {
        try {
            List<BillTransaction.BillPaymentProtoObj> billPaymentsList1 = getBillPaymentBlockingStub().
                    fetchBillPaymentsByDateAsync(StringValue.of(date)).getAllBillPaymentsList();
            List<BillPaymentEntity> billPaymentEntities = new ArrayList<>();
            for (BillTransaction.BillPaymentProtoObj billPaymentProtoObj : billPaymentsList1) {
                billPaymentEntities.add(fromProtoObjToEntity(billPaymentProtoObj));
            }
            return billPaymentEntities;
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }




    @Override
    public boolean deleteBillPayment(Long id) {
        try {
            BoolValue billPaymentProtoObj = getBillPaymentBlockingStub().deleteBillPaymentAsync(Int64Value.of(id));
            return billPaymentProtoObj.toBuilder().getValue();
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }


    //from proto to entity
    public static BillPaymentEntity fromProtoObjToEntity(BillTransaction.BillPaymentProtoObj billPaymentProtoObj) {
        BillPaymentEntity billPayment = new BillPaymentEntity();
        billPayment.setPayeeName(billPaymentProtoObj.getPayeeName().getValue());
        billPayment.setSender(UserClientImpl.fromProtoObjToEntity(billPaymentProtoObj.getSenderUser()));
        billPayment.setAmount(billPaymentProtoObj.getAmount().getValue());
        billPayment.setDate(billPaymentProtoObj.getDate().getValue());
        billPayment.setPaymentId(billPaymentProtoObj.getBillPaymentId().getValue());
        billPayment.setAccountNumber(billPaymentProtoObj.getAccountNumber().getValue());
        billPayment.setReference(billPaymentProtoObj.getReference().getValue());

        return billPayment;
    }

    //from entity to proto
    public static BillTransaction.BillPaymentProtoObj fromEntityToProtoObj(BillPaymentEntity billPayment) {
        BillTransaction.BillPaymentProtoObj.Builder billPaymentBuilder = BillTransaction.BillPaymentProtoObj.newBuilder()
                .setPayeeName(StringValue.of(billPayment.getPayeeName()))
                .setSenderUser(UserClientImpl.fromEntityToProtoObj(billPayment.getSender()))
                .setDate(StringValue.of(billPayment.getDate()))
                .setAmount(Int32Value.of(billPayment.getAmount()))
                .setAccountNumber(Int64Value.of(billPayment.getAccountNumber()))
                .setReference(StringValue.of(billPayment.getReference()));


        if (billPayment.getPaymentId() != null || billPayment.getPaymentId() != 0) {
            billPaymentBuilder.setBillPaymentId(Int64Value.of(billPayment.getPaymentId()));
        }

        return billPaymentBuilder.build();
    }
}
