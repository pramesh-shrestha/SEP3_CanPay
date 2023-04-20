package entity;

public class User {
  private Long userId;
  private String firstName;
  private String lastName;
  private String userName;
  private String password;
  private DebitCard card;

  public User(String firstName, String lastName, String userName, String password, DebitCard card) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.userName = userName;
    this.password = password;
    this.card = card;
  }

  public Long getUserId() {
    return userId;
  }

  public void setUserId(Long userId) {
    this.userId = userId;
  }

  public String getFirstName() {
    return firstName;
  }

  public void setFirstName(String firstName) {
    this.firstName = firstName;
  }

  public String getLastName() {
    return lastName;
  }

  public void setLastName(String lastName) {
    this.lastName = lastName;
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

  public DebitCard getCard() {
    return card;
  }

  public void setCard(DebitCard card) {
    this.card = card;
  }
}
