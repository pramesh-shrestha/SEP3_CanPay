using EFCDataAccess.DAOInterface;
using Entity.Model;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using SEP3_DataTier;

namespace GrpcService.Services;

public class DebitCardService : DebitCardProtoService.DebitCardProtoServiceBase
{
    private readonly ICardDao cardDao;

    public DebitCardService(ICardDao cardDao)
    {
        this.cardDao = cardDao;
    }

    public override async Task<DebitCardProtoObj> CreateCard(DebitCardProtoObj request, ServerCallContext context)
    {
        try
        {
            DebitCardEntity debitCardEntity = FromProtoToEntity(request);
            DebitCardEntity addedCard = await cardDao.CreateCardAsync(debitCardEntity);

            return FromEntityToProto(addedCard);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new RpcException(new Status(StatusCode.AlreadyExists, e.Message));
        }
    }

    public override async Task<DebitCardProtoObj> FetchCardByUsername(StringValue request, ServerCallContext context)
    {
        try
        {
            DebitCardEntity debitCardEntity = await cardDao.FetchCardByUsernameAsync(request.Value);
            return FromEntityToProto(debitCardEntity);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new RpcException(new Status(StatusCode.NotFound, e.Message));
        }
    }

    public override Task<DebitCardProtoObj> UpdateCardDetails(UpdateCard request, ServerCallContext context)
    {
        return base.UpdateCardDetails(request, context);
    }

    public override async Task<BoolValue> DeleteCard(Int64Value request, ServerCallContext context)
    {
        try
        {
            await cardDao.DeleteCardAsync(request.Value);
            return new BoolValue { Value = true };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new RpcException(new Status(StatusCode.NotFound, e.Message));
        }
    }

    public static DebitCardEntity FromProtoToEntity(DebitCardProtoObj debitCard)
    {
        DebitCardEntity cardEntity = new DebitCardEntity
        {
            CardNumber = debitCard.CardNumber,
            CVV = debitCard.Cvv,
            ExpiryDate = debitCard.ExpiryDate
        };

        if (debitCard.CardId != 0)
        {
            cardEntity.CardId = debitCard.CardId;
        }

        return cardEntity;
    }


    public static DebitCardProtoObj FromEntityToProto(DebitCardEntity cardEntity)
    {
        return new DebitCardProtoObj()
        {
            CardId = cardEntity.CardId,
            CardNumber = cardEntity.CardNumber,
            ExpiryDate = cardEntity.ExpiryDate,
            Cvv = cardEntity.CVV
        };
    }
}