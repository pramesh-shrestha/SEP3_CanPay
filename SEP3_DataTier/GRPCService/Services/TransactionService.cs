using EFCDataAccess.DAOInterface;
using Entity;
using Entity.Model;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using SEP3_DataTier;

namespace GrpcService.Services;

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
    /// Fetches a transaction by its ID.
    /// </summary>
    /// <param name="request">The ID of the transaction to fetch.</param>
    /// <param name="context">The ServerCallContext.</param>
    /// <returns>The TransactionProtoObj representing the fetched transaction.</returns>
    public override async Task<TransactionProtoObj> FetchTransactionByIdAsync(Int64Value request,
        ServerCallContext context)
    {
        try
        {
            TransactionEntity? entity = await transactionDao.FetchTransactionByIdAsync(request.Value);
            TransactionProtoObj protoObj = FromEntityToProto(entity);
            // protoObj.TransactionId = entity.Id;

            return protoObj;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new RpcException(new Status(StatusCode.NotFound, e.Message));
        }
    }

    /// <summary>
    /// Fetches all transactions by the sender's username.
    /// </summary>
    /// <param name="request">The username of the sender.</param>
    /// <param name="context">The ServerCallContext.</param>
    /// <returns>The TransactionProtoObjList representing the fetched transactions.</returns>
    public override async Task<TransactionProtoObjList> FetchAlLTransactionsBySenderAsync(StringValue request,
        ServerCallContext context)
    {
        try
        {
            ICollection<TransactionEntity> bySender =
                await transactionDao.FetchAlLTransactionsBySenderAsync(request.Value);

            TransactionProtoObjList transactionsBySenderProtoList = ConvertToProtoList(bySender);
            return transactionsBySenderProtoList;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new RpcException(new Status(StatusCode.NotFound, e.Message));
        }
    }

    /// <summary>
    /// Fetches all transactions by the receiver's username.
    /// </summary>
    /// <param name="request">The username of the receiver.</param>
    /// <param name="context">The ServerCallContext.</param>
    /// <returns>The TransactionProtoObjList representing the fetched transactions.</returns>
    public override async Task<TransactionProtoObjList> FetchAllTransactionsByReceiverAsync(StringValue request,
        ServerCallContext context)
    {
        try
        {
            ICollection<TransactionEntity> byReceiver =
                await transactionDao.FetchAllTransactionsByReceiverAsync(request.Value);

            TransactionProtoObjList transactionsByReceiverProtoList = ConvertToProtoList(byReceiver);
            return transactionsByReceiverProtoList;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new RpcException(new Status(StatusCode.NotFound, e.Message));
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
    /// Fetches transactions by date.
    /// </summary>
    /// <param name="request">The date of the transactions.</param>
    /// <param name="context">The ServerCallContext.</param>
    /// <returns>The TransactionProtoObjList representing the fetched transactions.</returns>
    public override async Task<TransactionProtoObjList> FetchTransactionsByDateAsync(StringValue request,
        ServerCallContext context)
    {
        try
        {
            ICollection<TransactionEntity?> byDate = await transactionDao.FetchTransactionsByDateAsync(request.Value);

            TransactionProtoObjList byDateProtoList = ConvertToProtoList(byDate);
            return byDateProtoList;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new RpcException(new Status(StatusCode.NotFound, e.Message));
        }
    }

    /// <summary>
    /// Fetches transactions by username and date.
    /// </summary>
    /// <param name="request">The filter criteria containing the username and date.</param>
    /// <param name="context">The ServerCallContext.</param>
    /// <returns>The TransactionProtoObjList representing the fetched transactions.</returns>
    public override async Task<TransactionProtoObjList> FetchTransactionsByUsernameAndDate(
        FilterByUserAndDateProtoObj request, ServerCallContext context)
    {
        try
        {
            ICollection<TransactionEntity?> byDateAndUsername =
                await transactionDao.fetchTransactionByUsernameAndDate(ConvertToFilterDto(request));
            TransactionProtoObjList byDateAndReceiveProtoObjList = ConvertToProtoList(byDateAndUsername);
            return byDateAndReceiveProtoObjList;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new RpcException(new Status(StatusCode.NotFound, e.Message));
        }
    }

    /// <summary>
    /// Deletes a transaction by ID.
    /// </summary>
    /// <param name="request">The ID of the transaction to delete.</param>
    /// <param name="context">The ServerCallContext.</param>
    /// <returns>A BoolValue indicating whether the transaction was deleted successfully.</returns>
    public override async Task<BoolValue> DeleteTransactionAsync(Int64Value request, ServerCallContext context)
    {
        try
        {
            bool isTransactionDeleted = await transactionDao.DeleteTransactionAsync(request.Value);
            return new BoolValue { Value = isTransactionDeleted };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new RpcException(new Status(StatusCode.Aborted, e.Message));
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
    /// Converts a FilterByUserAndDateProtoObj to a FilterDto.
    /// </summary>
    /// <param name="protoObj">The FilterByUserAndDateProtoObj to convert.</param>
    /// <returns>The converted FilterDto.</returns>
    public static FilterDto ConvertToFilterDto(FilterByUserAndDateProtoObj protoObj)
    {
        return new FilterDto()
        {
            Username = protoObj.Username,
            Date = protoObj.Date
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