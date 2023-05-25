package applicationtier.service.serviceImplementations;


import applicationtier.GrpcClient.card.ICardClient;
import applicationtier.entity.DebitCardEntity;
import applicationtier.service.serviceInterfaces.ICardService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class CardServiceImplementation implements ICardService {
    private ICardClient cardClient;

    @Autowired
    public CardServiceImplementation(ICardClient cardClient) {
        this.cardClient = cardClient;
    }

    /**
     * Creates a new debit card.
     *
     * @param card The debit card entity to create.
     * @return The created debit card entity.
     * @throws RuntimeException If an error occurs during the creation process.
     */
    @Override
    public DebitCardEntity CreateCard(DebitCardEntity card) {
        try {
            return cardClient.createCard(card);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }

    /**
     * Fetches a debit card by the associated username.
     *
     * @param username The username associated with the debit card.
     * @return The fetched debit card entity.
     * @throws RuntimeException If an error occurs during the fetching process.
     */
    @Override
    public DebitCardEntity FetchCardByUsername(String username) {
        try {
            return cardClient.fetchCardByUsername(username);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }

    /**
     * Updates the details of a debit card.
     *
     * @param id   The ID of the debit card to update.
     * @param card The updated debit card entity.
     * @return The updated debit card entity.
     * @throws RuntimeException If an error occurs during the update process.
     */
    @Override
    public DebitCardEntity updateCard(Long id, DebitCardEntity card) {
        try {
            return cardClient.updateCardDetails(card);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }

    /**
     * Deletes a debit card by its ID.
     *
     * @param id The ID of the debit card to delete.
     * @return True if the deletion is successful, false otherwise.
     * @throws RuntimeException If an error occurs during the deletion process.
     */
    @Override
    public boolean deleteCard(Long id) {
        try {
            return cardClient.deleteCard(id);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }
}
