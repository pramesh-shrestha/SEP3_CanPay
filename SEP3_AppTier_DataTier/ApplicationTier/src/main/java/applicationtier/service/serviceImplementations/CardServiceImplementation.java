package applicationtier.service.serviceImplementations;


import applicationtier.entity.DebitCardEntity;
import applicationtier.service.serviceInterfaces.ICardService;
import org.springframework.stereotype.Service;

@Service
public class CardServiceImplementation implements ICardService {
    @Override
    public DebitCardEntity CreateCard(DebitCardEntity card) {
        return null;
    }

    @Override
    public DebitCardEntity FetchCardByUsername(String username) {
        return null;
    }

    @Override
    public DebitCardEntity updateCard(Long id, DebitCardEntity card) {
        return null;
    }

    @Override
    public void deleteCard(Long id) {

    }
}
