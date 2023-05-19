namespace HTTPClients.ClientInterfaces;
using Entity.Model;


public interface IRequestService
{
    Task<RequestEntity?> CreateRequestAsync(RequestEntity requestEntity);
}