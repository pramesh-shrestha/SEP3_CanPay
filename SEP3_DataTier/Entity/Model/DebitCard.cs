using System.ComponentModel.DataAnnotations;

namespace Entity.Model; 

public class DebitCard {
    [Key]
    public long CardId { get; set; }
    public long CardNumber { get; set; }
    public string ExpiryDate { get; set; }
    public int CVV { get; set; }
}