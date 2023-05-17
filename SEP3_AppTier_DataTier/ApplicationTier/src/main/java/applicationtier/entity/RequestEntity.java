package applicationtier.entity;

public class RequestEntity {

    private Long id;
    private boolean isApproved;
    private String status;
    private int amount;
    private String comment;
    private UserEntity payer;


    public RequestEntity(Long id, boolean isApproved, String status, int amount, String comment, UserEntity payer) {

        this.id = id;
        this.isApproved = isApproved;
        this.status = status;
        this.amount = amount;
        this.comment = comment;
        this.payer = payer;
    }

    public Long getId() {
        return id;
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

    public UserEntity getPayer() {
        return payer;
    }

    public void setPayer(UserEntity payer) {
        this.payer = payer;
    }
}
