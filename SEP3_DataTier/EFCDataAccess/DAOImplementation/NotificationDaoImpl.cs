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

    /**
        Creates a notification asynchronously.
        @param notificationEntity The NotificationEntity object representing the notification to be created.
        @return A Task representing the asynchronous operation. 
        The task result contains the created NotificationEntity object, or null if no notification was created.
        @throws Exception If an error occurs during the creation process.
    */
    public async Task<NotificationEntity?> CreateNotificationAsync(NotificationEntity? notificationEntity)
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


            EntityEntry<NotificationEntity?> createdNotification =
                await context.Notifications.AddAsync(notificationEntity);
            await context.SaveChangesAsync();
            return createdNotification.Entity;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    /**
        Fetches a notification asynchronously based on the provided notification ID.
        @param requestValue The ID of the notification to be fetched.
        @return A Task representing the asynchronous operation. The task result contains the fetched NotificationEntity object, or null if no notification was found.
        @throws Exception If an error occurs during the fetch operation.
    */
    
    public async Task<NotificationEntity?> FetchNotificationByIdAsync(long requestValue)
    {
        try
        {
            NotificationEntity? notificationEntity =
                await context.Notifications.Include(entity => entity.Sender)
                    .Include(entity => entity.Receiver)
                    .FirstOrDefaultAsync(entity => entity.Id == requestValue);
            return notificationEntity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception(e.Message);
        }
    }

    /**
        Fetches a notification asynchronously based on the provided notification ID.
        @param requestValue The ID of the notification to be fetched.
        @return A Task representing the asynchronous operation. The task result contains the fetched NotificationEntity object, or null if no notification was found.
        @throws Exception If an error occurs during the fetch operation.
    */
    public async Task<ICollection<NotificationEntity?>> FetchAllNotificationsByReceiverAsync(string username)
    {
        try
        {
            ICollection<NotificationEntity?> notificationEntities = await context.Notifications
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

    public async Task MarkNotificationAsReadAsync(NotificationEntity? notificationEntity)
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

    /**
    Marks all notifications in the provided list as read asynchronously.
    @param notificationEntities A list of NotificationEntity objects representing the notifications to be marked as read.
    @return A Task representing the asynchronous operation.
    @throws Exception If an error occurs during the marking process.
*/
    
    public async Task MarkAllNotificationsAsReadAsync(List<NotificationEntity> notificationEntities)
    {
        try
        {
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

    /**
    Deletes a notification asynchronously based on the provided notification ID.
    @param notificationId The ID of the notification to be deleted.
    @return A Task representing the asynchronous operation. The task result is a boolean indicating whether the deletion was successful (true) or not (false).
    @throws Exception If an error occurs during the deletion process.
*/
    
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