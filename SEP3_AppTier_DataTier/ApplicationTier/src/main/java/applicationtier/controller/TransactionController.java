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


    /**
     * Create a new transaction.
     *
     * @param transaction The transaction entity to be created.
     * @return ResponseEntity containing the created transaction entity in the response body with HTTP status 200 (OK),
     * or HTTP status 400 (Bad Request) if an exception occurs.
     */
    @PostMapping("/transactions")
    public ResponseEntity<TransactionEntity> createTransaction(@RequestBody TransactionEntity transaction) {
        try {

            TransactionEntity transactionEntity = transactionService.createTransaction(transaction);
            return new ResponseEntity<>(transactionEntity, HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    /**
     * Fetch all transactions involving a user.
     *
     * @param username The username of the user.
     * @return ResponseEntity containing a list of transaction entities involving the specified user
     * in the response body with HTTP status 200 (OK), or HTTP status 400 (Bad Request) if an exception occurs.
     */
    @GetMapping("/transactions/{username}")
    public ResponseEntity<List<TransactionEntity>> fetchAllTransactionInvolvingUser(@PathVariable("username") String username) {

        try {
            return new ResponseEntity<>(transactionService.fetchAllTransactionInvolvingUser(username), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }
}
