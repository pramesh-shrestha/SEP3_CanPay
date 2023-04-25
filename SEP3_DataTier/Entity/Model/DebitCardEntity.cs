using System.ComponentModel.DataAnnotations;

namespace Entity.Model; 

public class DebitCardEntity {
    [Key]
    public long CardId { get; set; }
    [Required]
    [StringLength(16, ErrorMessage = "The card number must contain 16 digits")]
    public long CardNumber { get; set; }
    [Required]
    public string ExpiryDate { get; set; }
    [Required]
    public int CVV { get; set; }
}