package applicationtier.entity;


public class UserEntity {
    private Long userId;
    private String fullName;
    private String userName;
    private String password;
    private DebitCardEntity card;

    public UserEntity(String fullName, String userName, String password, DebitCardEntity card) {
        this.fullName = fullName;
        this.userName = userName;
        this.password = password;
        this.card = card;
    }

    public UserEntity() {
    }

    public Long getUserId() {
        return userId;
    }

    public void setUserId(Long userId) {
        this.userId = userId;
    }

    public String getUserName() {
        return userName;
    }

    public void setUserName(String userName) {
        this.userName = userName;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public DebitCardEntity getCard() {
        return card;
    }

    public void setCard(DebitCardEntity card) {
        this.card = card;
    }

    public String getFullName() {
        return fullName;
    }

    public void setFullName(String fullName) {
        this.fullName = fullName;
    }
}
