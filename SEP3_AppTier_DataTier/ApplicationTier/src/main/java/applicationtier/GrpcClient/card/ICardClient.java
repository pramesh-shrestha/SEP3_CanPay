package applicationtier.GrpcClient.card;

import applicationtier.entity.DebitCardEntity;

public interface ICardClient {
    boolean CreateCard(DebitCardEntity debitCardEntity);
    DebitCardEntity FetchCardByUsername(String username);
    DebitCardEntity UpdateCardDetails(DebitCardEntity debitCard);

    DebitCardEntity DeleteCard(int cardId);

}
