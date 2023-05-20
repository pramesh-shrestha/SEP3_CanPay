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

    //Create billPayment
    @PostMapping("/billPayment/create")
    public ResponseEntity<BillPaymentEntity> createBillPayment(@RequestBody BillPaymentEntity billPayment) {
        try {

            BillPaymentEntity billPaymentEntity = billPaymentService.createBillPayment(billPayment);
            return new ResponseEntity<>(billPaymentEntity, HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    @GetMapping("/billPayment/{id}")
    public ResponseEntity<BillPaymentEntity> fetchBillPaymentById(@PathVariable("id") Long id) {
        try {
            return new ResponseEntity<>(billPaymentService.fetchBillPaymentById(id), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    @GetMapping("/billPayment/sender/{senderUsername}")
    public ResponseEntity<List<BillPaymentEntity>> fetchAllBillPaymentBySender(@PathVariable("senderUsername") String senderUsername) {
        try {
            return new ResponseEntity<>(billPaymentService.fetchAlLBillPaymentsBySender(senderUsername), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    @GetMapping("/billPayment/receiver/{payeeName}")
    public ResponseEntity<List<BillPaymentEntity>> fetchAllBillPaymentByReceiver(@PathVariable("payeeName") String payeeName) {

        try {
            return new ResponseEntity<>(billPaymentService.fetchAllBillPaymentByReceiver(payeeName), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    @GetMapping("/billPayment/user/{username}")
    public ResponseEntity<List<BillPaymentEntity>> fetchAllBillPaymentInvolvingUser(@PathVariable("username") String username) {

        try {
            return new ResponseEntity<>(billPaymentService.fetchAllBillPaymentInvolvingUser(username), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    @GetMapping("/billPayment/date/{date}")
    public ResponseEntity<List<BillPaymentEntity>> fetchBillPaymentByDate(@PathVariable("date") String date) {

        try {
            return new ResponseEntity<>(billPaymentService.fetchBillPaymentByDate(date), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }



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
