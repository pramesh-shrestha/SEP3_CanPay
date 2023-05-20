package applicationtier.service.serviceImplementations;

import applicationtier.GrpcClient.billPayment.IBillPaymentClient;
import applicationtier.GrpcClient.user.IUserClient;
import applicationtier.entity.BillPaymentEntity;
import applicationtier.entity.UserEntity;
import applicationtier.service.serviceInterfaces.IBillPaymentService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class BillPaymentServiceImplementation implements IBillPaymentService {

    private IBillPaymentClient billPaymentClient;
    private IUserClient userClient;

    @Autowired
    public BillPaymentServiceImplementation(IBillPaymentClient billPaymentClient, IUserClient userClient) {
        this.billPaymentClient = billPaymentClient;
        this.userClient = userClient;
    }

    @Override
    public BillPaymentEntity createBillPayment(BillPaymentEntity billPayment) {
        try {
            String receiver = billPayment.getPayeeName();
            Long accountNumber = billPayment.getAccountNumber();
            UserEntity sender = billPayment.getSender();
            int amount = billPayment.getAmount();


            if (sender.getBalance() < amount || sender.getBalance() == 0) {
                throw new Exception("Insufficient balance");
            }
            //set balance of sender after billPayment
            sender.setBalance(sender.getBalance() - amount);

            //update user
            userClient.updateUser(sender);

            //create billPayment
            return billPaymentClient.createBillPayment(billPayment);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }

    @Override
    public BillPaymentEntity fetchBillPaymentById(Long id) {
        try {
            return billPaymentClient.fetchBillPaymentById(id);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }

    @Override
    public List<BillPaymentEntity> fetchAlLBillPaymentsBySender(String senderUsername) {
        try {
            return billPaymentClient.fetchAlLBillPaymentsBySender(senderUsername);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }

    @Override
    public List<BillPaymentEntity> fetchAllBillPaymentByReceiver(String payeeName) {
        try {
            return billPaymentClient.fetchAllBillPaymentByReceiver(payeeName);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }

    @Override
    public List<BillPaymentEntity> fetchAllBillPaymentInvolvingUser(String username) {
        try {
            return billPaymentClient.fetchAllBillPaymentInvolvingUser(username);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }

    @Override
    public List<BillPaymentEntity> fetchBillPaymentByDate(String date) {
        try {
            return billPaymentClient.fetchBillPaymentByDate(date);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }


    @Override
    public boolean deleteBillPayment(Long id) {
        try {
            return billPaymentClient.deleteBillPayment(id);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }


}
