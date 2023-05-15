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
            // Attach the sender and receiver entities to the context if they are not already attached
            if (!context.Users.Local.Contains(notificationEntity.Sender))
            {
                context.Users.Attach(notificationEntity.Sender);
                context.Cards.Attach(notificationEntity.Sender!.Card);
            }

            if (!context.Users.Local.Contains(notificationEntity.Receiver))
            {
                context.Users.Attach(notificationEntity.Receiver);
                context.Cards.Attach(notificationEntity.Receiver!.Card);
            }


            EntityEntry<NotificationEntity> createdNotification =
                await context.Notifications.AddAsync(notificationEntity);
            await context.SaveChangesAsync();
            return createdNotification.Entity;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<ICollection<NotificationEntity>> FetchAllNotificationsByReceiverAsync(string username)
    {
        try
        {
            ICollection<NotificationEntity> notificationEntities = await context.Notifications
                .Include(entity => entity.Sender).Include(entity => entity.Receiver)
                .Where(e => e.Receiver!.Username!.Equals(username)).Where(entity => !entity.IsRead).ToListAsync();


            /*if (notificationEntities.Count != 0)
            {
                foreach (NotificationEntity notificationEntity in notificationEntities)
                {
                    notificationEntity.IsRead = true;
                }

                await context.SaveChangesAsync();
            }*/

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
        /*try
        {
            context.Notifications.Update(notificationEntity);
            await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception(e.Message);
        }*/
    }

    public async Task MarkAllNotificationsAsReadAsync(List<NotificationEntity> notificationEntities)
    {
        try
        {
            Console.WriteLine(notificationEntities.Count);
            /*if (notificationEntities.Count != 0)
            {
                foreach (NotificationEntity notificationEntity in notificationEntities)
                {
                    notificationEntity.IsRead = true;
                    context.Notifications.Update(notificationEntity);
                    
                }
            }*/
            if (notificationEntities.Count != 0)
            {
                var existingEntities = await context.Notifications
                    .Where(n => notificationEntities.Select(ne => ne.Id).Contains(n.Id))
                    .ToListAsync();

                foreach (var existingEntity in existingEntities)
                {
                    existingEntity.IsRead = true;
                    Console.WriteLine($"Notification Dao Impl: {existingEntity.Id}  {existingEntity.IsRead}");
                }
            }

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