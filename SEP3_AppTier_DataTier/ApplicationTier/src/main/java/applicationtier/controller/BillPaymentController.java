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
     * a {@link ResponseEntity} with a {@link HttpStatus#BAD_REQUEST} status code if an exception occurs.
     */
    @PostMapping("/billPayments")
    public ResponseEntity<BillPaymentEntity> createBillPayment(@RequestBody BillPaymentEntity billPayment) {
        try {
            BillPaymentEntity billPaymentEntity = billPaymentService.createBillPayment(billPayment);
            return new ResponseEntity<>(billPaymentEntity, HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    /**
     * Fetches all bill payments involving a specific user.
     *
     * @param username The username of the user involved in the bill payments.
     * @return A {@link ResponseEntity} containing a list of {@link BillPaymentEntity} objects if successful,
     * or a {@link ResponseEntity} with a {@link HttpStatus#BAD_REQUEST} status code if an exception occurs.
     */
    @GetMapping("/billPayments/{username}")
    public ResponseEntity<List<BillPaymentEntity>> fetchAllBillPaymentInvolvingUser(@PathVariable("username") String username) {

        try {
            return new ResponseEntity<>(billPaymentService.fetchAllBillPaymentInvolvingUser(username), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }
}
