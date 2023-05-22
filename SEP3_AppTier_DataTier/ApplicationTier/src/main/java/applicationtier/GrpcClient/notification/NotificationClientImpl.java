package applicationtier.GrpcClient.notification;

import applicationtier.GrpcClient.ManagedChannelProvider;
import applicationtier.GrpcClient.user.UserClientImpl;
import applicationtier.entity.NotificationEntity;
import applicationtier.protobuf.Notification;
import applicationtier.protobuf.NotificationProtoServiceGrpc;
import com.google.protobuf.BoolValue;
import com.google.protobuf.Empty;
import com.google.protobuf.Int64Value;
import com.google.protobuf.StringValue;
import io.grpc.ManagedChannel;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;

/**
 * Implementation of the INotificationClient interface that communicates with the Notification Proto Service.
 * Manages notifications by converting between entity and proto objects, and invoking corresponding methods
 * of the Notification Proto Service blocking stub.
 */
@Service
public class NotificationClientImpl implements INotificationClient {

    private NotificationProtoServiceGrpc.NotificationProtoServiceBlockingStub notificationBlockingStub;


    /**
     * Retrieves the blocking stub for the Notification Proto Service.
     * If the stub is not initialized, it creates a new instance using the managed channel.
     *
     * @return The Notification Proto Service blocking stub.
     */
    private NotificationProtoServiceGrpc.NotificationProtoServiceBlockingStub getNotificationBlockingStub() {
        if (notificationBlockingStub == null) {
            ManagedChannel channel = ManagedChannelProvider.getChannel();
            notificationBlockingStub = NotificationProtoServiceGrpc.newBlockingStub(channel);
        }
        return notificationBlockingStub;
    }

