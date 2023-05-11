package applicationtier.service.serviceInterfaces;

import applicationtier.entity.NotificationEntity;

import java.util.List;

public interface INotificationService {
    NotificationEntity createNotification(NotificationEntity notification);
    List<NotificationEntity> fetchAllNotificationsByReceiver(String receiverUsername);
    void markAsRead(NotificationEntity notification);

    void markAllAsRead(List<NotificationEntity> notifications);

    boolean deleteNotification(Long id);

//    void markAllAsRead(String receivingUsername);
}
