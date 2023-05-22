package applicationtier.entity;

public class DebitCardEntity {
    private Long cardId;
    private Long cardNumber;
    private String expiryDate;
    private int cvv;

    /**
     * Constructor to initialize the debit card with card number, expiry date, and CVV.
     *
     * @param cardNumber The card number.
     * @param expiryDate The expiry date of the card.
     * @param cvv The CVV (Card Verification Value) of the card.
     */
    public DebitCardEntity(Long cardNumber, String expiryDate, int cvv) {
        this.cardNumber = cardNumber;
        this.expiryDate = expiryDate;
        this.cvv = cvv;
    }

    public DebitCardEntity() {
    }

    /**
     * Get the card ID.
     *
     * @return The card ID.
     */
    public Long getCardId() {
        return cardId;
    }

    /**
     * Set the card ID.
     *
     * @param cardId The card ID to set.
     */
    public void setCardId(Long cardId) {
        this.cardId = cardId;
    }

    /**
     * Get the card number.
     *
     * @return The card number.
     */
    public Long getCardNumber() {
        return cardNumber;
    }

    /**
     * Set the card number.
     *
     * @param cardNumber The card number to set.
     */
    public void setCardNumber(Long cardNumber) {
        this.cardNumber = cardNumber;
    }

    /**
     * Get the expiry date of the card.
     *
     * @return The expiry date.
     */
    public String getExpiryDate() {
        return expiryDate;
    }

    /**
     * Set the expiry date of the card.
     *
     * @param expiryDate The expiry date to set.
     */
    public void setExpiryDate(String expiryDate) {
        this.expiryDate = expiryDate;
    }

    /**
     * Get the CVV (Card Verification Value) of the card.
     *
     * @return The CVV.
     */
    public int getCvv() {
        return cvv;
    }


    /**
     * Set the CVV (Card Verification Value) of the card.
     *
     * @param cvv The CVV to set.
     */
    public void setCvv(int cvv) {
        this.cvv = cvv;
    }
}
