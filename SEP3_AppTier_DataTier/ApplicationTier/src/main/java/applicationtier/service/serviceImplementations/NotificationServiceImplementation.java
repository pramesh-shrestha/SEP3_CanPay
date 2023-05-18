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

    @Override
    public NotificationEntity createNotification(NotificationEntity notification) {

        try {
            return notificationClient.createNotification(notification);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    @Override
    public NotificationEntity fetchNotificationById(long id) {
        try {
            return notificationClient.fetchNotificationById(id);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }


    @Override
    public List<NotificationEntity> fetchAllNotificationsByReceiver(String receiverUsername) {
        try {
            //            markAllAsRead(entities);
            return notificationClient.fetchAllNotificationsByReceiver(receiverUsername);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }

    @Override
    public void markAsRead(NotificationEntity notification) {
        try {
            notification.setRead(true);
            notificationClient.markAsRead(notification);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }


    @Override
    public void markAllAsRead(List<NotificationEntity> notificationList) {
        try {

            notificationClient.markAllAsRead(notificationList);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }


    @Override
    public boolean deleteNotification(Long id) {
        try {
            return notificationClient.deleteNotification(id);
        } catch (Exception e) {
            throw new RuntimeException(e.getMessage());
        }
    }


}
