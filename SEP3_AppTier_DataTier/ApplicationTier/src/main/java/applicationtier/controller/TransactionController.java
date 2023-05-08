package applicationtier.controller;

import applicationtier.entity.TransactionEntity;
import applicationtier.service.serviceInterfaces.ITransactionService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
public class TransactionController {
    private final ITransactionService transactionService;

    @Autowired
    public TransactionController(ITransactionService transactionService) {
        this.transactionService = transactionService;
    }

    //Create transaction
    @PostMapping("/transaction/create")
    public ResponseEntity<TransactionEntity> createTransaction(@RequestBody TransactionEntity transaction) {
        try {

            System.out.println("Transaction Controller: " + transaction.getReceiver().getUsername());

            return new ResponseEntity<>(transactionService.createTransaction(transaction), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    @GetMapping("/transaction/{id}")
    public ResponseEntity<TransactionEntity> fetchTransactionById(@PathVariable("id") Long id) {
        try {
            return new ResponseEntity<>(transactionService.fetchTransactionById(id), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    @GetMapping("/transaction/sender/{senderUsername}")
    public ResponseEntity<List<TransactionEntity>> fetchAllTransactionBySender(@PathVariable("senderUsername") String senderUsername) {
        try {
            return new ResponseEntity<>(transactionService.fetchAlLTransactionsBySender(senderUsername), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    @GetMapping("/transaction/receiver/{receiverUsername}")
    public ResponseEntity<List<TransactionEntity>> fetchAllTransactionByReceiver(@PathVariable("receiverUsername") String receiverUsername) {

        try {
            return new ResponseEntity<>(transactionService.fetchAllTransactionByReceiver(receiverUsername), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    @GetMapping("/transaction/{username}")
    public ResponseEntity<List<TransactionEntity>> fetchAllTransactionInvolvingUser(@PathVariable("username") String username) {

        try {
            return new ResponseEntity<>(transactionService.fetchAllTransactionInvolvingUser(username), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    @GetMapping("/transaction/date/{date}")
    public ResponseEntity<List<TransactionEntity>> fetchTransactionByDate(@PathVariable("date") String date) {

        try {
            return new ResponseEntity<>(transactionService.fetchTransactionByDate(date), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    @DeleteMapping("/transaction/delete/{id}")
    public ResponseEntity<String> deleterTransaction(@PathVariable("id") Long id) {

        try {
            transactionService.deleteTransaction(id);
            return new ResponseEntity<>("Transaction has been deleted", HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }
}
