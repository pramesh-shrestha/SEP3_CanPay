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


    /// <summary>
    /// Creates a debit card asynchronously.
    /// </summary>
    /// <param name="debitCardEntity">The debit card entity to create.</param>
    /// <returns>The created debit card entity.</returns>
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

    
    
    /// <summary>
    /// Fetches a debit card by username asynchronously.
    /// </summary>
    /// <param name="username">The username associated with the debit card.</param>
    /// <returns>The fetched debit card entity.</returns>
    public async Task<DebitCardEntity> FetchCardByUsernameAsync(string username)
    {
        DebitCardEntity? debitCard = await context.Cards.FindAsync(username);
        if (debitCard == null)
        {
            throw new Exception("Card doesnt exist");
        }

        return debitCard;
    }

    /// <summary>
    /// Updates a debit card asynchronously.
    /// </summary>
    /// <param name="debitCardEntity">The debit card entity to update.</param>
    /// <returns>The updated debit card entity.</returns>
    public async Task<DebitCardEntity> UpdateCardAsync(DebitCardEntity debitCardEntity)
    {
        context.Cards.Update(debitCardEntity);
        await context.SaveChangesAsync();
        return debitCardEntity;
    }

    /// <summary>
    /// Deletes a debit card asynchronously.
    /// </summary>
    /// <param name="id">The ID of the debit card to delete.</param>
    /// <returns>A task representing the asynchronous delete operation.</returns>
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