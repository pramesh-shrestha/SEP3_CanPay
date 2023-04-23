using Entity.Model;

namespace EFCDataAccess.DAOInterface; 

public interface IUserDao {
    Task<User> CreateUserAsync(User user);
    Task<User> FetchUserByUsernameAsync(string username);
    Task<User> FetchUserByIdAsync(long id);
    Task<ICollection<User>> FetchUsersAsync();
    Task<User> UpdateUserAsync(User user);
    Task DeleteUserAsync(long id);

}