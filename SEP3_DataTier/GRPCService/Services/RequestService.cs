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

    /// <summary>
    /// Creates a new request based on the provided request data.
    /// </summary>
    /// <param name="request">The request data to create the request from.</param>
    /// <param name="context">The server call context.</param>
    /// <returns>The created request as a RequestProtoObj.</returns>
    /// <exception cref="RpcException">Thrown when the request already exists.</exception>
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


    /// <summary>
    /// Fetches a request by its ID.
    /// </summary>
    /// <param name="request">The ID of the request.</param>
    /// <param name="context">The server call context.</param>
    /// <returns>The requested request as a RequestProtoObj.</returns>
    /// <exception cref="RpcException">Thrown when the requested request is not found.</exception>
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



    /// <summary>
    /// Updates a request.
    /// </summary>
    /// <param name="request">The request to be updated.</param>
    /// <param name="context">The server call context.</param>
    /// <returns>The updated request as a RequestProtoObj.</returns>
    public override async Task<RequestProtoObj> UpdateRequestAsync(RequestProtoObj request, ServerCallContext context)
    {
        RequestEntity? requestEntity = FromProtoToRequestEntity(request);
        RequestEntity? toUpdateRequest = await requestDao.UpdateRequest(requestEntity);
        RequestProtoObj requestProtoObj = FromRequestEntityToProto(toUpdateRequest);
        requestProtoObj.RequestId = toUpdateRequest.Id;
        return requestProtoObj;
    }

    /// <summary>
    /// Converts a RequestProtoObj to a RequestEntity.
    /// </summary>
    /// <param name="requestProtoObj">The RequestProtoObj to be converted.</param>
    /// <returns>The converted RequestEntity.</returns>
    public static RequestEntity FromProtoToRequestEntity(RequestProtoObj requestProtoObj)
    {
        RequestEntity requestEntity = new RequestEntity()
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

    /// <summary>
    /// Converts a RequestEntity to a RequestProtoObj.
    /// </summary>
    /// <param name="requestEntity">The RequestEntity to be converted.</param>
    /// <returns>The converted RequestProtoObj.</returns>
    public static RequestProtoObj FromRequestEntityToProto(RequestEntity requestEntity)

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