using Domains.Entity;

namespace HTTPClients.ClientInterfaces;

public interface ICardService
{
    Task<DebitCardEntity> CreateAsync(DebitCardEntity toCreateCardEntity);

}