namespace Domains.Entity;

public class NotificationEntity
{
    public long Id { get; set; }

     public UserEntity? Sender { get; set; }

    public UserEntity? Receiver { get; set; }

    public string? Message { get; set; }

    public string? NotificationType { get; set; }

    public string? Date { get; set; }

    public bool IsRead { get; set; }

    public NotificationEntity(long id, UserEntity? sender, UserEntity? receiver, string? message, string? notificationType, string? date, bool isRead)
    {
        Id = id;
        Sender = sender;
        Receiver = receiver;
        Message = message;
        NotificationType = notificationType;
        Date = date;
        IsRead = isRead;
    }
}