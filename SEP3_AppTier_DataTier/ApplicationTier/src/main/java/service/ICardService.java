package service;

import entity.DebitCard;

public interface ICardService {
    DebitCard CreateCard(DebitCard card);
    DebitCard FetchCardByUsername(String username);
    DebitCard updateCard(Long id,DebitCard card);
    void deleteCard(Long id);
}
