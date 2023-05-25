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

    /**
     * Retrieves the blocking stub for the BillPaymentProtoService.
     *
     * @return The blocking stub for the BillPaymentProtoService.
     */
    private BillPaymentProtoServiceGrpc.BillPaymentProtoServiceBlockingStub getBillPaymentBlockingStub() {
        if (billPaymentBlockingStub == null) {
            ManagedChannel channel = ManagedChannelProvider.getChannel();
            billPaymentBlockingStub = BillPaymentProtoServiceGrpc.newBlockingStub(channel);
        }
        return billPaymentBlockingStub;
    }

    /**
     * Creates a new bill payment.
     *
     * @param billPayment The {@link BillPaymentEntity} object containing the details of the bill payment.
     * @return The created {@link BillPaymentEntity} object.
     * @throws RuntimeException if an exception occurs during the creation of the bill payment.
     */
    @Override
    public BillPaymentEntity createBillPayment(BillPaymentEntity billPayment) {
        try {
            System.out.println(billPayment.getPayee()+"this is client");
            BillTransaction.BillPaymentProtoObj billPaymentProtoObj = fromEntityToProtoObj(billPayment);

            BillTransaction.BillPaymentProtoObj protoObj = getBillPaymentBlockingStub().createBillPaymentAsync(billPaymentProtoObj);
            return fromProtoObjToEntity(protoObj);
        } catch (Exception e) {
                throw new RuntimeException(e);
        }
    }

    /**
     * Fetches a bill payment by its ID.
     *
     * @param id The ID of the bill payment to fetch.
     * @return The {@link BillPaymentEntity} object representing the fetched bill payment.
     * @throws RuntimeException if an exception occurs during the fetching of the bill payment.
     */
    @Override
    public BillPaymentEntity fetchBillPaymentById(Long id) {
        try {
            BillTransaction.BillPaymentProtoObj billPaymentProtoObj = getBillPaymentBlockingStub().fetchBillPaymentByIdAsync(Int64Value.of(id));
            return fromProtoObjToEntity(billPaymentProtoObj);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    /**
     * Fetches all bill payments by the sender's username.
     *
     * @param senderUsername The username of the sender.
     * @return A list of {@link BillPaymentEntity} objects representing the fetched bill payments.
     * @throws RuntimeException if an exception occurs during the fetching of the bill payments.
     */
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


    /**
     * Fetches all bill payments by the receiver's payee name.
     *
     * @param payeeName The payee name of the receiver.
     * @return A list of {@link BillPaymentEntity} objects representing the fetched bill payments.
     * @throws RuntimeException if an exception occurs during the fetching of the bill payments.
     */
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

    /**
     * Fetches all bill payments involving a specific user.
     *
     * @param username The username of the user.
     * @return A list of {@link BillPaymentEntity} objects representing the fetched bill payments.
     * @throws RuntimeException if an exception occurs during the fetching of the bill payments.
     */
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

    /**
     * Fetches all bill payments by a specific date.
     *
     * @param date The date in string format.
     * @return A list of {@link BillPaymentEntity} objects representing the fetched bill payments.
     * @throws RuntimeException if an exception occurs during the fetching of the bill payments.
     */
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


    /**
     * Deletes a bill payment by its ID.
     *
     * @param id The ID of the bill payment to delete.
     * @return true if the bill payment is successfully deleted, false otherwise.
     * @throws RuntimeException if an exception occurs during the deletion of the bill payment.
     */
    @Override
    public boolean deleteBillPayment(Long id) {
        try {
            BoolValue billPaymentProtoObj = getBillPaymentBlockingStub().deleteBillPaymentAsync(Int64Value.of(id));
            return billPaymentProtoObj.toBuilder().getValue();
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }


    /**
     * Converts a {@link BillTransaction.BillPaymentProtoObj} object to a {@link BillPaymentEntity} object.
     *
     * @param billPaymentProtoObj The {@link BillTransaction.BillPaymentProtoObj} object to convert.
     * @return The converted {@link BillPaymentEntity} object.
     */
    public static BillPaymentEntity fromProtoObjToEntity(BillTransaction.BillPaymentProtoObj billPaymentProtoObj) {
        BillPaymentEntity billPayment = new BillPaymentEntity();
        billPayment.setPayee(billPaymentProtoObj.getPayeeName().getValue());
        billPayment.setPayer(UserClientImpl.fromProtoObjToEntity(billPaymentProtoObj.getSenderUser()));
        billPayment.setAmount(billPaymentProtoObj.getAmount().getValue());
        billPayment.setDate(billPaymentProtoObj.getDate().getValue());
        billPayment.setId(billPaymentProtoObj.getBillPaymentId().getValue());
        billPayment.setAccountNumber(billPaymentProtoObj.getAccountNumber().getValue());
        billPayment.setReferenceNumber(billPaymentProtoObj.getReference().getValue());

        return billPayment;
    }

    /**
     * Converts a {@link BillPaymentEntity} object to a {@link BillTransaction.BillPaymentProtoObj} object.
     *
     * @param billPayment The {@link BillPaymentEntity} object to convert.
     * @return The converted {@link BillTransaction.BillPaymentProtoObj} object.
     */
    public static BillTransaction.BillPaymentProtoObj fromEntityToProtoObj(BillPaymentEntity billPayment) {
        BillTransaction.BillPaymentProtoObj.Builder billPaymentBuilder = BillTransaction.BillPaymentProtoObj.newBuilder()
                .setPayeeName(StringValue.of(billPayment.getPayee()))
                .setSenderUser(UserClientImpl.fromEntityToProtoObj(billPayment.getPayer()))
                .setDate(StringValue.of(billPayment.getDate()))
                .setAmount(Int32Value.of(billPayment.getAmount()))
                .setAccountNumber(StringValue.of(billPayment.getAccountNumber()))
                .setReference(StringValue.of(billPayment.getReferenceNumber()));


        if (billPayment.getId() != null || billPayment.getId() != 0) {
            billPaymentBuilder.setBillPaymentId(Int64Value.of(billPayment.getId()));
        }

        return billPaymentBuilder.build();
    }
}
