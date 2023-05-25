package applicationtier.service.serviceImplementations;

import applicationtier.GrpcClient.notification.INotificationClient;
import applicationtier.GrpcClient.request.IRequestClient;
import applicationtier.entity.NotificationEntity;
import applicationtier.entity.RequestEntity;
import applicationtier.service.serviceInterfaces.IRequestService;
import org.springframework.stereotype.Service;

@Service
public class RequestServiceImplementation implements IRequestService {

    private IRequestClient requestClient;
    private INotificationClient notificationClient;

    public RequestServiceImplementation(IRequestClient requestClient, INotificationClient notificationClient) {
        this.requestClient = requestClient;
        this.notificationClient = notificationClient;
    }

    /**
     * Creates a new request.
     *
     * @param requestEntity The request entity to create.
     * @return The created request entity.
     * @throws RuntimeException If an error occurs during the creation process.
     */
    @Override
    public RequestEntity createRequest(RequestEntity requestEntity) {
        try {
            return requestClient.createRequest(requestEntity);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    /**
     * Fetches all requests.
     *
     * @return The list of fetched request entities.
     * @throws RuntimeException If an error occurs during the fetching process.
     */
    /*@Override
    public List<RequestEntity> fetchAllRequest() {
        try {
            return requestClient.FetchAllRequest();
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }*/

    /**
     * Fetches a request by its ID.
     *
     * @param id The ID of the request to fetch.
     * @return The fetched request entity.
     * @throws RuntimeException If an error occurs during the fetching process.
     */
    @Override
    public RequestEntity fetchRequestById(Long id) {
        try {
            return requestClient.FetchRequestById(id);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }


    /**
     * Fetches a request by the username associated with it.
     *
     * @param username The username associated with the request.
     * @return The fetched request entity.
     * @throws RuntimeException If an error occurs during the fetching process.
     */
   /* @Override
    public RequestEntity fetchRequestByUsername(String username) {
        try {
            return requestClient.FetchRequestByUsername(username);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }*/

    /**
     * Updates a request.
     *
     * @param requestEntity The updated request entity.
     * @return The updated request entity.
     * @throws RuntimeException If an error occurs during the update process.
     */
    @Override
    public RequestEntity updateRequest(RequestEntity requestEntity) {
        try {
            return requestClient.UpdateRequest(requestEntity);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }

    /**
     * Deletes a request by its ID.
     *
     * @param id The ID of the request to delete.
     * @return True if the deletion is successful, false otherwise.
     * @throws RuntimeException If an error occurs during the deletion process.
     */
    /*@Override
    public boolean deleteRequest(Long id) {
        try {
            return requestClient.DeleteRequest(id);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }*/


}
