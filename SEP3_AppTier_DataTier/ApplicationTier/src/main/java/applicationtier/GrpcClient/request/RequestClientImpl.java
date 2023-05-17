package applicationtier.GrpcClient.request;

import applicationtier.GrpcClient.ManagedChannelProvider;
import applicationtier.GrpcClient.user.UserClientImpl;
import applicationtier.entity.RequestEntity;
import applicationtier.protobuf.Request;
import applicationtier.protobuf.RequestProtoServiceGrpc;
import com.google.protobuf.BoolValue;
import com.google.protobuf.Empty;
import com.google.protobuf.Int64Value;
import com.google.protobuf.StringValue;
import io.grpc.ManagedChannel;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;

@Service
public class RequestClientImpl implements IRequestClient{

    private RequestProtoServiceGrpc.RequestProtoServiceBlockingStub requestProtoBlockingStub;

    private RequestProtoServiceGrpc.RequestProtoServiceBlockingStub getRequestBlockingStub() {
        if (requestProtoBlockingStub == null) {
            ManagedChannel channel = ManagedChannelProvider.getChannel();
            requestProtoBlockingStub = RequestProtoServiceGrpc.newBlockingStub(channel);
        }
        return requestProtoBlockingStub;
    }
    @Override
    public RequestEntity createRequest(RequestEntity requestEntity) {
        try {
            Request.RequestProtoObj requestProtoObj= fromEntityToProtoObj(requestEntity);

            Request.RequestProtoObj protoObj=getRequestBlockingStub().createRequestAsync(requestProtoObj);
            return fromProtoObjToEntity(protoObj);
        }catch (Exception e){
            throw new RuntimeException(e);
        }
    }

    @Override
    public List<RequestEntity> FetchAllRequest() {
        try {
            Request.RequestProtoObjList allRequest=getRequestBlockingStub().fetchAllRequestsAsync(Empty.newBuilder().build());
            List<RequestEntity> requestEntities=new ArrayList<>();

            for (Request.RequestProtoObj requestProtoObj : allRequest.getRequestsList()) {
                RequestEntity request=fromProtoObjToEntity(requestProtoObj);
                requestEntities.add(request);
            }
            return requestEntities;
        }catch (Exception e){
            throw new RuntimeException(e);
        }
    }

    @Override
    public RequestEntity FetchRequestById(Long id) {
        try {
            Request.RequestProtoObj requestProtoObj=getRequestBlockingStub().fetchRequestByIdAsync(Int64Value.of(id));
            return fromProtoObjToEntity(requestProtoObj);
        }catch (Exception e){
            throw new RuntimeException(e);
        }
    }

    @Override
    public RequestEntity FetchRequestByUsername(String username) {
        try {
            Request.RequestProtoObj requestProtoObj= getRequestBlockingStub().fetchRequestByUsername(StringValue.of(username));
            return fromProtoObjToEntity(requestProtoObj);
        }catch (Exception e){
            throw new RuntimeException(e);
        }
    }

    @Override
    public RequestEntity UpdateRequest(RequestEntity requestEntity) {
        try {
            Request.RequestProtoObj requestProtoObj=getRequestBlockingStub().updateRequestAsync(fromEntityToProtoObj(requestEntity));
            return fromProtoObjToEntity(requestProtoObj);
        }catch (Exception e){
            throw new RuntimeException(e);
        }
    }

    @Override
    public boolean DeleteRequest(Long id) {
        try {
            BoolValue requestProtoObj= getRequestBlockingStub().deleteRequestAsync(Int64Value.of(id));
            return requestProtoObj.toBuilder().getValue();
        }catch (Exception e){
            throw new RuntimeException(e);
        }
    }

    //from entity to proto
    public static RequestEntity fromProtoObjToEntity(Request.RequestProtoObj requestProtoObj){
        RequestEntity requestEntity= new RequestEntity();
        requestEntity.setAmount(requestProtoObj.getAmount());
        requestEntity.setApproved(requestProtoObj.getIsApproved());
        requestEntity.setComment(requestProtoObj.getComment());
        requestEntity.setRequestReceiver(UserClientImpl.fromProtoObjToEntity(requestProtoObj.getRequestReceiver()));
        requestEntity.setStatus(requestProtoObj.getStatus());
        return requestEntity;
    }

    //from entity to proto
    public static Request.RequestProtoObj fromEntityToProtoObj(RequestEntity request){
        Request.RequestProtoObj.Builder requestBuilder=Request.RequestProtoObj.newBuilder()
                .setRequestId(request.getId())
                .setAmount(request.getAmount())
                .setComment(request.getComment())
                .setRequestReceiver(UserClientImpl.fromEntityToProtoObj(request.getRequestReceiver()))
                .setIsApproved(request.isApproved());
        return requestBuilder.build();
    }
}
