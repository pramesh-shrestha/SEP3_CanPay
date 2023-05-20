package applicationtier.entity;

public class BillPaymentEntity {
    private Long paymentId;
    private UserEntity sender;

    private String payeeName;
    private long accountNumber;
    private int amount;
    private String date;
    private String reference;

    public BillPaymentEntity(Long paymentId, UserEntity sender, String payeeName, long accountNumber, int amount, String date, String reference) {
        this.paymentId = paymentId;
        this.sender = sender;
        this.payeeName = payeeName;
        this.accountNumber = accountNumber;
        this.amount = amount;
        this.date = date;
        this.reference = reference;
    }

    public BillPaymentEntity(){}

    public Long getPaymentId() {
        return paymentId;
    }

    public void setPaymentId(Long paymentId) {
        this.paymentId = paymentId;
    }

    public UserEntity getSender() {
        return sender;
    }

    public void setSender(UserEntity sender) {
        this.sender = sender;
    }

    public String getPayeeName() {
        return payeeName;
    }

    public void setPayeeName(String payeeName) {
        this.payeeName = payeeName;
    }

    public long getAccountNumber() {
        return accountNumber;
    }

    public void setAccountNumber(long accountNumber) {
        this.accountNumber = accountNumber;
    }

    public int getAmount() {
        return amount;
    }

    public void setAmount(int amount) {
        this.amount = amount;
    }

    public String getDate() {
        return date;
    }

    public void setDate(String date) {
        this.date = date;
    }

    public String getReference() {
        return reference;
    }

    public void setReference(String reference) {
        this.reference = reference;
    }


}
