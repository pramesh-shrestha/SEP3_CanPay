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

    public override async Task<NotificationProtoObj> CreateNotificationAsync(NotificationProtoObj request,
        ServerCallContext context)
    {
        try
        {
            NotificationEntity createdNotification =
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

    public override async Task<NotificationProtoObjList> FetchAllNotificationsByReceiverAsync(StringValue request,
        ServerCallContext context)
    {
        try
        {
            ICollection<NotificationEntity> notificationEntities =
                await notificationDao.FetchAllNotificationsByReceiverAsync(request.Value);

            if (notificationEntities.Count == 0)
            {
                throw new Exception("No Notifications for Receiver!!!");
            }

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
            Console.WriteLine(e);
            throw new RpcException(new Status(StatusCode.Aborted, e.Message));
        }
    }

    public override async Task<Empty> MarkAsRead(NotificationProtoObj request, ServerCallContext context)
    {
        await notificationDao.MarkNotificationAsReadAsync(FromProtoToEntity(request));
        return new Empty();
    }

    public override async Task<Empty> MarkAllAsRead(NotificationProtoObjList request, ServerCallContext context)
    {
        List<NotificationProtoObj> protoObjs = request.AllNotifications.ToList();

        List<NotificationEntity> entities = protoObjs.Select(FromProtoToEntity).ToList();

        await notificationDao.MarkAllNotificationsAsReadAsync(entities);
        return new Empty();
    }

    public override async Task<BoolValue> DeleteNotificationAsync(Int64Value request, ServerCallContext context)
    {
        try
        {
            bool deleteNotificationAsync = await notificationDao.DeleteNotificationAsync(request.Value);
            return new BoolValue { Value = deleteNotificationAsync };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new RpcException(new Status(StatusCode.Aborted, e.Message));
        }
    }

    public static NotificationEntity FromProtoToEntity(NotificationProtoObj notificationProtoObj)
    {
        NotificationEntity entity = new NotificationEntity
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

    public static NotificationProtoObj FromEntityToProto(NotificationEntity entity)
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