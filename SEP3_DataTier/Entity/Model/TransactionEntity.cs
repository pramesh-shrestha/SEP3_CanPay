using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Model;

public class TransactionEntity
{
    [Key] public long Id { get; set; }
    public UserEntity? Sender { get; set; }
    public UserEntity? Receiver { get; set; }
    [Required] public int? Amount { get; set; }
    public string Date { get; set; }
    public string Comment { get; set; }
}