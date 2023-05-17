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


    public RequestEntity(Long id, boolean isApproved, String status, int amount, String comment, UserEntity requestReceiver, UserEntity requestSender) {

        this.id = id;
        this.isApproved = isApproved;
        this.status = status;
        this.amount = amount;
        this.comment = comment;
        this.requestReceiver = requestReceiver;
        this.requestSender = requestSender;
    }

    public RequestEntity() {
    }

    public Long getId() {
        return id;
    }

    public UserEntity getRequestSender() {
        return requestSender;
    }

    public void setRequestSender(UserEntity requestSender) {
        this.requestSender = requestSender;
    }

    public UserEntity getRequestReceiver() {
        return requestReceiver;
    }

    public void setRequestReceiver(UserEntity requestReceiver) {
        this.requestReceiver = requestReceiver;
    }

    public String getRequestedDate() {
        return requestedDate;
    }

    public void setRequestedDate(String requestedDate) {
        this.requestedDate = requestedDate;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public boolean isApproved() {
        return isApproved;
    }

    public void setApproved(boolean approved) {
        isApproved = approved;
    }

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }

    public int getAmount() {
        return amount;
    }

    public void setAmount(int amount) {
        this.amount = amount;
    }

    public String getComment() {
        return comment;
    }

    public void setComment(String comment) {
        this.comment = comment;
    }




}