    /**
     * Creates a new notification by converting the given NotificationEntity object to a NotificationProtoObj,
     * invoking the createNotificationAsync method of the Notification Proto Service blocking stub,
     * and converting the returned NotificationProtoObj back to a NotificationEntity.
     *
     * @param notification The NotificationEntity object representing the notification to create.
     * @return The created NotificationEntity object.
     * @throws RuntimeException if an exception occurs during the creation process.
     */
    @Override
    public NotificationEntity createNotification(NotificationEntity notification) {
        try {

            Notification.NotificationProtoObj notificationProtoObj = fromEntityToProtoObj(notification);

            Notification.NotificationProtoObj protoObj = getNotificationBlockingStub().createNotificationAsync(notificationProtoObj);
            return fromProtoObjToEntity(protoObj);

        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    /**
     * Retrieves a notification by its ID by invoking the fetchNotificationByIdAsync method
     * of the Notification Proto Service blocking stub, and converting the returned
     * NotificationProtoObj to a NotificationEntity.
     *
     * @param id The ID of the notification to fetch.
     * @return The fetched NotificationEntity object.
     * @throws RuntimeException if an exception occurs during the retrieval process.
     */
    @Override
    public NotificationEntity fetchNotificationById(long id) {
        try {
            Notification.NotificationProtoObj notificationProtoObj = getNotificationBlockingStub().
                    fetchNotificationByIdAsync(Int64Value.of(id));
            return fromProtoObjToEntity(notificationProtoObj);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    /**
     * Marks a notification as read by converting the given NotificationEntity object to a NotificationProtoObj
     * and invoking the markAsRead method of the Notification Proto Service blocking stub.
     *
     * @param notification The NotificationEntity object to mark as read.
     * @throws RuntimeException if an exception occurs during the marking process.
     */
    @Override
    public void markAsRead(NotificationEntity notification) {
        try {
            getNotificationBlockingStub().markAsRead(fromEntityToProtoObj(notification));
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }


    /**
     * Marks multiple notifications as read by converting the list of NotificationEntity objects to a
     * NotificationProtoObjList, invoking the markAllAsRead method of the Notification Proto Service blocking stub,
     * and discarding the returned Empty object.
     *
     * @param notifications The list of NotificationEntity objects to mark as read.
     * @throws RuntimeException if an exception occurs during the marking process.
     */
    @Override
    public void markAllAsRead(List<NotificationEntity> notifications) {
        try {
            Notification.NotificationProtoObjList.Builder notificationListBuilder = Notification.NotificationProtoObjList.newBuilder();
            for (NotificationEntity notification : notifications) {
                notificationListBuilder.addAllNotifications(fromEntityToProtoObj(notification));
            }

            Empty empty = getNotificationBlockingStub().markAllAsRead(notificationListBuilder.build());
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }


    /**
     * Fetches all notifications for a given receiver username by invoking the fetchAllNotificationsByReceiverAsync
     * method of the Notification Proto Service blocking stub, and converting the returned list of
     * NotificationProtoObj objects to a list of NotificationEntity objects.
     *
     * @param receiverUsername The username of the receiver to fetch notifications for.
     * @return The list of fetched NotificationEntity objects.
     * @throws RuntimeException if an exception occurs during the retrieval process.
     */
    @Override
    public List<NotificationEntity> fetchAllNotificationsByReceiver(String receiverUsername) {
        try {
            List<Notification.NotificationProtoObj> allNotificationsList = getNotificationBlockingStub().fetchAllNotificationsByReceiverAsync(StringValue.of(receiverUsername)).getAllNotificationsList();
            List<NotificationEntity> notificationEntities = new ArrayList<>();
            for (Notification.NotificationProtoObj notificationProtoObj : allNotificationsList) {
                notificationEntities.add(fromProtoObjToEntity(notificationProtoObj));
            }
            return notificationEntities;
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }


    /**
     * Deletes a notification by its ID by invoking the deleteNotificationAsync method
     * of the Notification Proto Service blocking stub.
     *
     * @param id The ID of the notification to delete.
     * @return true if the deletion is successful, false otherwise.
     * @throws RuntimeException if an exception occurs during the deletion process.
     */
    @Override
    public boolean deleteNotification(Long id) {
        try {
            BoolValue notificationProtoObj = getNotificationBlockingStub().deleteNotificationAsync(Int64Value.of(id));
            return notificationProtoObj.toBuilder().getValue();
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }


    /**
     * Converts a Notification.NotificationProtoObj to a NotificationEntity object.
     *
     * @param notificationProtoObj The Notification.NotificationProtoObj to convert.
     * @return The converted NotificationEntity object.
     */
    public static NotificationEntity fromProtoObjToEntity(Notification.NotificationProtoObj notificationProtoObj) {
        NotificationEntity notification = new NotificationEntity();
        notification.setReceiver(UserClientImpl.fromProtoObjToEntity(notificationProtoObj.getReceiverUser()));
        notification.setSender(UserClientImpl.fromProtoObjToEntity(notificationProtoObj.getSenderUser()));
        notification.setDate(notificationProtoObj.getDate().getValue());
        notification.setMessage(notificationProtoObj.getMessage().getValue());
        notification.setNotificationType(notificationProtoObj.getType().getValue());
        notification.setRead(notificationProtoObj.getIsRead().getValue());
        notification.setId(notificationProtoObj.getNotificationId().getValue());

        return notification;
    }

    /**
     * Converts a NotificationEntity object to a Notification.NotificationProtoObj.
     *
     * @param notification The NotificationEntity object to convert.
     * @return The converted Notification.NotificationProtoObj.
     */
    public static Notification.NotificationProtoObj fromEntityToProtoObj(NotificationEntity notification) {
        Notification.NotificationProtoObj.Builder notificationBuilder = Notification.NotificationProtoObj.newBuilder()
                .setReceiverUser(UserClientImpl.fromEntityToProtoObj(notification.getReceiver()))
                .setSenderUser(UserClientImpl.fromEntityToProtoObj(notification.getSender()))
                .setDate(StringValue.of(notification.getDate()))
                .setMessage(StringValue.of(notification.getMessage()))
                .setType(StringValue.of(notification.getNotificationType()))
                .setIsRead(BoolValue.of(notification.isRead()));

        if (notification.getId() != null || notification.getId() == 0) {
            notificationBuilder.setNotificationId(Int64Value.of(notification.getId()));
        }

        return notificationBuilder.build();
    }
}
