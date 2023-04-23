using EFCDataAccess.DAOInterface;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using SEP3_DataTier;

namespace GrpcService.Services;

public class DebitCardService : DebitCardProtoService.DebitCardProtoServiceBase
{
    

    public override Task<BoolValue> CreateCard(DebitCard request, ServerCallContext context)
    {
        
        return base.CreateCard(request, context);
    }

    public override Task<DebitCard> FetchCardByUsername(Int64Value request, ServerCallContext context)
    {
        return base.FetchCardByUsername(request, context);
    }

    public override Task<DebitCard> UpdateCardDetails(UpdateCard request, ServerCallContext context)
    {
        return base.UpdateCardDetails(request, context);
    }

    public override Task<BoolValue> DeleteCard(Int64Value request, ServerCallContext context)
    {
        return base.DeleteCard(request, context);
    }
}