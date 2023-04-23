package applicationtier.controller;

import applicationtier.entity.DebitCard;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import applicationtier.service.serviceInterfaces.ICardService;

@RestController
public class CardController {

    private final ICardService cardService;

    @Autowired
    public CardController(ICardService cardService) {
        this.cardService = cardService;
    }

    //Create Card--
    @PostMapping("/card/create")
    public ResponseEntity<DebitCard> CreateCard(@RequestBody DebitCard card){
        try {
            return new ResponseEntity<>(cardService.CreateCard(card), HttpStatus.OK);
        }
        catch (Exception e){
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    //Get Card by username--
    @GetMapping("/user/{username}")
    public ResponseEntity<DebitCard> FetchCardByUsername(@PathVariable("username") String username){
        try{
            return new ResponseEntity<>(cardService.FetchCardByUsername(username),HttpStatus.OK);
        }
        catch (Exception e){
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    //update card--
    @PutMapping("/card/{id}")
    public ResponseEntity<DebitCard> UpdateCard(@PathVariable long id, @RequestBody DebitCard card){
        try{
            return new ResponseEntity<>(cardService.updateCard(id,card),HttpStatus.OK);
        }
        catch (Exception e){
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    //delete card--
    @DeleteMapping("/card/delete/{id}")
    public ResponseEntity<String> DeleteCard(@PathVariable("id") long id){
        try {
            cardService.deleteCard(id);
            return new ResponseEntity<>("Card has been successfully deleted",HttpStatus.OK);
        }
        catch (Exception e){
            return  new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }
}
