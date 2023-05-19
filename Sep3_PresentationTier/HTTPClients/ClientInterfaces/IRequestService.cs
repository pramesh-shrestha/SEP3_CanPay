using Entity.Model;

namespace HTTPClients.ClientInterfaces;

public interface IRequestService
{
    Task<RequestEntity?> CreateRequestAsync(RequestEntity requestEntity);
    Task<RequestEntity?> UpdateRequestAsync(RequestEntity requestEntity);
    Task<RequestEntity> FetchRequestById(long id);
}