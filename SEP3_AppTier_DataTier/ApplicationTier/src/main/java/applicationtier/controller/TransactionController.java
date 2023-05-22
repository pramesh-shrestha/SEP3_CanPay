package applicationtier.controller;

import applicationtier.dto.FilterDto;
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
     *         or HTTP status 400 (Bad Request) if an exception occurs.
     */
    @PostMapping("/transaction/create")
    public ResponseEntity<TransactionEntity> createTransaction(@RequestBody TransactionEntity transaction) {
        try {

            TransactionEntity transactionEntity = transactionService.createTransaction(transaction);
            return new ResponseEntity<>(transactionEntity, HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    /**
     * Fetch a transaction by ID.
     *
     * @param id The ID of the transaction to be fetched.
     * @return ResponseEntity containing the transaction entity with the specified ID in the response body
     *         with HTTP status 200 (OK), or HTTP status 400 (Bad Request) if an exception occurs.
     */
    @GetMapping("/transaction/{id}")
    public ResponseEntity<TransactionEntity> fetchTransactionById(@PathVariable("id") Long id) {
        try {
            return new ResponseEntity<>(transactionService.fetchTransactionById(id), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    /**
     * Fetch all transactions by sender username.
     *
     * @param senderUsername The username of the sender.
     * @return ResponseEntity containing a list of transaction entities with the specified sender username
     *         in the response body with HTTP status 200 (OK), or HTTP status 400 (Bad Request) if an exception occurs.
     */
    @GetMapping("/transaction/sender/{senderUsername}")
    public ResponseEntity<List<TransactionEntity>> fetchAllTransactionBySender(@PathVariable("senderUsername") String senderUsername) {
        try {
            return new ResponseEntity<>(transactionService.fetchAlLTransactionsBySender(senderUsername), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    /**
     * Fetch all transactions by receiver username.
     *
     * @param receiverUsername The username of the receiver.
     * @return ResponseEntity containing a list of transaction entities with the specified receiver username
     *         in the response body with HTTP status 200 (OK), or HTTP status 400 (Bad Request) if an exception occurs.
     */
    @GetMapping("/transaction/receiver/{receiverUsername}")
    public ResponseEntity<List<TransactionEntity>> fetchAllTransactionByReceiver(@PathVariable("receiverUsername") String receiverUsername) {

        try {
            return new ResponseEntity<>(transactionService.fetchAllTransactionByReceiver(receiverUsername), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    /**
     * Fetch all transactions involving a user.
     *
     * @param username The username of the user.
     * @return ResponseEntity containing a list of transaction entities involving the specified user
     *         in the response body with HTTP status 200 (OK), or HTTP status 400 (Bad Request) if an exception occurs.
     */
    @GetMapping("/transaction/user/{username}")
    public ResponseEntity<List<TransactionEntity>> fetchAllTransactionInvolvingUser(@PathVariable("username") String username) {

        try {
            return new ResponseEntity<>(transactionService.fetchAllTransactionInvolvingUser(username), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    /**
     * Fetch transactions by date.
     *
     * @param date The date of the transactions.
     * @return ResponseEntity containing a list of transaction entities with the specified date
     *         in the response body with HTTP status 200 (OK), or HTTP status 400 (Bad Request) if an exception occurs.
     */
    @GetMapping("/transaction/date/{date}")
    public ResponseEntity<List<TransactionEntity>> fetchTransactionByDate(@PathVariable("date") String date) {

        try {
            return new ResponseEntity<>(transactionService.fetchTransactionByDate(date), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    /**
     * Fetch transactions by date and username.
     *
     * @param date     The date of the transactions.
     * @param username The username of the user.
     * @return ResponseEntity containing a list of transaction entities with the specified date and username
     *         in the response body with HTTP status 200 (OK), or HTTP status 400 (Bad Request) if an exception occurs.
     */
    @GetMapping("/transaction/date/{date}/username/{username}")
    public ResponseEntity<List<TransactionEntity>> fetchTransactionsByDateAndUsername(
            @PathVariable String date,
            @PathVariable String username) {
        try {
            FilterDto filter = new FilterDto(username, date);
            List<TransactionEntity> transactions = transactionService.fetchTransactionByDateAndUsername(filter);
            return new ResponseEntity<>(transactions, HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }


    /**
     * Delete a transaction by ID.
     *
     * @param id The ID of the transaction to be deleted.
     * @return ResponseEntity with a success message in the response body with HTTP status 200 (OK),
     *         or HTTP status 400 (Bad Request) if an exception occurs.
     */
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
