package applicationtier.GrpcClient.card;

import applicationtier.GrpcClient.ManagedChannelProvider;
import applicationtier.entity.DebitCardEntity;
import applicationtier.protobuf.DebitCardProtoServiceGrpc;
import applicationtier.protobuf.Debitcard;
import io.grpc.ManagedChannel;
import org.springframework.stereotype.Service;

@Service
public class CardClientImpl implements ICardClient {
    private DebitCardProtoServiceGrpc.DebitCardProtoServiceBlockingStub cardBlockingStub;


    private DebitCardProtoServiceGrpc.DebitCardProtoServiceBlockingStub getCardBlockingStub() {
        if (cardBlockingStub == null) {
            ManagedChannel channel = ManagedChannelProvider.getChannel();
            cardBlockingStub = DebitCardProtoServiceGrpc.newBlockingStub(channel);
        }
        return cardBlockingStub;
    }

    @Override
    public DebitCardEntity createCard(DebitCardEntity debitCardEntity) {
        try {
            Debitcard.DebitCardProtoObj cardProtoObj = fromEntityToProtoObj(debitCardEntity);
            Debitcard.DebitCardProtoObj protoObj = getCardBlockingStub().createCard(cardProtoObj);
            return fromProtoObjToEntity(protoObj);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    @Override
    public DebitCardEntity fetchCardByUsername(String username) {
        return null;
    }

    @Override
    public DebitCardEntity updateCardDetails(DebitCardEntity debitCard) {
        return null;
    }

    @Override
    public boolean deleteCard(Long cardId) {
        return false;
    }

    public static Debitcard.DebitCardProtoObj fromEntityToProtoObj(DebitCardEntity debitCard) {
        Debitcard.DebitCardProtoObj.Builder cardBuilder = Debitcard.DebitCardProtoObj.newBuilder()
                .setCardNumber(debitCard.getCardNumber())
                .setCvv(debitCard.getCvv())
                .setExpiryDate(debitCard.getExpiryDate());

        if (debitCard.getCardId() != null) {
            cardBuilder.setCardId(debitCard.getCardId());
        }
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
