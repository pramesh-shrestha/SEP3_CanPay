namespace Domains.Entity;

public class BillPaymentEntity
{
    
    public string  date { get; set; }
    public UserEntity   SenderUser { get; set; }
    public string  Payee { get; set; }
    public int  amount { get; set; }
    public long  accountNumber { get; set; }
    public string  Reference { get; set; }

    
    public BillPaymentEntity(string date, UserEntity senderUser, string payee, int amount, long accountNumber, string reference)
    {
        this.date = date;
        SenderUser = senderUser;
        Payee = payee;
        this.amount = amount;
        this.accountNumber = accountNumber;
        Reference = reference;
    }
}