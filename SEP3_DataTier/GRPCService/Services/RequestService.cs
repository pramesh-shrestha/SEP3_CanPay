using EFCDataAccess.DAOInterface;
using Entity.Model;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using SEP3_DataTier;

namespace GrpcService.Services;

public class RequestService : RequestProtoService.RequestProtoServiceBase
{
    private readonly IRequestDao requestDao;

    public RequestService(IRequestDao requestDao)
    {
        this.requestDao = requestDao;
    }

    public override async Task<RequestProtoObj> CreateRequestAsync(RequestProtoObj request, ServerCallContext context)
    {
        try
        {
            RequestEntity? requestEntity = FromProtoToRequestEntity(request);
            RequestEntity? addedRequest = await requestDao.CreateRequestAsync(requestEntity);
            RequestProtoObj requestProtoObj = FromRequestEntityToProto(addedRequest);

            return requestProtoObj;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new RpcException(new Status(StatusCode.AlreadyExists, e.Message));
        }
    }

    public override async Task<RequestProtoObjList> FetchAllRequestsAsync(Empty request, ServerCallContext context)
    {
        try
        {
            ICollection<RequestEntity?> allRequests = await requestDao.FetchAllRequestsAsync();
            RequestProtoObjList requestProtoObjList = new RequestProtoObjList();

            foreach (RequestEntity? requestEntity in allRequests)
            {
                RequestProtoObj requestProtoObj = FromRequestEntityToProto(requestEntity);
                requestProtoObjList.Requests.Add(requestProtoObj);
            }

            return requestProtoObjList;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new RpcException(new Status(StatusCode.AlreadyExists, e.Message));
        }
    }

    public override async Task<RequestProtoObj> FetchRequestByIdAsync(Int64Value request, ServerCallContext context)
    {
        try
        {
            RequestEntity? requestEntity = await requestDao.FetchRequestByIdAsync(request.Value);
            RequestProtoObj requestProtoObj = FromRequestEntityToProto(requestEntity);
            return requestProtoObj;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new RpcException(new Status(StatusCode.NotFound, e.Message));
        }
    }

    public override async Task<RequestProtoObj> FetchRequestByUsername(StringValue request, ServerCallContext context)
    {
        try
        {
            RequestEntity? requestEntity = await requestDao.FetchRequestByUsernameAsync(request.Value);
            RequestProtoObj requestProtoObj = FromRequestEntityToProto(requestEntity);
            return requestProtoObj;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new RpcException(new Status(StatusCode.NotFound, e.Message));
        }
    }

    public override async Task<RequestProtoObj> UpdateRequestAsync(RequestProtoObj request, ServerCallContext context)
    {
        RequestEntity? requestEntity = FromProtoToRequestEntity(request);
        RequestEntity? toUpdateRequest = await requestDao.UpdateRequest(requestEntity);
        RequestProtoObj requestProtoObj = FromRequestEntityToProto(toUpdateRequest);
        requestProtoObj.RequestId = toUpdateRequest.Id;
        return requestProtoObj;
    }

    public override async Task<BoolValue> DeleteRequestAsync(Int64Value request, ServerCallContext context)
    {
        try
        {
            await requestDao.DeleteRequest(request.Value);
            return new BoolValue { Value = true };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new RpcException(new Status(StatusCode.NotFound, e.Message));
        }
    }

    public static RequestEntity? FromProtoToRequestEntity(RequestProtoObj requestProtoObj)
    {
        RequestEntity? requestEntity = new RequestEntity()
        {
            IsApproved = requestProtoObj.IsApproved,
            Status = requestProtoObj.Status,
            Amount = requestProtoObj.Amount,
            Comment = requestProtoObj.Comment,
            RequestReceiver = UserService.FromProtoToEntity(requestProtoObj.RequestReceiver),
            RequestSender = UserService.FromProtoToEntity(requestProtoObj.RequestSender),
            RequestedDate = requestProtoObj.RequestedDate
        };

        if (requestProtoObj.RequestId != 0)
        {
            requestEntity.Id = requestProtoObj.RequestId;
        }

        return requestEntity;
    }

    public static RequestProtoObj FromRequestEntityToProto(RequestEntity? requestEntity)
    {
        RequestProtoObj protoObj = new RequestProtoObj()
        {
            IsApproved = requestEntity.IsApproved,
            Status = requestEntity.Status,
            Amount = requestEntity.Amount,
            Comment = requestEntity.Comment,
            RequestReceiver = UserService.FromEntityToProto(requestEntity.RequestReceiver),
            RequestSender = UserService.FromEntityToProto(requestEntity.RequestSender),
            RequestedDate = requestEntity.RequestedDate
        };

        if (requestEntity.Id != 0)
        {
            protoObj.RequestId = requestEntity.Id;
        }

        return protoObj;
    }
}