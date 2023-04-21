using System.Net.Http.Json;
using System.Text.Json;
using Domains.Entity;
using HTTPClients.ClientInterfaces;

namespace HTTPClients.Implementations;

public class UserService : IUserService
{
    private readonly HttpClient client;

    public UserService(HttpClient client)
    {
        this.client = client;
    }

    public async Task<User> CreateAsync(User toCreateUser)
    {
        HttpResponseMessage responseMessage = await client.PostAsJsonAsync("/user/create", toCreateUser);
        string result = await responseMessage.Content.ReadAsStringAsync();
        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        User user = JsonSerializer.Deserialize<User>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        
        return user;
    }

    public Task<IEnumerable<User>> FetchUsersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User> FetchUserByIdAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User> FetchUserByUsernameAsync(string username)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateUserAsync(long id, User user)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUserAsync(long id)
    {
        throw new NotImplementedException();
    }
}