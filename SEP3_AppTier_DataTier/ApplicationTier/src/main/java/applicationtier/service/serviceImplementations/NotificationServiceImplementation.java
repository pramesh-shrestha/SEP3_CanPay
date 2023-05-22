package applicationtier.service.serviceImplementations;

import applicationtier.GrpcClient.notification.INotificationClient;

import applicationtier.entity.NotificationEntity;
import applicationtier.service.serviceInterfaces.INotificationService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class NotificationServiceImplementation implements INotificationService {

    private final INotificationClient notificationClient;

    @Autowired
    public NotificationServiceImplementation(INotificationClient notificationClient) {
        this.notificationClient = notificationClient;
    }

    /**
     * Creates a new notification.
     *
     * @param notification The notification entity to create.
     * @return The created notification entity.
     * @throws RuntimeException If an error occurs during the creation process.
     */
    @Override
    public NotificationEntity createNotification(NotificationEntity notification) {

        try {
            return notificationClient.createNotification(notification);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }


    /**
     * Fetches a notification by its ID.
     *
     * @param id The ID of the notification to fetch.
     * @return The fetched notification entity.
     * @throws RuntimeException If an error occurs during the fetching process.
     */
    @Override
    public NotificationEntity fetchNotificationById(long id) {
        try {
            return notificationClient.fetchNotificationById(id);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }


    /**
     * Fetches all notifications for a given receiver.
     *
     * @param receiverUsername The username of the receiver.
     * @return The list of fetched notification entities.
     * @throws RuntimeException If an error occurs during the fetching process.
     */
    @Override
    public List<NotificationEntity> fetchAllNotificationsByReceiver(String receiverUsername) {
        try {
            //            markAllAsRead(entities);
            return notificationClient.fetchAllNotificationsByReceiver(receiverUsername);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }

    /**
     * Marks a notification as read.
     *
     * @param notification The notification entity to mark as read.
     * @throws RuntimeException If an error occurs during the marking process.
     */
    @Override
    public void markAsRead(NotificationEntity notification) {
        try {
            notification.setRead(true);
            notificationClient.markAsRead(notification);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }


    /**
     * Marks multiple notifications as read.
     *
     * @param notificationList The list of notification entities to mark as read.
     * @throws RuntimeException If an error occurs during the marking process.
     */
    @Override
    public void markAllAsRead(List<NotificationEntity> notificationList) {
        try {

            notificationClient.markAllAsRead(notificationList);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }


    /**
     * Deletes a notification by its ID.
     *
     * @param id The ID of the notification to delete.
     * @return True if the deletion is successful, false otherwise.
     * @throws RuntimeException If an error occurs during the deletion process.
     */
    /*@Override
    public boolean deleteNotification(Long id) {
        try {
            return notificationClient.deleteNotification(id);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }
*/

}
