package applicationtier.entity;

public class TransactionEntity {

    private Long transactionId;
    private UserEntity sender;
    private UserEntity receiver;
    private int amount;
    private String date;
    private String comment;

//    public TransactionEntity(Long TransactionId, UserEntity sender, UserEntity receiver, int amount, String date, String comment) {
//        this.transactionId = TransactionId;
//        this.sender = sender;
//        this.receiver = receiver;
//        this.amount = amount;
//        this.date = date;
//        this.comment = comment;
//    }

    public TransactionEntity() {
    }

    /**
     * Get the ID of the transaction.
     *
     * @return The transaction ID.
     */
    public Long getTransactionId() {
        return transactionId;
    }

    /**
     * Set the ID of the transaction.
     *
     * @param transactionId The transaction ID to set.
     */
    public void setTransactionId(Long transactionId) {
        this.transactionId = transactionId;
    }

    /**
     * Get the sender of the transaction.
     *
     * @return The sender.
     */
    public UserEntity getSender() {
        return sender;
    }

    /**
     * Set the sender of the transaction.
     *
     * @param sender The sender to set.
     */
    public void setSender(UserEntity sender) {
        this.sender = sender;
    }

    /**
     * Get the receiver of the transaction.
     *
     * @return The receiver.
     */
    public UserEntity getReceiver() {
        return receiver;
    }

    /**
     * Set the receiver of the transaction.
     *
     * @param receiver The receiver to set.
     */
    public void setReceiver(UserEntity receiver) {
        this.receiver = receiver;
    }

    /**
     * Get the amount associated with the transaction.
     *
     * @return The amount.
     */
    public int getAmount() {
        return amount;
    }

    /**
     * Set the amount associated with the transaction.
     *
     * @param amount The amount to set.
     */
    public void setAmount(int amount) {
        this.amount = amount;
    }

    /**
     * Get the date of the transaction.
     *
     * @return The date.
     */
    public String getDate() {
        return date;
    }

    /**
     * Set the date of the transaction.
     *
     * @param date The date to set.
     */
    public void setDate(String date) {
        this.date = date;
    }

    /**
     * Get the comment or additional information about the transaction.
     *
     * @return The comment.
     */
    public String getComment() {
        return comment;
    }

    /**
     * Set the comment or additional information about the transaction.
     *
     * @param comment The comment to set.
     */
    public void setComment(String comment) {
        this.comment = comment;
    }

}
