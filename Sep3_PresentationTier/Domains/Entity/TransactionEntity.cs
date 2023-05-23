namespace Domains.Entity;

public class TransactionEntity
{
    public long TransactionId { get; set; }
    public UserEntity Sender { get; set; }
    public UserEntity? Receiver { get; set; }
    public int Amount { get; set; }
    public string Date { get; set; }
    public string Comment { get; set; }

    /*public TransactionEntity(UserEntity sender, UserEntity? receiver, int amount, string date, string comment)
    {
        Sender = sender;
        Receiver = receiver;
        Amount = amount;
        Date = date;
        Comment = comment;
    }*/
}