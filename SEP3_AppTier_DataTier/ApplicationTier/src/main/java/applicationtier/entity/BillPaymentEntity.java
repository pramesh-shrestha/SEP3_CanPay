package applicationtier.entity;

public class BillPaymentEntity {
    private Long Id;
    private UserEntity payer;

    private String payee;
    private String accountNumber;
    private int amount;
    private String date;
    private String referenceNumber;

    public BillPaymentEntity(Long Id, UserEntity payer, String payee, String accountNumber, int amount, String date, String referenceNumber) {
        this.Id = Id;
        this.payer = payer;
        this.payee = payee;
        this.accountNumber = accountNumber;
        this.amount = amount;
        this.date = date;
        this.referenceNumber = referenceNumber;
    }

    public BillPaymentEntity(){}

    public Long getId() {
        return Id;
    }

    public void setId(Long id) {
        Id = id;
    }

    public UserEntity getPayer() {
        return payer;
    }

    public void setPayer(UserEntity payer) {
        this.payer = payer;
    }

    public String getPayee() {
        return payee;
    }

    public void setPayee(String payee) {
        this.payee = payee;
    }

    public String getReferenceNumber() {
        return referenceNumber;
    }

    public void setReferenceNumber(String referenceNumber) {
        this.referenceNumber = referenceNumber;
    }

    public String getAccountNumber() {
        return accountNumber;
    }

    public void setAccountNumber(String accountNumber) {
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




}
