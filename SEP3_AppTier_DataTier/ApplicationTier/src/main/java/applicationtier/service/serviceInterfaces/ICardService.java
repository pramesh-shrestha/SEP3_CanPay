package applicationtier.service.serviceInterfaces;


import applicationtier.entity.DebitCardEntity;

public interface ICardService {
    DebitCardEntity CreateCard(DebitCardEntity card);
    DebitCardEntity FetchCardByUsername(String username);
    DebitCardEntity updateCard(Long id, DebitCardEntity card);
    void deleteCard(Long id);
}
