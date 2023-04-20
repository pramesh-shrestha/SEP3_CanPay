using Domains.Entity;

namespace HTTPClients.ClientInterfaces;

public interface ICardService
{
    Task<DebitCard> CreateAsync(DebitCard toCreateCard);
    Task<DebitCard> FetchCardByUsernameAsync(string username);
    Task<DebitCard> UpdateCardAsync(long id, User user);
    Task DeleteCardAsync(long id);
}