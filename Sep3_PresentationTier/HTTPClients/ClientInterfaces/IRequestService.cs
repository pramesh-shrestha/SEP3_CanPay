namespace HTTPClients.ClientInterfaces;
using Entity.Model;


public interface IRequestService
{
    Task<RequestEntity?> CreateRequestAsync(RequestEntity requestEntity);
    Task<RequestEntity?> UpdateRequestAsync(RequestEntity requestEntity);
    Task<RequestEntity> FetchRequestById(long id);
}