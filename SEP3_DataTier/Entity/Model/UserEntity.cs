using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Model;

public class UserEntity
{
    [Key] public string Username { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Required]
    // [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^\w\d\s:])([^\s]){8,30}$")]
    public string Password { get; set; }

    [Required] public string Fullname { get; set; }

    [Required] public int Balance { get; set; }
    public DebitCardEntity Card { get; set; }
}