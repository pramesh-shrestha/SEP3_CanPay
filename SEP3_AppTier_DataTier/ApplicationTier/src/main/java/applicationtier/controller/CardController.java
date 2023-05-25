package applicationtier.controller;

import applicationtier.entity.DebitCardEntity;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import applicationtier.service.serviceInterfaces.ICardService;

/**
 *
 */
@RestController
public class CardController {

    private final ICardService cardService;

    @Autowired
    public CardController(ICardService cardService) {
        this.cardService = cardService;
    }

    /**
     * Create a new card.
     *
     * @param card The debit card entity to be created.
     * @return ResponseEntity containing the created debit card entity in the response body with HTTP status 200 (OK),
     *         or HTTP status 400 (Bad Request) if an exception occurs.
     */
    @PostMapping("/card/create")
    public ResponseEntity<DebitCardEntity> CreateCard(@RequestBody
                                                      DebitCardEntity card) {
        try {
            return new ResponseEntity<>(cardService.CreateCard(card), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    /**
     * Fetch a card by username.
     *
     * @param username The username associated with the card.
     * @return ResponseEntity containing the debit card entity with the specified username in the response body
     *         with HTTP status 200 (OK), or HTTP status 400 (Bad Request) if an exception occurs.
     */
    @GetMapping("/card/{username}")
    public ResponseEntity<DebitCardEntity> FetchCardByUsername(@PathVariable("username") String username) {
        try {
            return new ResponseEntity<>(cardService.FetchCardByUsername(username), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    /**
     * Update a card by ID.
     *
     * @param id    The ID of the card to be updated.
     * @param card  The updated debit card entity.
     * @return ResponseEntity containing the updated debit card entity in the response body with HTTP status 200 (OK),
     *         or HTTP status 400 (Bad Request) if an exception occurs.
     */
    @PutMapping("/card/{id}")
    public ResponseEntity<DebitCardEntity> UpdateCard(@PathVariable long id, @RequestBody
    DebitCardEntity card) {
        try {
            return new ResponseEntity<>(cardService.updateCard(id, card), HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    /**
     * Delete a card by ID.
     *
     * @param id The ID of the card to be deleted.
     * @return ResponseEntity with a success message in the response body with HTTP status 200 (OK),
     *         or HTTP status 400 (Bad Request) if an exception occurs.
     */
    @DeleteMapping("/card/delete/{id}")
    public ResponseEntity<String> DeleteCard(@PathVariable("id") long id) {
        try {
            cardService.deleteCard(id);
            return new ResponseEntity<>("Card has been successfully deleted", HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }
}
