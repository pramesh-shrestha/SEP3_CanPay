using System.ComponentModel.DataAnnotations;

namespace Entity.Model;

public class NotificationEntity
{
    [Key] public long Id { get; set; }

    public UserEntity? Sender { get; set; }

    public UserEntity? Receiver { get; set; }

    [Required] public string? Message { get; set; }

    [Required] public string? NotificationType { get; set; }

    [Required] public string? Date { get; set; }

    [Required] public bool IsRead { get; set; }
}