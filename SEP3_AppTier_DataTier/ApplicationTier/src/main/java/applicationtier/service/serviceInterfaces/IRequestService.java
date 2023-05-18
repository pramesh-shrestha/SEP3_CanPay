package applicationtier.service.serviceInterfaces;

import applicationtier.entity.RequestEntity;

import java.util.List;

public interface IRequestService {

    RequestEntity createRequest(RequestEntity requestEntity);
    List<RequestEntity> fetchAllRequest();
    RequestEntity fetchRequestById(Long id);
    RequestEntity fetchRequestByUsername(String username);
    RequestEntity updateRequest(RequestEntity requestEntity);
    boolean deleteRequest(Long id);
}
