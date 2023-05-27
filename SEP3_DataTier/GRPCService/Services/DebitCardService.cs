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

    /// <summary>
    /// Creates a debit card based on the provided proto object.
    /// </summary>
    /// <param name="request">The proto object representing the debit card.</param>
    /// <param name="context">The server call context.</param>
    /// <returns>The created debit card as a proto object.</returns>
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

    /// <summary>
    /// Fetches a debit card by username.
    /// </summary>
    /// <param name="request">The username as a string value.</param>
    /// <param name="context">The server call context.</param>
    /// <returns>The debit card as a proto object.</returns>
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
    

    /// <summary>
    /// Deletes a debit card by ID.
    /// </summary>
    /// <param name="request">The ID of the debit card as a 64-bit integer value.</param>
    /// <param name="context">The server call context.</param>
    /// <returns>A boolean value indicating the success of the deletion operation.</returns>
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

    /// <summary>
    /// Converts a DebitCardProtoObj object to a DebitCardEntity object.
    /// </summary>
    /// <param name="debitCard">The DebitCardProtoObj object to convert.</param>
    /// <returns>A DebitCardEntity object converted from the provided DebitCardProtoObj.</returns>
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


    /// <summary>
    /// Converts a DebitCardEntity object to a DebitCardProtoObj object.
    /// </summary>
    /// <param name="cardEntity">The DebitCardEntity object to convert.</param>
    /// <returns>A DebitCardProtoObj object converted from the provided DebitCardEntity.</returns>
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