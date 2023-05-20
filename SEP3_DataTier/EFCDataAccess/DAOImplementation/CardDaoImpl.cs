using EFCDataAccess.DAOInterface;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFCDataAccess.DAOImplementation;

public class CardDaoImpl : ICardDao
{
    private readonly CanPayDbAccess context;

    public CardDaoImpl(CanPayDbAccess context)
    {
        this.context = context;
    }


    /**
        Creates a debit card asynchronously.
        @param debitCardEntity The DebitCardEntity object representing the debit card to be created.
        @return A Task representing the asynchronous operation. 
        The task result contains the created DebitCardEntity object.
        @throws Exception If the card already exists.
    */
    public async Task<DebitCardEntity> CreateCardAsync(DebitCardEntity debitCardEntity)
    {
        try
        {
            EntityEntry<DebitCardEntity> cardAdded = await context.Cards.AddAsync(debitCardEntity);
            await context.SaveChangesAsync();
            return cardAdded.Entity;
        }
        catch (Exception e)
        {
            throw new Exception("Card already exists");
        }
    }

    
    
    /**
        Fetches a debit card asynchronously based on the provided username.
        @param username The username associated with the debit card to be fetched.
        @return A Task representing the asynchronous operation. The task result contains the fetched DebitCardEntity object.
        @throws Exception If the card doesn't exist.
    */
    public async Task<DebitCardEntity> FetchCardByUsernameAsync(string username)
    {
        DebitCardEntity? debitCard = await context.Cards.FindAsync(username);
        if (debitCard == null)
        {
            throw new Exception("Card doesnt exist");
        }

        return debitCard;
    }

    /**
        Updates a debit card asynchronously.
        @param debitCardEntity The DebitCardEntity object representing the updated debit card information.
        @return A Task representing the asynchronous operation. The task result contains the updated DebitCardEntity object.
    */
    public async Task<DebitCardEntity> UpdateCardAsync(DebitCardEntity debitCardEntity)
    {
        context.Cards.Update(debitCardEntity);
        await context.SaveChangesAsync();
        return debitCardEntity;
    }

    /**
        Deletes a debit card asynchronously based on the provided card ID.
        @param id The ID of the card to be deleted.
        @return A Task representing the asynchronous operation.
        @throws Exception If the card with the specified ID doesn't exist.
    */
    public async Task DeleteCardAsync(long id)
    {
        DebitCardEntity? existedCardEntity = await context.Cards.FirstOrDefaultAsync(card => card.CardId == id);
        if (existedCardEntity == null)
        {
            throw new Exception($"Card with id {id} doesnt exists");
        }

        context.Cards.Remove(existedCardEntity);
        await context.SaveChangesAsync();
    }
}