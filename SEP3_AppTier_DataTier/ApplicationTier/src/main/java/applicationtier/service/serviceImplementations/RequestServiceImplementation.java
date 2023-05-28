package applicationtier.service.serviceImplementations;

import applicationtier.GrpcClient.notification.INotificationClient;
import applicationtier.GrpcClient.request.IRequestClient;
import applicationtier.entity.RequestEntity;
import applicationtier.service.serviceInterfaces.IRequestService;
import org.springframework.stereotype.Service;

@Service
public class RequestServiceImplementation implements IRequestService {

    private IRequestClient requestClient;

    public RequestServiceImplementation(IRequestClient requestClient) {
        this.requestClient = requestClient;
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



}
