using Entity.Model;
using SEP3_DataTier;

namespace GrpcService.ObjectMapper;

public class DebitCardMapper
{
    public static DebitCardEntity FromProtoToEntity(DebitCard debitCard)
    {
        return new DebitCardEntity
        {
            CardNumber = debitCard.CardNumber,
            CVV = debitCard.Cvv,
            ExpiryDate = debitCard.ExpiryDate
        };
    }
    


    public static DebitCard FromEntityToProto(DebitCardEntity userEntityCardEntity)
    {
        throw new NotImplementedException();
    }
}