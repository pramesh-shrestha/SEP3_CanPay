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


    /**
     * Get the blocking stub for the Debit Card Proto Service.
     * If the stub is not initialized, it initializes a new one using the ManagedChannel.
     *
     * @return The blocking stub for the Debit Card Proto Service.
     */
    private DebitCardProtoServiceGrpc.DebitCardProtoServiceBlockingStub getCardBlockingStub() {
        if (cardBlockingStub == null) {
            ManagedChannel channel = ManagedChannelProvider.getChannel();
            cardBlockingStub = DebitCardProtoServiceGrpc.newBlockingStub(channel);
        }
        return cardBlockingStub;
    }

    /**
     * Creates a new debit card by converting the given DebitCardEntity object to a DebitCardProtoObj,
     * invoking the createCard method of the Card Proto Service blocking stub,
     * and converting the returned DebitCardProtoObj back to a DebitCardEntity.
     *
     * @param debitCardEntity The DebitCardEntity object representing the debit card to create.
     * @return The created DebitCardEntity object.
     * @throws RuntimeException if an exception occurs during the creation process.
     */
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


    /**
     * Converts a DebitCardEntity object to DebitCardProtoObj.
     *
     * @param debitCard The DebitCardEntity object to convert.
     * @return The converted DebitCardProtoObj.
     */
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


    /**
     * Converts a DebitCardProtoObj to DebitCardEntity.
     *
     * @param cardProtoObj The DebitCardProtoObj to convert.
     * @return The converted DebitCardEntity.
     */
    public static DebitCardEntity fromProtoObjToEntity(Debitcard.DebitCardProtoObj cardProtoObj) {
        DebitCardEntity debitCardEntity = new DebitCardEntity();
        debitCardEntity.setCardId(cardProtoObj.getCardId());
        debitCardEntity.setCardNumber(cardProtoObj.getCardNumber());
        debitCardEntity.setCvv(cardProtoObj.getCvv());
        debitCardEntity.setExpiryDate(cardProtoObj.getExpiryDate());
        return debitCardEntity;
    }
}
