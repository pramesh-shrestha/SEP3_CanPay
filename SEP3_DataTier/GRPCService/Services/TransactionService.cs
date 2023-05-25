namespace GrpcService.Services;
using EFCDataAccess.DAOInterface;
using Entity;
using Entity.Model;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using SEP3_DataTier;


public class TransactionService : TransactionProtoService.TransactionProtoServiceBase
{
    private readonly ITransactionDao transactionDao;

    public TransactionService(ITransactionDao transactionDao)
    {
        this.transactionDao = transactionDao;
    }

    /// <summary>
    /// Creates a new transaction based on the provided TransactionProtoObj.
    /// </summary>
    /// <param name="request">The TransactionProtoObj containing the transaction details.</param>
    /// <param name="context">The ServerCallContext.</param>
    /// <returns>The created TransactionProtoObj.</returns>
    public override async Task<TransactionProtoObj> CreateTransactionAsync(TransactionProtoObj request,
        ServerCallContext context)
    {
        try
        {
            TransactionEntity? transactionEntity = FromProtoToEntity(request);
            TransactionEntity? createdTransaction =
                await transactionDao.CreateTransactionAsync(transactionEntity);

            TransactionProtoObj protoObj = FromEntityToProto(createdTransaction);
            return protoObj;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new RpcException(new Status(StatusCode.AlreadyExists, e.Message));
        }
    }

    /// <summary>
    /// Fetches all transactions involving a user.
    /// </summary>
    /// <param name="request">The username of the user.</param>
    /// <param name="context">The ServerCallContext.</param>
    /// <returns>The TransactionProtoObjList representing the fetched transactions.</returns>
    public override async Task<TransactionProtoObjList> FetchAlLTransactionsInvolvingUserAsync(StringValue request,
        ServerCallContext context)
    {
        try
        {
            ICollection<TransactionEntity> involvingUser =
                await transactionDao.FetchAlLTransactionsInvolvingUserAsync(request.Value);

            TransactionProtoObjList transactionsByUserProtoList = ConvertToProtoList(involvingUser!);
            return transactionsByUserProtoList;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new RpcException(new Status(StatusCode.NotFound, e.Message));
        }
    }

    /// <summary>
    /// Converts a TransactionProtoObj to a TransactionEntity.
    /// </summary>
    /// <param name="transactionProtoObj">The TransactionProtoObj to convert.</param>
    /// <returns>The converted TransactionEntity.</returns>
    public static TransactionEntity? FromProtoToEntity(TransactionProtoObj transactionProtoObj)
    {
        TransactionEntity transactionEntity = new TransactionEntity()
        {
            Sender = UserService.FromProtoToEntity(transactionProtoObj.SenderUser),
            Receiver = UserService.FromProtoToEntity(transactionProtoObj.ReceiverUser),
            Amount = transactionProtoObj.Amount,
            Date = transactionProtoObj.Date,
            Comment = transactionProtoObj.Comment
        };

        if (transactionProtoObj.TransactionId != 0)
        {
            transactionEntity.Id = transactionProtoObj.TransactionId!.Value;
        }

        return transactionEntity;
    }

    /// <summary>
    /// Converts a TransactionEntity to a TransactionProtoObj.
    /// </summary>
    /// <param name="transactionEntity">The TransactionEntity to convert.</param>
    /// <returns>The converted TransactionProtoObj.</returns>
    public static TransactionProtoObj FromEntityToProto(TransactionEntity? transactionEntity)
    {
        return new TransactionProtoObj()
        {
            TransactionId = transactionEntity!.Id,
            SenderUser = UserService.FromEntityToProto(transactionEntity!.Sender),
            ReceiverUser = UserService.FromEntityToProto(transactionEntity.Receiver),
            Amount = transactionEntity.Amount,
            Date = transactionEntity.Date,
            Comment = transactionEntity.Comment
        };
    }
    
    /// <summary>
    /// Converts a collection of TransactionEntity objects to a TransactionProtoObjList.
    /// </summary>
    /// <param name="transactionEntities">The collection of TransactionEntity objects to convert.</param>
    /// <returns>The converted TransactionProtoObjList.</returns>

    private static TransactionProtoObjList ConvertToProtoList(ICollection<TransactionEntity> transactionEntities)
    {
        TransactionProtoObjList transactionProtoObjList = new TransactionProtoObjList
        {
            AllTransactions =
            {
                transactionEntities.Select(entity =>
                {
                    TransactionProtoObj protoObj = FromEntityToProto(entity);
                    return protoObj;
                })
            }
        };
        return transactionProtoObjList;
    }
}