using System.ComponentModel.DataAnnotations;

namespace Entity.Model; 

public class User {
    [Key]
    public string Username { get; set; }

    public string Password { get; set; }
    public string Fullname { get; set; }
    public DebitCard Card { get; set; }
}
