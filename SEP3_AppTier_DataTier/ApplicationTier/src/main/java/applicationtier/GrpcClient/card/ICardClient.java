package applicationtier.GrpcClient.card;

import applicationtier.entity.DebitCardEntity;

public interface ICardClient {
    DebitCardEntity createCard(DebitCardEntity debitCardEntity);

    DebitCardEntity fetchCardByUsername(String username);

    DebitCardEntity updateCardDetails(DebitCardEntity debitCard);

    DebitCardEntity deleteCard(int cardId);

}
