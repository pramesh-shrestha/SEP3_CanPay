package applicationtier.service.serviceImplementations;

import applicationtier.GrpcClient.notification.INotificationClient;

import applicationtier.GrpcClient.transaction.ITransactionClient;
import applicationtier.entity.NotificationEntity;
import applicationtier.entity.TransactionEntity;
import applicationtier.entity.UserEntity;
import applicationtier.service.serviceInterfaces.INotificationService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
@Service
public class NotificationServiceImplementation implements INotificationService {

    private INotificationClient notificationClient;
    private ITransactionClient transactionClient;

    @Autowired
    public NotificationServiceImplementation(INotificationClient notificationClient, ITransactionClient transactionClient) {
        this.notificationClient = notificationClient;
        this.transactionClient = transactionClient;
    }

    @Override
    public NotificationEntity createNotification(NotificationEntity notification) {

        try{
            TransactionEntity transaction = transactionClient.fetchTransactionById(notification.getId());

            if(transaction == null){
                throw new Exception("Transaction not found");
            }

            UserEntity receiver = transaction.getReceiver();

            NotificationEntity newNotification = new NotificationEntity();
            newNotification.setReceiver(receiver);
            newNotification.setId(transaction.getId());
            newNotification.setDate(transaction.getDate());
            newNotification.setMessage("You received a payment from " + transaction.getSender().getUsername());
            //newNotification.setType();
            newNotification.setRead(false);

            return notificationClient.createNotification(newNotification);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }


    @Override
    public List<NotificationEntity> fetchAllNotificationsByReceiver(String receiverUsername) {
        try {
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
    public void markAllAsRead(String receivingUsername) {
        try {
            List<NotificationEntity> notificationList = fetchAllNotificationsByReceiver(receivingUsername);
            for (NotificationEntity notification : notificationList) {
                notification.setRead(true);
                notificationList.add(notification);
            }
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
