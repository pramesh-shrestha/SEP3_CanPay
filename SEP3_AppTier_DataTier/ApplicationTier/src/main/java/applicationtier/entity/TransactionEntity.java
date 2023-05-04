package applicationtier.entity;

public class TransactionEntity {

    private UserEntity sender;
    private UserEntity receiver;
    private int amount;
    private String date;

    public TransactionEntity(UserEntity sender, UserEntity receiver, int amount, String date) {
        this.sender = sender;
        this.receiver = receiver;
        this.amount = amount;
        this.date = date;
    }

    public TransactionEntity() {
    }


    public UserEntity getSender() {
        return sender;
    }

    public void setSender(UserEntity sender) {
        this.sender = sender;
    }

    public UserEntity getReceiver() {
        return receiver;
    }

    public void setReceiver(UserEntity receiver) {
        this.receiver = receiver;
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