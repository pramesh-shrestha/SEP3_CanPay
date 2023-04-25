using Entity.Model;

namespace EFCDataAccess.DAOInterface;

public interface ICardDao
{
    Task<DebitCardEntity> CreateCardAsync(DebitCardEntity debitCardEntity);
    Task<DebitCardEntity> FetchCardByUsernameAsync(string username);
    Task<DebitCardEntity> UpdateCardAsync(DebitCardEntity debitCardEntity);
    Task DeleteCardAsync(long id);
}