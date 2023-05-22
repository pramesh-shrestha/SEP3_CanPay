﻿namespace GrpcService.Services;
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
    
    public static BillTransactionEntity? FromProtoToEntity(BillPaymentProtoObj BillPaymentProtoObj)
    {
        BillTransactionEntity BillTransactionEntity = new BillTransactionEntity()
        {
            Payer = UserService.FromProtoToEntity(BillPaymentProtoObj.SenderUser),
            Payee = BillPaymentProtoObj.PayeeName,
            Amount = (int)BillPaymentProtoObj.Amount,
            Date = BillPaymentProtoObj.Date,
            ReferenceNumber = BillPaymentProtoObj.Reference
        };
        if (BillPaymentProtoObj.BillPaymentId != 0)
        {
            BillTransactionEntity.Id = BillPaymentProtoObj.BillPaymentId!.Value;
        }
        return BillTransactionEntity;
    }
    public static BillPaymentProtoObj FromEntityToProto(BillTransactionEntity? billTransactionEntity)
    {
        return new BillPaymentProtoObj()
        {
            BillPaymentId = billTransactionEntity!.Id,
            SenderUser = UserService.FromEntityToProto(billTransactionEntity!.Payer),
            PayeeName = billTransactionEntity.Payee,
            Amount = billTransactionEntity.Amount,
            Date = billTransactionEntity.Date,
            Reference = billTransactionEntity.ReferenceNumber
        };
    }

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

