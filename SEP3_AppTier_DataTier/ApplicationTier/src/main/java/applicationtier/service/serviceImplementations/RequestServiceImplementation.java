package applicationtier.service.serviceImplementations;

import applicationtier.GrpcClient.notification.INotificationClient;
import applicationtier.GrpcClient.request.IRequestClient;
import applicationtier.entity.NotificationEntity;
import applicationtier.entity.RequestEntity;
import applicationtier.service.serviceInterfaces.IRequestService;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class RequestServiceImplementation implements IRequestService {

    private IRequestClient requestClient;
    private INotificationClient notificationClient;

    public RequestServiceImplementation(IRequestClient requestClient, INotificationClient notificationClient) {
        this.requestClient = requestClient;
        this.notificationClient = notificationClient;
    }

    @Override
    public RequestEntity createRequest(RequestEntity requestEntity) {
        try {
            return requestClient.createRequest(requestEntity);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    @Override
    public List<RequestEntity> fetchAllRequest() {
        try {
            return requestClient.FetchAllRequest();
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }

    @Override
    public RequestEntity fetchRequestById(Long id) {
        try {
            return requestClient.FetchRequestById(id);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }

    @Override
    public RequestEntity fetchRequestByUsername(String username) {
        try {
            return requestClient.FetchRequestByUsername(username);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }

    @Override
    public RequestEntity updateRequest(RequestEntity requestEntity) {
        try {
            return requestClient.UpdateRequest(requestEntity);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }

    @Override
    public boolean deleteRequest(Long id) {
        try {
            return requestClient.DeleteRequest(id);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }
}
