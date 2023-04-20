package entity;

public class DebitCard {
  private Long cardId;
  private Long cardNumber;
  private String expiryDate;
  private int cvv;

  public DebitCard(Long cardNumber, String expiryDate, int cvv) {
    this.cardNumber = cardNumber;
    this.expiryDate = expiryDate;
    this.cvv = cvv;
  }

  public Long getCardId() {
    return cardId;
  }

  public void setCardId(Long cardId) {
    this.cardId = cardId;
  }

  public Long getCardNumber() {
    return cardNumber;
  }

  public void setCardNumber(Long cardNumber) {
    this.cardNumber = cardNumber;
  }

  public String getExpiryDate() {
    return expiryDate;
  }

  public void setExpiryDate(String expiryDate) {
    this.expiryDate = expiryDate;
  }

  public int getCvv() {
    return cvv;
  }

  public void setCvv(int cvv) {
    this.cvv = cvv;
  }
}
