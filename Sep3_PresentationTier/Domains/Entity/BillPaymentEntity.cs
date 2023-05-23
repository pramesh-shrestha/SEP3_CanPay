namespace Domains.Entity;

public class BillPaymentEntity
{
    public long id { get; set; }
    public UserEntity Payer { get; set; }
    public string Payee { get; set; }
    public string AccountNumber { get; set; }
    public int Amount { get; set; }
    public string Date { get; set; }
    public string ReferenceNumber { get; set; }


    public BillPaymentEntity(UserEntity payer, string payee, string accountNumber, int amount, string date, string referenceNumber)
    {
        Payer = payer;
        Payee = payee;
        AccountNumber = accountNumber;
        Amount = amount;
        Date = date;
        ReferenceNumber = referenceNumber;
    }
}