using Entity.Model;

namespace EFCDataAccess.DAOInterface; 

public interface IRequestDao {
    Task<RequestEntity?> CreateRequestAsync(RequestEntity? requestEntity);
    Task<ICollection<RequestEntity?>> FetchAllRequestsAsync();
    Task<RequestEntity?> FetchRequestByIdAsync(long id);
    Task<RequestEntity?> FetchRequestByUsernameAsync(string username);
    Task<RequestEntity?> UpdateRequest(RequestEntity? requestEntity);
    Task<bool> DeleteRequest(long id);
}