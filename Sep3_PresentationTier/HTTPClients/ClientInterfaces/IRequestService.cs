using Entity.Model;

namespace HTTPClients.ClientInterfaces;

public interface IRequestService
{
    Task<RequestEntity?> CreateRequestAsync(RequestEntity requestEntity);
}