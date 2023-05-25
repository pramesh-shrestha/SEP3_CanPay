using System.Collections;
using EFCDataAccess.DAOInterface;
using Entity.Model;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using SEP3_DataTier;

namespace GrpcService.Services;

public class NotificationService : NotificationProtoService.NotificationProtoServiceBase
{
    private readonly INotificationDao notificationDao;

    public NotificationService(INotificationDao notificationDao)
    {
        this.notificationDao = notificationDao;
    }

    /// <summary>
    /// Creates a new notification.
    /// </summary>
    /// <param name="request">The NotificationProtoObj containing the notification data.</param>
    /// <param name="context">The server call context.</param>
    /// <returns>The created NotificationProtoObj.</returns>
    public override async Task<NotificationProtoObj> CreateNotificationAsync(NotificationProtoObj request,
        ServerCallContext context)
    {
        try
        {
            NotificationEntity? createdNotification =
                await notificationDao.CreateNotificationAsync(FromProtoToEntity(request));

            NotificationProtoObj notificationProtoObj = FromEntityToProto(createdNotification);

            return notificationProtoObj;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new RpcException(new Status(StatusCode.AlreadyExists, e.Message));
        }
    }

    /// <summary>
    /// Fetches a notification by its ID.
    /// </summary>
    /// <param name="request">The Int64Value containing the ID of the notification to fetch.</param>
    /// <param name="context">The server call context.</param>
    /// <returns>The fetched NotificationProtoObj.</returns>
    public override async Task<NotificationProtoObj> FetchNotificationByIdAsync(Int64Value request,
        ServerCallContext context)
    {
        try
        {
            NotificationEntity? notificationById
                = await notificationDao.FetchNotificationByIdAsync(request.Value);
            return FromEntityToProto(notificationById);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new RpcException(new Status(StatusCode.Internal, e.Message));
        }
    }

    /// <summary>
    /// Fetches all notifications by the receiver's username.
    /// </summary>
    /// <param name="request">The StringValue containing the username of the receiver.</param>
    /// <param name="context">The server call context.</param>
    /// <returns>The list of fetched NotificationProtoObj objects.</returns>
    public override async Task<NotificationProtoObjList> FetchAllNotificationsByReceiverAsync(StringValue request,
        ServerCallContext context)
    {
        try
        {
            ICollection<NotificationEntity?> notificationEntities =
                await notificationDao.FetchAllNotificationsByReceiverAsync(request.Value);

            NotificationProtoObjList protoObjList = new NotificationProtoObjList
            {
                AllNotifications =
                {
                    notificationEntities.Select(entity =>
                    {
                        NotificationProtoObj protoObj = FromEntityToProto(entity);
                        protoObj.NotificationId = entity.Id;
                        return protoObj;
                    })
                }
            };
            return protoObjList;
        }
        catch (Exception e)
        {
            // Console.WriteLine(e);
            throw new RpcException(new Status(StatusCode.Aborted, e.Message));
        }
    }

    /// <summary>
    /// Marks a notification as read.
    /// </summary>
    /// <param name="request">The NotificationProtoObj representing the notification to mark as read.</param>
    /// <param name="context">The server call context.</param>
    /// <returns>An Empty response.</returns>
    public override async Task<Empty> MarkAsRead(NotificationProtoObj request, ServerCallContext context)
    {
        await notificationDao.MarkNotificationAsReadAsync(FromProtoToEntity(request));
        return new Empty();
    }

    /// <summary>
    /// Marks all notifications in the list as read.
    /// </summary>
    /// <param name="request">The NotificationProtoObjList containing the notifications to mark as read.</param>
    /// <param name="context">The server call context.</param>
    /// <returns>An Empty response.</returns>
    public override async Task<Empty> MarkAllAsRead(NotificationProtoObjList request, ServerCallContext context)
    {
        List<NotificationProtoObj> protoObjs = request.AllNotifications.ToList();

        List<NotificationEntity> entities = protoObjs.Select(FromProtoToEntity).ToList();

        await notificationDao.MarkAllNotificationsAsReadAsync(entities);
        return new Empty();
    }



    /// <summary>
    /// Converts a NotificationProtoObj to a NotificationEntity.
    /// </summary>
    /// <param name="notificationProtoObj">The NotificationProtoObj to convert.</param>
    /// <returns>The converted NotificationEntity.</returns>
    public static NotificationEntity? FromProtoToEntity(NotificationProtoObj notificationProtoObj)
    {
        NotificationEntity? entity = new NotificationEntity
        {
            Date = notificationProtoObj.Date,
            IsRead = (bool)notificationProtoObj.IsRead!,
            Message = notificationProtoObj.Message,
            Sender = UserService.FromProtoToEntity(notificationProtoObj.SenderUser),
            Receiver = UserService.FromProtoToEntity(notificationProtoObj.ReceiverUser),
            NotificationType = notificationProtoObj.Type
        };

        if (notificationProtoObj.NotificationId != 0)
        {
            entity.Id = notificationProtoObj.NotificationId!.Value;
        }

        return entity;
    }

    /// <summary>
    /// Converts a NotificationEntity to a NotificationProtoObj.
    /// </summary>
    /// <param name="entity">The NotificationEntity to convert.</param>
    /// <returns>The converted NotificationProtoObj.</returns>
    public static NotificationProtoObj FromEntityToProto(NotificationEntity? entity)
    {
        NotificationProtoObj protoObj = new NotificationProtoObj
        {
            NotificationId = entity.Id,
            Date = entity.Date,
            IsRead = entity.IsRead,
            Message = entity.Message,
            SenderUser = UserService.FromEntityToProto(entity.Sender!),
            ReceiverUser = UserService.FromEntityToProto(entity.Receiver!),
            Type = entity.NotificationType
        };
        return protoObj;
    }
}