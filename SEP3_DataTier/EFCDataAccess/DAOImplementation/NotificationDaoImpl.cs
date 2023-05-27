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

    /// <summary>
    /// Creates a notification asynchronously.
    /// </summary>
    /// <param name="notificationEntity">The notification entity to create.</param>
    /// <returns>The created notification entity.</returns>
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

    /// <summary>
    /// Fetches a notification by its ID asynchronously.
    /// </summary>
    /// <param name="requestValue">The ID of the notification to fetch.</param>
    /// <returns>The fetched notification entity.</returns>
    public async Task<NotificationEntity?> FetchNotificationByIdAsync(long requestValue)
    {
        try
        {
            NotificationEntity? notificationEntity =
                await context.Notifications.Include(entity => entity.Sender)
                    .Include(entity => entity.Sender.Card)
                    .Include(entity => entity.Receiver.Card)
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

    /// <summary>
    /// Fetches all notifications by receiver username asynchronously.
    /// </summary>
    /// <param name="username">The username of the receiver.</param>
    /// <returns>A collection of notification entities.</returns>
    public async Task<ICollection<NotificationEntity?>> FetchAllNotificationsByReceiverAsync(string username)
    {
        try
        {
            ICollection<NotificationEntity?> notificationEntities = await context.Notifications
                .Include(entity => entity.Sender).Include(entity => entity.Receiver)
                .Where(e => e.Receiver!.Username!.Equals(username)).Where(entity => !entity.IsRead).ToListAsync();

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
        try
        {
            var existingEntities = await context.Notifications
                .FirstOrDefaultAsync(entity => entity.Id == notificationEntity.Id);
            existingEntities.IsRead = true;
            await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception(e.Message);
        }
    }

    /// <summary>
    /// Marks all notifications as read asynchronously.
    /// </summary>
    /// <param name="notificationEntities">The list of notification entities to mark as read.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task MarkAllNotificationsAsReadAsync(List<NotificationEntity> notificationEntities)
    {
        try
        {
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
    
}