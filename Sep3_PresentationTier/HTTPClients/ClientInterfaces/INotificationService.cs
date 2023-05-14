using Domains.Entity;

namespace HTTPClients.ClientInterfaces;

public interface INotificationService
{
    Task<NotificationEntity> CreateNotificationAsync(NotificationEntity notificationEntity);
    Task<ICollection<NotificationEntity>> FetchAllNotificationsByReceiverAsync(string? username);
    // Task MarkNotificationAsReadAsync(NotificationEntity notificationEntity);
    Task<ICollection<NotificationEntity>> MarkAllNotificationsAsReadAsync(List<NotificationEntity>? notificationEntities);
    Task<bool> DeleteNotificationAsync(long notificationId);
}