package applicationtier.GrpcClient.card;

import applicationtier.entity.DebitCardEntity;
import applicationtier.protobuf.Debitcard;
import org.springframework.stereotype.Service;

import java.time.LocalDate;

@Service
public class CardClient implements ICardClient {
    @Override
    public boolean CreateCard(DebitCardEntity debitCardEntity) {
        return false;
    }

    @Override
    public DebitCardEntity FetchCardByUsername(String username) {
        return null;
    }

    @Override
    public DebitCardEntity UpdateCardDetails(DebitCardEntity debitCard) {
        return null;
    }

    @Override
    public DebitCardEntity DeleteCard(int cardId) {
        return null;
    }

    public static Debitcard.DebitCardProtoObj fromEntityToProtoObj(DebitCardEntity debitCard) {
        Debitcard.DebitCardProtoObj.Builder cardBuilder = Debitcard.DebitCardProtoObj.newBuilder()
                .setCardNumber(debitCard.getCardNumber())
                .setCvv(debitCard.getCvv())
                .setExpiryDate(debitCard.getExpiryDate());
        return cardBuilder.build();
    }

    public static DebitCardEntity fromProtoObjToEntity(Debitcard.DebitCardProtoObj cardProtoObj) {
        DebitCardEntity debitCardEntity = new DebitCardEntity();
        debitCardEntity.setCardId(cardProtoObj.getCardId());
        debitCardEntity.setCardNumber(cardProtoObj.getCardNumber());
        debitCardEntity.setCvv(cardProtoObj.getCvv());
        debitCardEntity.setExpiryDate(cardProtoObj.getExpiryDate());
        return debitCardEntity;
    }
}
