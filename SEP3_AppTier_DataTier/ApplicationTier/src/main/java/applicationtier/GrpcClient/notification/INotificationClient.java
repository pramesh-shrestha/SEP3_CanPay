package applicationtier.GrpcClient.notification;

import applicationtier.entity.NotificationEntity;

import java.util.List;

public interface INotificationClient {
    NotificationEntity createNotification(NotificationEntity notification);

    List<NotificationEntity> fetchAllNotificationsByReceiver(String receiverUsername);
    void markAsRead(NotificationEntity notification);
    void markAllAsRead(List<NotificationEntity> notifications);
//    boolean deleteNotification(Long id);

    NotificationEntity fetchNotificationById(long id);
}
