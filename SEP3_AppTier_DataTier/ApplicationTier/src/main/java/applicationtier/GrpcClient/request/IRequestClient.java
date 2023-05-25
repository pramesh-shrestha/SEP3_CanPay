package applicationtier.GrpcClient.request;

import applicationtier.entity.RequestEntity;

public interface IRequestClient {

    RequestEntity createRequest(RequestEntity requestEntity);
//    List<RequestEntity> FetchAllRequest();
    RequestEntity FetchRequestById(Long id);
//    RequestEntity FetchRequestByUsername(String username);
    RequestEntity UpdateRequest(RequestEntity requestEntity);
//    boolean DeleteRequest(Long id);

}
