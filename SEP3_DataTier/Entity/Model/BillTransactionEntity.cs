namespace Entity.Model;
using System.ComponentModel.DataAnnotations;

public class BillTransactionEntity
{
    [Key] public long Id { get; set; }
    public UserEntity Payer { get; set; }
    public string Payee { get; set; }
    public string AccountNumber { get; set; }
    [Required] public int Amount { get; set; }
    public string Date { get; set; }
    public string ReferenceNumber { get; set; }
}
