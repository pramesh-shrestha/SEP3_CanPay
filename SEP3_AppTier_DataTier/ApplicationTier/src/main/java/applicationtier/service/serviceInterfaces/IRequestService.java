package applicationtier.service.serviceInterfaces;

import applicationtier.entity.RequestEntity;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public interface IRequestService {

    RequestEntity createRequest(RequestEntity requestEntity);
    List<RequestEntity> FetchAllRequest();
    RequestEntity FetchRequestById(Long id);
    RequestEntity FetchRequestByUsername(String username);
    RequestEntity UpdateRequest(RequestEntity requestEntity);
    boolean DeleteRequest(Long id);
}
