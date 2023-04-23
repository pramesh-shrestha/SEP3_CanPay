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
    

    //method to create Card
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

    //Fetch card by username
    public async Task<DebitCardEntity> FetchCardByUsernameAsync(string username)
    {
        DebitCardEntity? debitCard = await context.Cards.FindAsync(username);
        if (debitCard==null)
        {
            throw new Exception("Card doesnt exist");
        }
        return debitCard;
    }

    //update card 
    public async Task<DebitCardEntity> UpdateCardAsync(DebitCardEntity debitCardEntity)
    {
        context.Cards.Update(debitCardEntity);
        await context.SaveChangesAsync();
        return debitCardEntity;
    }

    //delete cardd
    public async Task DeleteCardAsync(long id)
    {
        DebitCardEntity? existedCardEntity = await context.Cards.FirstOrDefaultAsync(card => card.CardId == id);
        if (existedCardEntity==null)
        {
            throw new Exception($"Card with id {id} doesnt exists");
        }

        context.Cards.Remove(existedCardEntity);
        await context.SaveChangesAsync();
    }
}