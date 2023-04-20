namespace Domains.Entity;

public class DebitCard
{
    public long CardId { get; set; }
    public long CardNumber { get; set; }
    public string? ExpiryDate { get; set; }
    public int CVV { get; set; }

    public DebitCard(long cardNumber, string? expiryDate, int cvv)
    {
        CardNumber = cardNumber;
        ExpiryDate = expiryDate;
        CVV = cvv;
    }
}