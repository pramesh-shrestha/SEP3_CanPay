using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Model;

public class TransactionEntity
{
    [Key] public long Id { get; set; }
    [Required] 
    public UserEntity Sender { get; set; }
    [Required] public UserEntity Receiver { get; set; }
    [Required] public int? Amount { get; set; }

    public string Date { get; set; }
}
