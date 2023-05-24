namespace GrpcService.Services;
using EFCDataAccess.DAOInterface;
using Entity;
using Entity.Model;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using SEP3_DataTier;


public class BillTransactionService : BillPaymentProtoService.BillPaymentProtoServiceBase 
{
    private readonly IBillTransactionDao billTransactionDao;

    public BillTransactionService(IBillTransactionDao billTransactionDao)
    {
        this.billTransactionDao = billTransactionDao;
    }

    /// <summary>
    /// Creates a bill payment asynchronously.
    /// </summary>
    /// <param name="request">The <see cref="BillPaymentProtoObj"/> object containing the bill payment information.</param>
    /// <param name="context">The server call context.</param>
    /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The task result contains the created <see cref="BillPaymentProtoObj"/>.</returns>
    /// <exception cref="RpcException">Thrown when an error occurs during the bill payment creation process.</exception>
    public override async Task<BillPaymentProtoObj> CreateBillPaymentAsync(BillPaymentProtoObj request,
        ServerCallContext context)
    {
        try
        {
            BillTransactionEntity? billTransactionEntity = FromProtoToEntity(request);
            BillTransactionEntity? createdBillTransaction =
                await billTransactionDao.CreateBillTransactionAsync(billTransactionEntity);

            BillPaymentProtoObj protoObj = FromEntityToProto(createdBillTransaction);
            return protoObj;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new RpcException(new Status(StatusCode.AlreadyExists, e.Message));
        }
    }

    /// <summary>
    /// Fetches a bill payment by ID asynchronously.
    /// </summary>
    /// <param name="request">The <see cref="Int64Value"/> object containing the ID of the bill payment to fetch.</param>
    /// <param name="context">The server call context.</param>
    /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The task result contains the fetched <see cref="BillPaymentProtoObj"/>.</returns>
    /// <exception cref="RpcException">Thrown when an error occurs while fetching the bill payment.</exception>
    public override async Task<BillPaymentProtoObj> FetchBillPaymentByIdAsync(Int64Value request, ServerCallContext context)
    {
        try
        {
            BillTransactionEntity? entity = await billTransactionDao.FetchBillTransactionByIdAsync(request.Value);
            BillPaymentProtoObj protoObj = FromEntityToProto(entity);
            return protoObj;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new RpcException(new Status(StatusCode.NotFound, e.Message));
        }
    }

    /// <summary>
    /// Fetches all bill payments by sender asynchronously.
    /// </summary>
    /// <param name="request">The <see cref="StringValue"/> object containing the sender's name.</param>
    /// <param name="context">The server call context.</param>
    /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The task result contains a list of fetched <see cref="BillPaymentProtoObj"/>.</returns>
    /// <exception cref="RpcException">Thrown when an error occurs while fetching the bill payments.</exception>
    public override async Task<BillPaymentProtoObjList> FetchAllBillPaymentsBySenderAsync(StringValue request,
        ServerCallContext context)
    {
        try
        {
            ICollection<BillTransactionEntity> byPayer =
                await billTransactionDao.FetchAllBillTransactionsByPayerAsync(request.Value);

            BillPaymentProtoObjList transactionsByPayerProtoList = ConvertToProtoList(byPayer);
            return transactionsByPayerProtoList;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new RpcException(new Status(StatusCode.NotFound, e.Message));
        }
    }

    /// <summary>
    /// Fetches all bill payments involving a user asynchronously.
    /// </summary>
    /// <param name="request">The <see cref="StringValue"/> object containing the user's name.</param>
    /// <param name="context">The server call context.</param>
    /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The task result contains a list of fetched <see cref="BillPaymentProtoObj"/>.</returns>
    /// <exception cref="RpcException">Thrown when an error occurs while fetching the bill payments.</exception>
    public override async Task<BillPaymentProtoObjList> FetchAlLBillPaymentsInvolvingUserAsync(StringValue request, ServerCallContext context)
    {
        try
        {
            ICollection<BillTransactionEntity> involvingUser =
                await billTransactionDao.FetchAllBillTransactionsInvolvingUserAsync(request.Value);

            BillPaymentProtoObjList transactionsByUserProtoList = ConvertToProtoList(involvingUser);
            return transactionsByUserProtoList;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new RpcException(new Status(StatusCode.NotFound, e.Message));
        }
    }

