package applicationtier.entity;

public class NotificationEntity {

    private Long id;
    private UserEntity sender;
    private UserEntity receiver;
    private String date;

    private String message;

    private String notificationType;

    private boolean isRead;


    public NotificationEntity() {
    }

    /**
     * Get the ID of the notification.
     *
     * @return The ID.
     */
    public Long getId() {
        return id;
    }

    /**
     * Set the ID of the notification.
     *
     * @param id The ID to set.
     */
    public void setId(Long id) {
        this.id = id;
    }

    /**
     * Get the sender of the notification.
     *
     * @return The sender.
     */
    public UserEntity getSender() {
        return sender;
    }

    /**
     * Set the sender of the notification.
     *
     * @param sender The sender to set.
     */
    public void setSender(UserEntity sender) {
        this.sender = sender;
    }

    /**
     * Get the receiver of the notification.
     *
     * @return The receiver.
     */
    public UserEntity getReceiver() {
        return receiver;
    }

    /**
     * Set the receiver of the notification.
     *
     * @param receiver The receiver to set.
     */
    public void setReceiver(UserEntity receiver) {
        this.receiver = receiver;
    }

    /**
     * Get the date of the notification.
     *
     * @return The date.
     */
    public String getDate() {
        return date;
    }

    /**
     * Set the date of the notification.
     *
     * @param date The date to set.
     */
    public void setDate(String date) {
        this.date = date;
    }

    /**
     * Get the message of the notification.
     *
     * @return The message.
     */
    public String getMessage() {
        return message;
    }

    /**
     * Set the message of the notification.
     *
     * @param message The message to set.
     */
    public void setMessage(String message) {
        this.message = message;
    }

    /**
     * Get the notification type.
     *
     * @return The notification type.
     */
    public String getNotificationType() {
        return notificationType;
    }

    /**
     * Set the notification type.
     *
     * @param notificationType The notification type to set.
     */
    public void setNotificationType(String notificationType) {
        this.notificationType = notificationType;
    }

    /**
     * Check if the notification has been read.
     *
     * @return true if the notification has been read, false otherwise.
     */
    public boolean isRead() {
        return isRead;
    }

    /**
     * Set the read status of the notification.
     *
     * @param read The read status to set.
     */
    public void setRead(boolean read) {
        isRead = read;
    }


}
