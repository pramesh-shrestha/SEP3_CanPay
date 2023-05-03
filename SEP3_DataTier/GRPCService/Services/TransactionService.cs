using EFCDataAccess.DAOInterface;
using Entity.Model;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using SEP3_DataTier;

namespace GrpcService.Services;

public class TransactionService : TransactionProtoService.TransactionProtoServiceBase
{
    private ITransactionDao transactionDao;

    public TransactionService(ITransactionDao transactionDao)
    {
        this.transactionDao = transactionDao;
    }

    public override Task<TransactionProtoObj> CreateTransactionAsync(TransactionProtoObj request,
        ServerCallContext context)
    {
        return base.CreateTransactionAsync(request, context);
    }

    public override Task<TransactionProtoObj> FetchTransactionByIdAsync(Int64Value request, ServerCallContext context)
    {
        return base.FetchTransactionByIdAsync(request, context);
    }

    public override Task<TransactionProtoObjList> FetchAlLTransactionsBySenderAsync(StringValue request,
        ServerCallContext context)
    {
        return base.FetchAlLTransactionsBySenderAsync(request, context);
    }

    public override Task<TransactionProtoObjList> FetchAllTransactionsByReceiverAsync(StringValue request,
        ServerCallContext context)
    {
        return base.FetchAllTransactionsByReceiverAsync(request, context);
    }

    public override Task<TransactionProtoObjList> FetchAlLTransactionsInvolvingUserAsync(StringValue request,
        ServerCallContext context)
    {
        return base.FetchAlLTransactionsInvolvingUserAsync(request, context);
    }

    public override Task<TransactionProtoObjList> FetchTransactionsByDateAsync(StringValue request,
        ServerCallContext context)
    {
        return base.FetchTransactionsByDateAsync(request, context);
    }

    public override Task<BoolValue> DeleteTransactionAsync(Int64Value request, ServerCallContext context)
    {
        return base.DeleteTransactionAsync(request, context);
    }

    public static TransactionEntity FromProtoToEntity(TransactionProtoObj transactionProtoObj)
    {
        return new TransactionEntity()
        {
            Sender = UserService.FromProtoToEntity(transactionProtoObj.SenderUser),
            Receiver = UserService.FromProtoToEntity(transactionProtoObj.ReceiverUser),
            Amount = transactionProtoObj.Amount,
            Date = transactionProtoObj.Date
        };
    }

    public static TransactionProtoObj FromEntityToProto(TransactionEntity transactionEntity)
    {
        return new TransactionProtoObj()
        {
            SenderUser = UserService.FromEntityToProto(transactionEntity.Sender),
            ReceiverUser = UserService.FromEntityToProto(transactionEntity.Receiver),
            Amount = transactionEntity.Amount,
            Date = transactionEntity.Date
        };
    }
}