    /// <summary>
    /// Fetches bill payments by date asynchronously.
    /// </summary>
    /// <param name="request">The <see cref="StringValue"/> object containing the date for filtering the bill payments.</param>
    /// <param name="context">The server call context.</param>
    /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The task result contains a list of fetched <see cref="BillPaymentProtoObj"/>.</returns>
    /// <exception cref="RpcException">Thrown when an error occurs while fetching the bill payments.</exception>
    public override async Task<BillPaymentProtoObjList> FetchBillPaymentsByDateAsync(StringValue request,
        ServerCallContext context)
    {
        try
        {
            ICollection<BillTransactionEntity> byDate =
                await billTransactionDao.FetchBillTransactionsByDateAsync(request.Value);

            BillPaymentProtoObjList byDateProtoList = ConvertToProtoList(byDate);
            return byDateProtoList;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new RpcException(new Status(StatusCode.NotFound, e.Message));
        }
    }
    
    /// <summary>
    /// Deletes a bill payment asynchronously.
    /// </summary>
    /// <param name="request">The <see cref="Int64Value"/> object containing the ID of the bill payment to delete.</param>
    /// <param name="context">The server call context.</param>
    /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The task result contains a <see cref="BoolValue"/> indicating whether the deletion was successful.</returns>
    /// <exception cref="RpcException">Thrown when an error occurs while deleting the bill payment.</exception>
    public override async Task<BoolValue> DeleteBillPaymentAsync(Int64Value request, ServerCallContext context)
    {
        try
        {
            bool isTransactionDeleted = await billTransactionDao.DeleteBillTransactionAsync(request.Value);
            return new BoolValue { Value = isTransactionDeleted };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new RpcException(new Status(StatusCode.Aborted, e.Message));
        }
    }
    
    /// <summary>
    /// Converts a <see cref="BillPaymentProtoObj"/> to a <see cref="BillTransactionEntity"/>.
    /// </summary>
    /// <param name="BillPaymentProtoObj">The <see cref="BillPaymentProtoObj"/> to convert.</param>
    /// <returns>A <see cref="BillTransactionEntity"/> representing the converted entity object, or null if the conversion fails.</returns>
    public static BillTransactionEntity? FromProtoToEntity(BillPaymentProtoObj BillPaymentProtoObj)
    {
        BillTransactionEntity? BillTransactionEntity = new BillTransactionEntity
        {
            Payer = UserService.FromProtoToEntity(BillPaymentProtoObj.SenderUser),
            Payee = BillPaymentProtoObj.PayeeName,
            Amount = (int)BillPaymentProtoObj.Amount,
            Date = BillPaymentProtoObj.Date,
            ReferenceNumber = BillPaymentProtoObj.Reference,
            AccountNumber = BillPaymentProtoObj.AccountNumber
        };
        if (BillPaymentProtoObj.BillPaymentId != 0)
        {
            BillTransactionEntity.Id = BillPaymentProtoObj.BillPaymentId!.Value;
        }
        return BillTransactionEntity;
    }
    
    /// <summary>
    /// Converts a <see cref="BillTransactionEntity"/> to a <see cref="BillPaymentProtoObj"/>.
    /// </summary>
    /// <param name="billTransactionEntity">The <see cref="BillTransactionEntity"/> to convert.</param>
    /// <returns>A <see cref="BillPaymentProtoObj"/> representing the converted proto object.</returns>
    public static BillPaymentProtoObj FromEntityToProto(BillTransactionEntity? billTransactionEntity)
    {
        BillPaymentProtoObj protoObj=new BillPaymentProtoObj
        {
            BillPaymentId = billTransactionEntity!.Id,
            SenderUser = UserService.FromEntityToProto(billTransactionEntity!.Payer),
            PayeeName = billTransactionEntity.Payee,
            Amount = billTransactionEntity.Amount,
            Date = billTransactionEntity.Date,
            Reference = billTransactionEntity.ReferenceNumber,
            AccountNumber = billTransactionEntity.AccountNumber
        };
        return protoObj;
    }

    /// <summary>
    /// Converts a collection of <see cref="BillTransactionEntity"/> objects to a <see cref="BillPaymentProtoObjList"/>.
    /// </summary>
    /// <param name="billTransactionEntities">The collection of <see cref="BillTransactionEntity"/> to convert.</param>
    /// <returns>A <see cref="BillPaymentProtoObjList"/> representing the converted proto object list.</returns>
    private static BillPaymentProtoObjList ConvertToProtoList(ICollection<BillTransactionEntity> billTransactionEntities)
    {
        BillPaymentProtoObjList  billTransactionProtoObjList = new BillPaymentProtoObjList 
        {
            AllBillPayments =
            {
                billTransactionEntities.Select(entity => 
                {
                    BillPaymentProtoObj protoObj = FromEntityToProto(entity);
                    return protoObj;
                })
            }
        };
        return billTransactionProtoObjList;
    }
}

