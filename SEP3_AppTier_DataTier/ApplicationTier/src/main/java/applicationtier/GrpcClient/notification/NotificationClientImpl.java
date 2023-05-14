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

@Service
public class NotificationClientImpl implements INotificationClient {

    private NotificationProtoServiceGrpc.NotificationProtoServiceBlockingStub notificationBlockingStub;

    private NotificationProtoServiceGrpc.NotificationProtoServiceBlockingStub getNotificationBlockingStub() {
        if (notificationBlockingStub == null) {
            ManagedChannel channel = ManagedChannelProvider.getChannel();
            notificationBlockingStub = NotificationProtoServiceGrpc.newBlockingStub(channel);
        }
        return notificationBlockingStub;
    }

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

    @Override
    public void markAsRead(NotificationEntity notification) {
        try {
            getNotificationBlockingStub().markAsRead(fromEntityToProtoObj(notification));
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

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


    @Override
    public boolean deleteNotification(Long id) {
        try {
            BoolValue notificationProtoObj = getNotificationBlockingStub().deleteNotificationAsync(Int64Value.of(id));
            return notificationProtoObj.toBuilder().getValue();
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    //from proto to entity
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

    //from entity to proto
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
