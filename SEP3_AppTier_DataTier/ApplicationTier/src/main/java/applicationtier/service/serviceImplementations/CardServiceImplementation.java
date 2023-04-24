package applicationtier.service.serviceImplementations;


import applicationtier.entity.DebitCard;
import applicationtier.service.serviceInterfaces.ICardService;
import org.springframework.stereotype.Service;

@Service
public class CardServiceImplementation implements ICardService {
    @Override
    public DebitCard CreateCard(DebitCard card) {
        return null;
    }

    @Override
    public DebitCard FetchCardByUsername(String username) {
        return null;
    }

    @Override
    public DebitCard updateCard(Long id, DebitCard card) {
        return null;
    }

    @Override
    public void deleteCard(Long id) {

    }
}
