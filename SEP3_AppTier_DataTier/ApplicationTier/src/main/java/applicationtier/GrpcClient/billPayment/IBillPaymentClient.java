package applicationtier.GrpcClient.billPayment;

import applicationtier.entity.BillPaymentEntity;

import java.util.List;

public interface IBillPaymentClient {
    BillPaymentEntity createBillPayment(BillPaymentEntity transaction);
    BillPaymentEntity fetchBillPaymentById(Long id);
    List<BillPaymentEntity> fetchAlLBillPaymentsBySender(String senderUsername);
    List<BillPaymentEntity> fetchAllBillPaymentByReceiver(String payeeName);
    List<BillPaymentEntity> fetchAllBillPaymentInvolvingUser(String username);
    List<BillPaymentEntity> fetchBillPaymentByDate(String date);
    boolean deleteBillPayment(Long id);

}
