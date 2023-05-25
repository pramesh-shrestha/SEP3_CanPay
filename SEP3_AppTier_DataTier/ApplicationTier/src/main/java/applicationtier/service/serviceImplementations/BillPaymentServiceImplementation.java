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

    /**
     * Constructs a new instance of the {@code BillPaymentServiceImplementation} class.
     *
     * @param billPaymentClient The bill payment client used for bill payment operations.
     * @param userClient The user client used for user-related operations.
     */
    @Autowired
    public BillPaymentServiceImplementation(IBillPaymentClient billPaymentClient, IUserClient userClient) {
        this.billPaymentClient = billPaymentClient;
        this.userClient = userClient;
    }

    /**
     * Creates a new bill payment.
     *
     * @param billPayment The {@link BillPaymentEntity} representing the bill payment to create.
     * @return The created {@link BillPaymentEntity}.
     * @throws RuntimeException If an error occurs during the bill payment creation process.
     * @throws Exception If the sender's balance is insufficient or zero.
     */
    @Override
    public BillPaymentEntity createBillPayment(BillPaymentEntity billPayment) {
        try {

            UserEntity sender = billPayment.getPayer();
            int amount = billPayment.getAmount();


            if (sender.getBalance() < amount || sender.getBalance() == 0) {
                throw new Exception("Insufficient balance");
            }
            //set balance of sender after billPayment
            sender.setBalance(sender.getBalance() - amount);

            //update user
            userClient.updateUser(sender);

            //create billPayment
            System.out.println(billPayment.getAccountNumber()+"this is service");
            return billPaymentClient.createBillPayment(billPayment);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }

    /**
     * Fetches a bill payment by its ID.
     *
     * @param id The ID of the bill payment to fetch.
     * @return The {@link BillPaymentEntity} representing the fetched bill payment.
     * @throws RuntimeException If an error occurs during the bill payment retrieval process.
     */
    @Override
    public BillPaymentEntity fetchBillPaymentById(Long id) {
        try {
            return billPaymentClient.fetchBillPaymentById(id);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }

    /**
     * Fetches all bill payments made by a specific sender.
     *
     * @param senderUsername The username of the sender.
     * @return A list of {@link BillPaymentEntity} objects representing the bill payments made by the sender.
     * @throws RuntimeException If an error occurs during the bill payment retrieval process.
     */
    @Override
    public List<BillPaymentEntity> fetchAlLBillPaymentsBySender(String senderUsername) {
        try {
            return billPaymentClient.fetchAlLBillPaymentsBySender(senderUsername);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }

    /**
     * Fetches all bill payments received by a specific payee.
     *
     * @param payeeName The name of the payee.
     * @return A list of {@link BillPaymentEntity} objects representing the bill payments received by the payee.
     * @throws RuntimeException If an error occurs during the bill payment retrieval process.
     */
    @Override
    public List<BillPaymentEntity> fetchAllBillPaymentByReceiver(String payeeName) {
        try {
            return billPaymentClient.fetchAllBillPaymentByReceiver(payeeName);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }

    /**
     * Fetches all bill payments involving a specific user.
     *
     * @param username The username of the user involved in the bill payments.
     * @return A list of {@link BillPaymentEntity} objects representing the bill payments involving the user.
     * @throws RuntimeException If an error occurs during the bill payment retrieval process.
     */
    @Override
    public List<BillPaymentEntity> fetchAllBillPaymentInvolvingUser(String username) {
        try {
            return billPaymentClient.fetchAllBillPaymentInvolvingUser(username);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }

    /**
     * Fetches all bill payments made on a specific date.
     *
     * @param date The date in string format (e.g., "yyyy-MM-dd") for which to fetch the bill payments.
     * @return A list of {@link BillPaymentEntity} objects representing the bill payments made on the specified date.
     * @throws RuntimeException If an error occurs during the bill payment retrieval process.
     */
    @Override
    public List<BillPaymentEntity> fetchBillPaymentByDate(String date) {
        try {
            return billPaymentClient.fetchBillPaymentByDate(date);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }


    /**
     * Deletes a bill payment with the specified ID.
     *
     * @param id The ID of the bill payment to delete.
     * @return {@code true} if the bill payment was successfully deleted, {@code false} otherwise.
     * @throws RuntimeException If an error occurs during the bill payment deletion process.
     */
    @Override
    public boolean deleteBillPayment(Long id) {
        try {
            return billPaymentClient.deleteBillPayment(id);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }


}
