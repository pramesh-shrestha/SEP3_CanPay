package applicationtier.entity;


import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.userdetails.UserDetails;

import java.util.Collection;

public class UserEntity implements UserDetails {
    private Long userId;
    private String fullName;
    private String userName;
    private String password;
    private DebitCardEntity card;
    private int balance;

    /**
     * Constructs a new UserEntity object with the specified parameters.
     *
     * @param fullName The full name of the user.
     * @param userName The username of the user.
     * @param password The password of the user.
     * @param card     The debit card associated with the user.
     * @param balance  The balance of the user.
     */
    public UserEntity(String fullName, String userName, String password, DebitCardEntity card, int balance) {
        this.fullName = fullName;
        this.userName = userName;
        this.password = password;
        this.card = card;
        this.balance = balance;
    }

    public UserEntity() {
    }

    /**
     * Get the ID of the user.
     *
     * @return The user ID.
     */
    public Long getUserId() {
        return userId;
    }

    /**
     * Set the ID of the user.
     *
     * @param userId The user ID to set.
     */
    public void setUserId(Long userId) {
        this.userId = userId;
    }

    /**
     * Get the username of the user.
     *
     * @return The username.
     */
    public String getUserName() {
        return userName;
    }


    /**
     * Set the username of the user.
     *
     * @param userName The username to set.
     */
    public void setUserName(String userName) {
        this.userName = userName;
    }

    @Override
    public Collection<? extends GrantedAuthority> getAuthorities() {
        return null;
    }


    /**
     * Get the password of the user.
     *
     * @return The password.
     */
    public String getPassword() {
        return password;
    }

    @Override
    public String getUsername() {
        return userName;
    }

    @Override
    public boolean isAccountNonExpired() {
        return true;
    }

    @Override
    public boolean isAccountNonLocked() {
        return true;
    }

    @Override
    public boolean isCredentialsNonExpired() {
        return true;
    }

    @Override
    public boolean isEnabled() {
        return true;
    }


    /**
     * Set the password of the user.
     *
     * @param password The password to set.
     */
    public void setPassword(String password) {
        this.password = password;
    }

    /**
     * Get the debit card associated with the user.
     *
     * @return The debit card.
     */
    public DebitCardEntity getCard() {
        return card;
    }

    /**
     * Set the debit card associated with the user.
     *
     * @param card The debit card to set.
     */
    public void setCard(DebitCardEntity card) {
        this.card = card;
    }

    /**
     * Get the full name of the user.
     *
     * @return The full name.
     */
    public String getFullName() {
        return fullName;
    }

    /**
     * Set the full name of the user.
     *
     * @param fullName The full name to set.
     */
    public void setFullName(String fullName) {
        this.fullName = fullName;
    }

    /**
     * Get the balance of the user.
     *
     * @return The balance.
     */
    public int getBalance() {
        return balance;
    }

    /**
     * Set the balance of the user.
     *
     * @param balance The balance to set.
     */
    public void setBalance(int balance) {
        this.balance = balance;
    }
}
