package applicationtier.entity;

public class RequestEntity {

    private Long id;
    private boolean isApproved;
    private String status;
    private int amount;
    private String comment;
    private UserEntity requestSender;
    private UserEntity requestReceiver;
    private String requestedDate;




    public RequestEntity() {
    }


    /**
     * Get the ID of the request.
     *
     * @return The ID.
     */
    public Long getId() {
        return id;
    }

    /**
     * Get the sender of the request.
     *
     * @return The sender.
     */
    public UserEntity getRequestSender() {
        return requestSender;
    }

    /**
     * Set the sender of the request.
     *
     * @param requestSender The sender to set.
     */
    public void setRequestSender(UserEntity requestSender) {
        this.requestSender = requestSender;
    }

    /**
     * Get the receiver of the request.
     *
     * @return The receiver.
     */
    public UserEntity getRequestReceiver() {
        return requestReceiver;
    }

    /**
     * Set the receiver of the request.
     *
     * @param requestReceiver The receiver to set.
     */
    public void setRequestReceiver(UserEntity requestReceiver) {
        this.requestReceiver = requestReceiver;
    }


    /**
     * Get the date when the request was made.
     *
     * @return The requested date.
     */
    public String getRequestedDate() {
        return requestedDate;
    }

    /**
     * Set the date when the request was made.
     *
     * @param requestedDate The requested date to set.
     */
    public void setRequestedDate(String requestedDate) {
        this.requestedDate = requestedDate;
    }

    /**
     * Set the ID of the request.
     *
     * @param id The ID to set.
     */
    public void setId(Long id) {
        this.id = id;
    }

    /**
     * Check if the request is approved.
     *
     * @return true if the request is approved, false otherwise.
     */
    public boolean isApproved() {
        return isApproved;
    }

    /**
     * Set the approval status of the request.
     *
     * @param approved The approval status to set.
     */
    public void setApproved(boolean approved) {
        isApproved = approved;
    }

    /**
     * Get the status of the request.
     *
     * @return The status.
     */
    public String getStatus() {
        return status;
    }

    /**
     * Set the status of the request.
     *
     * @param status The status to set.
     */
    public void setStatus(String status) {
        this.status = status;
    }

    /**
     * Get the amount associated with the request.
     *
     * @return The amount.
     */
    public int getAmount() {
        return amount;
    }

    /**
     * Set the amount associated with the request.
     *
     * @param amount The amount to set.
     */
    public void setAmount(int amount) {
        this.amount = amount;
    }

    /**
     * Get the comment or additional information about the request.
     *
     * @return The comment.
     */
    public String getComment() {
        return comment;
    }

    /**
     * Set the comment or additional information about the request.
     *
     * @param comment The comment to set.
     */
    public void setComment(String comment) {
        this.comment = comment;
    }


}
