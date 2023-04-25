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

    @Override
    public DebitCardEntity CreateCard(DebitCardEntity card) {
        try {
            return cardClient.createCard(card);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }

    @Override
    public DebitCardEntity FetchCardByUsername(String username) {
        try {
            return cardClient.fetchCardByUsername(username);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }

    @Override
    public DebitCardEntity updateCard(Long id, DebitCardEntity card) {
        try {
            return cardClient.updateCardDetails(card);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }

    @Override
    public boolean deleteCard(Long id) {
        try {
            return cardClient.deleteCard(id);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }
}
