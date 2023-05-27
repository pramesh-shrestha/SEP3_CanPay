using Entity.Model;

namespace EFCDataAccess.DAOInterface; 

public interface IRequestDao {
    Task<RequestEntity?> CreateRequestAsync(RequestEntity? requestEntity);
    
    Task<RequestEntity?> FetchRequestByIdAsync(long id);
   
    Task<RequestEntity?> UpdateRequest(RequestEntity? requestEntity);
   
}