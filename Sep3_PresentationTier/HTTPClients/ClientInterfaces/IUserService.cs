using System.Collections;
using Domains.Entity;

namespace HTTPClients.ClientInterfaces;

public interface IUserService
{
    Task<User> CreateAsync(User toCreateUser);
    Task<IEnumerable<User>> FetchUsersAsync();
    Task<User> FetchUserByIdAsync();
    Task<User> FetchUserByUsernameAsync(string username);
    Task<User> UpdateUserAsync(long id, User user);
    Task DeleteUserAsync(long id);
}