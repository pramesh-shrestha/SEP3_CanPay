using System.Collections;
using EFCDataAccess.DAOInterface;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFCDataAccess.DAOImplementation;

public class NotificationDaoImpl : INotificationDao
{
    private readonly CanPayDbAccess context;

    public NotificationDaoImpl(CanPayDbAccess context)
    {
        this.context = context;
    }

    public async Task<NotificationEntity> CreateNotificationAsync(NotificationEntity notificationEntity)
    {
        try
        {
            EntityEntry<UserEntity> sender = context.Users.Attach(notificationEntity.Sender!);
            EntityEntry<UserEntity> receiver = context.Users.Attach(notificationEntity.Receiver!);

            notificationEntity.Sender = sender.Entity;
            notificationEntity.Receiver = receiver.Entity;

            EntityEntry<NotificationEntity> createdNotification =
                await context.Notifications.AddAsync(notificationEntity);
            await context.SaveChangesAsync();
            return createdNotification.Entity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception(e.Message);
        }
    }

    public async Task<ICollection<NotificationEntity>> FetchAllNotificationsByReceiverAsync(string username)
    {
        try
        {
            ICollection<NotificationEntity> notificationEntities = await context.Notifications
                .Include(entity => entity.Sender).Include(entity => entity.Receiver)
                .Where(e => e.Receiver!.Equals(username)).Where(entity => !entity.IsRead).ToListAsync();
            return notificationEntities;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception(e.Message);
        }
    }

    public async Task MarkNotificationAsReadAsync(NotificationEntity notificationEntity)
    {
        try
        {
            context.Notifications.Update(notificationEntity);
            await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception(e.Message);
        }
    }

    public async Task MarkAllNotificationsAsReadAsync(List<NotificationEntity> notificationEntities)
    {
        try
        {
            context.Notifications.UpdateRange(notificationEntities);
            await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception(e.Message);
        }
    }

    public async Task<bool> DeleteNotificationAsync(long notificationId)
    {
        try
        {
            NotificationEntity? notificationEntity =
                await context.Notifications.FirstOrDefaultAsync(entity => entity.Id == notificationId);
            context.Notifications.Remove(notificationEntity!);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception(e.Message);
        }
    }
}