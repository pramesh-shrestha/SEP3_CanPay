package applicationtier.entity;
public class NotificationEntity {

    private Long id;
    private UserEntity sender;
    private UserEntity receiver;
    private String date;

    private String message;

    private String type;

    private boolean isRead;

    public NotificationEntity(Long id, UserEntity sender, UserEntity receiver, String date, String message, String type, boolean isRead) {
        this.id = id;
        this.sender = sender;
        this.receiver = receiver;
        this.date = date;
        this.message = message;
        this.type = type;
        this.isRead = isRead;
    }
    public NotificationEntity(){}

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
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

    public String getDate() {
        return date;
    }

    public void setDate(String date) {
        this.date = date;
    }

    public String getMessage() {
        return message;
    }

    public void setMessage(String message) {
        this.message = message;
    }

    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }

    public boolean isRead() {
        return isRead;
    }

    public void setRead(boolean read) {
        isRead = read;
    }
}
