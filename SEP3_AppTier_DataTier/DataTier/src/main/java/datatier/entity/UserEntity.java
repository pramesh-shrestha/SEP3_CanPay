package datatier.entity;

import datatier.protobuf.DebitCard;
import datatier.protobuf.User;

import jakarta.persistence.*;

@Entity
@Table(name = "User")
public class UserEntity {
  @Id
  @GeneratedValue(strategy = GenerationType.AUTO)
  @Column(name = "user_id")
  private Long userId;
  @Column(name = "Fullname")
  private String fullName;
  @Column(name = "Username")
  private String userName;

  @Column(name = "Password")
  private String password;

  @Column(name = "Card")
  private DebitCard card;

  public UserEntity(String fullName, String userName, String password, DebitCard card) {
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

  public datatier.protobuf.DebitCard getCard() {
    return card;
  }

  public void setCard(DebitCard card) {
    this.card = card;
  }

  public String getFullName() {
    return fullName;
  }

  public void setFullName(String fullName) {
    this.fullName = fullName;
  }

  public User toProto(){
    return User.newBuilder()
        .setUserId(getUserId())
        .setFullName(getFullName())
        .setUserName(getUserName())
        .setPassword(getPassword())
        .setCard(getCard())
        .build();
  }

  public static UserEntity fromProto(User user){
    UserEntity userEntity = new UserEntity();
    userEntity.setUserId(user.getUserId());
    userEntity.setFullName(user.getFullName());
    userEntity.setUserName(userEntity.getUserName());
    userEntity.setPassword(user.getPassword());
    userEntity.setCard(user.getCard());
    return userEntity;
  }
}
