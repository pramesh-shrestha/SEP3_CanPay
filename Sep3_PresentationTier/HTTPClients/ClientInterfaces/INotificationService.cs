using Domains.Entity;

namespace HTTPClients.ClientInterfaces;

public interface INotificationService
{
    Task<NotificationEntity> CreateNotificationAsync(NotificationEntity notificationEntity);

    Task<ICollection<NotificationEntity>> FetchAllNotificationsByReceiverAsync(string? username);
    Task<NotificationEntity> FetchNotificationById(long id);

    Task MarkNotificationAsReadAsync(NotificationEntity? notificationEntity);
    Task MarkAllNotificationsAsReadAsync(List<NotificationEntity>? notificationEntities);
}