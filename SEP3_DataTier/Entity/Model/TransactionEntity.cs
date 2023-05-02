using System.ComponentModel.DataAnnotations;

namespace Entity.Model;

public class TransactionEntity
{
    [Key] public int Id { get; set; }
    [Required] public UserEntity Sender { get; set; }
    [Required] public UserEntity Receiver { get; set; }
    [Required] public int Amount { get; set; }
    public string Date { get; set; }
}