package applicationtier.GrpcClient.request;

import applicationtier.GrpcClient.ManagedChannelProvider;
import applicationtier.GrpcClient.user.UserClientImpl;
import applicationtier.entity.RequestEntity;
import applicationtier.protobuf.Request;
import applicationtier.protobuf.RequestProtoServiceGrpc;
import com.google.protobuf.Int64Value;
import io.grpc.ManagedChannel;
import org.springframework.stereotype.Service;

@Service
public class RequestClientImpl implements IRequestClient {

    private RequestProtoServiceGrpc.RequestProtoServiceBlockingStub requestProtoBlockingStub;

    /**
     * Retrieves the RequestProtoServiceBlockingStub instance.
     *
     * @return The RequestProtoServiceBlockingStub instance.
     */
    private RequestProtoServiceGrpc.RequestProtoServiceBlockingStub getRequestBlockingStub() {
        if (requestProtoBlockingStub == null) {
            ManagedChannel channel = ManagedChannelProvider.getChannel();
            requestProtoBlockingStub = RequestProtoServiceGrpc.newBlockingStub(channel);
        }
        return requestProtoBlockingStub;
    }

    /**
     * Creates a new request.
     *
     * @param requestEntity The RequestEntity object representing the request.
     * @return The created RequestEntity object.
     * @throws RuntimeException If an exception occurs during the creation process.
     */
    @Override
    public RequestEntity createRequest(RequestEntity requestEntity) {
        try {
            Request.RequestProtoObj requestProtoObj = fromEntityToProtoObj(requestEntity);
            Request.RequestProtoObj protoObj = getRequestBlockingStub().createRequestAsync(requestProtoObj);

            return fromProtoObjToEntity(protoObj);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    /**
     * Fetches all requests.
     *
     * @return A list of RequestEntity objects representing all the requests.
     * @throws RuntimeException If an exception occurs during the fetch process.
     */
    /*@Override
    public List<RequestEntity> FetchAllRequest() {
        try {
            Request.RequestProtoObjList allRequest = getRequestBlockingStub().fetchAllRequestsAsync(Empty.newBuilder().build());
            List<RequestEntity> requestEntities = new ArrayList<>();

            for (Request.RequestProtoObj requestProtoObj : allRequest.getRequestsList()) {
                RequestEntity request = fromProtoObjToEntity(requestProtoObj);
                requestEntities.add(request);
            }
            return requestEntities;
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }*/

    /**
     * Fetches a request by its ID.
     *
     * @param id The ID of the request to fetch.
     * @return The RequestEntity object representing the fetched request.
     * @throws RuntimeException If an exception occurs during the fetch process.
     */
    @Override
    public RequestEntity FetchRequestById(Long id) {
        try {
            Request.RequestProtoObj requestProtoObj = getRequestBlockingStub().fetchRequestByIdAsync(Int64Value.of(id));
            RequestEntity entity = fromProtoObjToEntity(requestProtoObj);
            return entity;
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    /**
     * Fetches a request by username.
     *
     * @param username The username of the request to fetch.
     * @return The RequestEntity object representing the fetched request.
     * @throws RuntimeException If an exception occurs during the fetch process.
     */
   /* @Override
    public RequestEntity FetchRequestByUsername(String username) {
        try {
            Request.RequestProtoObj requestProtoObj = getRequestBlockingStub().fetchRequestByUsername(StringValue.of(username));
            return fromProtoObjToEntity(requestProtoObj);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }*/

    /**
     * Updates a request.
     *
     * @param requestEntity The RequestEntity object representing the request to update.
     * @return The updated RequestEntity object.
     * @throws RuntimeException If an exception occurs during the update process.
     */
    @Override
    public RequestEntity UpdateRequest(RequestEntity requestEntity) {
        try {
            Request.RequestProtoObj requestProtoObj = getRequestBlockingStub().updateRequestAsync(fromEntityToProtoObj(requestEntity));
            return fromProtoObjToEntity(requestProtoObj);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    /**
     * Deletes a request by its ID.
     *
     * @param id The ID of the request to delete.
     * @return true if the request was successfully deleted, false otherwise.
     * @throws RuntimeException If an exception occurs during the delete process.
     */
    /*@Override
    public boolean DeleteRequest(Long id) {
        try {
            BoolValue requestProtoObj = getRequestBlockingStub().deleteRequestAsync(Int64Value.of(id));
            return requestProtoObj.toBuilder().getValue();
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }*/

    /**
     * Converts a Request.RequestProtoObj object to a RequestEntity object.
     *
     * @param requestProtoObj The Request.RequestProtoObj object to convert.
     * @return The converted RequestEntity object.
     */
    public static RequestEntity fromProtoObjToEntity(Request.RequestProtoObj requestProtoObj) {
        RequestEntity requestEntity = new RequestEntity();
        requestEntity.setAmount(requestProtoObj.getAmount());
        requestEntity.setApproved(requestProtoObj.getIsApproved());
        requestEntity.setComment(requestProtoObj.getComment());
        requestEntity.setRequestReceiver(UserClientImpl.fromProtoObjToEntity(requestProtoObj.getRequestReceiver()));
        requestEntity.setStatus(requestProtoObj.getStatus());
        requestEntity.setRequestSender(UserClientImpl.fromProtoObjToEntity(requestProtoObj.getRequestSender()));
        requestEntity.setRequestedDate(requestProtoObj.getRequestedDate());

        if (requestProtoObj.getRequestId() != 0) {
            requestEntity.setId(requestProtoObj.getRequestId());
        }
        return requestEntity;
    }

    /**
     * Converts a RequestEntity object to a Request.RequestProtoObj object.
     *
     * @param request The RequestEntity object to convert.
     * @return The converted Request.RequestProtoObj object.
     */
    public static Request.RequestProtoObj fromEntityToProtoObj(RequestEntity request) {
        Request.RequestProtoObj.Builder requestBuilder = Request.RequestProtoObj.newBuilder()
                .setAmount(request.getAmount())
                .setComment(request.getComment())
                .setRequestReceiver(UserClientImpl.fromEntityToProtoObj(request.getRequestReceiver()))
                .setRequestSender(UserClientImpl.fromEntityToProtoObj(request.getRequestSender()))
                .setRequestedDate(request.getRequestedDate())
                .setIsApproved(request.isApproved())
                .setStatus(request.getStatus());

        if (request.getId() != 0) {
            requestBuilder.setRequestId(request.getId());
        }

        return requestBuilder.build();
    }
}
