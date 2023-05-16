using System.ComponentModel.DataAnnotations;

namespace Entity.Model; 

public class RequestEntity {
    
    [Key]public long Id { get; set; }
    public bool IsApproved { get; set; }
    public string? Status { get; set; }
    public int Amount { get; set; }
    public string? Comment { get; set; }
    public UserEntity? Payer { get; set; }  
}