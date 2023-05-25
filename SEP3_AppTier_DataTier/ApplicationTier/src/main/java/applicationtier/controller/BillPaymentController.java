package applicationtier.controller;

import applicationtier.entity.BillPaymentEntity;
import applicationtier.service.serviceInterfaces.IBillPaymentService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
public class BillPaymentController {
    private final IBillPaymentService billPaymentService;

    @Autowired
    public BillPaymentController(IBillPaymentService billPaymentService) {
        this.billPaymentService = billPaymentService;
    }

    /**
     * Creates a new bill payment.
     *
     * @param billPayment The {@link BillPaymentEntity} object containing the details of the bill payment.
     * @return A {@link ResponseEntity} containing the created {@link BillPaymentEntity} if successful, or
     *         a {@link ResponseEntity} with a {@link HttpStatus#BAD_REQUEST} status code if an exception occurs.
     */
    @PostMapping("/billPayment/create")
    public ResponseEntity<BillPaymentEntity> createBillPayment(@RequestBody BillPaymentEntity billPayment) {
        try {
            System.out.println(billPayment.getAccountNumber()+"controller class");
            BillPaymentEntity billPaymentEntity = billPaymentService.createBillPayment(billPayment);
            return new ResponseEntity<>(billPaymentEntity, HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    /**
     * Fetches a bill payment by its ID.
     *
     * @param id The ID of the bill payment to fetch.
     * @return A {@link ResponseEntity} containing the fetched {@link BillPaymentEntity} if found, or
     *         a {@link ResponseEntity} with a {@link HttpStatus#BAD_REQUEST} status code if an exception occurs.
     */
    @GetMapping("/billPayment/{id}")
    public ResponseEntity<BillPaymentEntity> fetchBillPaymentById(@PathVariable("id") Long id) {
        try {
            return new ResponseEntity<>(billPaymentService.fetchBillPaymentById(id), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    /**
     * Fetches all bill payments by the sender's username.
     *
     * @param senderUsername The username of the sender.
     * @return A {@link ResponseEntity} containing a list of {@link BillPaymentEntity} objects if successful,
     *         or a {@link ResponseEntity} with a {@link HttpStatus#BAD_REQUEST} status code if an exception occurs.
     */
    @GetMapping("/billPayment/sender/{senderUsername}")
    public ResponseEntity<List<BillPaymentEntity>> fetchAllBillPaymentBySender(@PathVariable("senderUsername") String senderUsername) {
        try {
            return new ResponseEntity<>(billPaymentService.fetchAlLBillPaymentsBySender(senderUsername), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    /**
     * Fetches all bill payments by the receiver's payee name.
     *
     * @param payeeName The name of the payee (receiver).
     * @return A {@link ResponseEntity} containing a list of {@link BillPaymentEntity} objects if successful,
     *         or a {@link ResponseEntity} with a {@link HttpStatus#BAD_REQUEST} status code if an exception occurs.
     */
    @GetMapping("/billPayment/receiver/{payeeName}")
    public ResponseEntity<List<BillPaymentEntity>> fetchAllBillPaymentByReceiver(@PathVariable("payeeName") String payeeName) {

        try {
            return new ResponseEntity<>(billPaymentService.fetchAllBillPaymentByReceiver(payeeName), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    /**
     * Fetches all bill payments involving a specific user.
     *
     * @param username The username of the user involved in the bill payments.
     * @return A {@link ResponseEntity} containing a list of {@link BillPaymentEntity} objects if successful,
     *         or a {@link ResponseEntity} with a {@link HttpStatus#BAD_REQUEST} status code if an exception occurs.
     */
    @GetMapping("/billPayment/user/{username}")
    public ResponseEntity<List<BillPaymentEntity>> fetchAllBillPaymentInvolvingUser(@PathVariable("username") String username) {

        try {
            return new ResponseEntity<>(billPaymentService.fetchAllBillPaymentInvolvingUser(username), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    /**
     * Fetches all bill payments by a specific date.
     *
     * @param date The date of the bill payments in the format "YYYY-MM-DD".
     * @return A {@link ResponseEntity} containing a list of {@link BillPaymentEntity} objects if successful,
     *         or a {@link ResponseEntity} with a {@link HttpStatus#BAD_REQUEST} status code if an exception occurs.
     */
    @GetMapping("/billPayment/date/{date}")
    public ResponseEntity<List<BillPaymentEntity>> fetchBillPaymentByDate(@PathVariable("date") String date) {

        try {
            return new ResponseEntity<>(billPaymentService.fetchBillPaymentByDate(date), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }


    /**
     * Deletes a bill payment by its ID.
     *
     * @param id The ID of the bill payment to delete.
     * @return A {@link ResponseEntity} with a success message if the deletion is successful,
     *         or a {@link ResponseEntity} with a {@link HttpStatus#BAD_REQUEST} status code if an exception occurs.
     */
    @DeleteMapping("/billPayment/delete/{id}")
    public ResponseEntity<String> deleterBillPayment(@PathVariable("id") Long id) {

        try {
            billPaymentService.deleteBillPayment(id);
            return new ResponseEntity<>("BillPayment has been deleted", HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }
}
