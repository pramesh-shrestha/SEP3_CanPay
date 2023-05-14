using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Json;
using Domains.Entity;
using HTTPClients.Auth;
using HTTPClients.ClientInterfaces;

namespace HTTPClients.Implementations;

using Domains;

public class UserService : IUserService
{
    private readonly HttpClient client;
    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; } = null!;
    public static string? Jwt { get; private set; } = "";


    public UserService(HttpClient client)
    {
        this.client = client;
    }

    public async Task<UserEntity> CreateAsync(UserEntity toCreateUserEntity)
    {
        HttpResponseMessage responseMessage = await client.PostAsJsonAsync("/user/create", toCreateUserEntity);
        string result = await responseMessage.Content.ReadAsStringAsync();
        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        UserEntity userEntity = JsonSerializer.Deserialize<UserEntity>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;

        return userEntity;
    }

    public async Task<IEnumerable<UserEntity?>> FetchAllUsersAsync()
    {
        LoadClientWithToken();
        HttpResponseMessage responseMessage = await client.GetAsync("/user");
        string result = await responseMessage.Content.ReadAsStringAsync();
        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        IEnumerable<UserEntity?> userEntities = JsonSerializer.Deserialize<IEnumerable<UserEntity>>(result,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;

        return userEntities.ToList();
    }


    public Task<UserEntity> FetchUserByIdAsync(long id)
    {
        LoadClientWithToken();
        throw new NotImplementedException();
    }

    public async Task<UserEntity> FetchUserByUsernameAsync(string username)
    {
        LoadClientWithToken();
        HttpResponseMessage responseMessage = await client.GetAsync($"/user/username/{username}");
        string result = await responseMessage.Content.ReadAsStringAsync();

        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        UserEntity userEntity = JsonSerializer.Deserialize<UserEntity>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        

        return userEntity;
    }

 

    public Task<Boolean> DeleteUserAsync(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<UserEntity> UpdateUserAsync(UserEntity userEntity) {
        LoadClientWithToken();
        HttpResponseMessage response = await client.PostAsJsonAsync("/user/update", userEntity);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        UserEntity user = JsonSerializer.Deserialize<UserEntity>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;

        return user;
        
    }

    //Send user credentials to the Application tier for validation
    public async Task<AuthenticationResponse> ValidateUser(string username, string password)
    {
        LoginDto loginDto = new LoginDto
        {
            Username = username,
            Password = password
        };

        HttpResponseMessage responseMessage = await client.PostAsJsonAsync("/user/authenticate", loginDto);
        string result = await responseMessage.Content.ReadAsStringAsync();
        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        AuthenticationResponse authenticationResponse = JsonSerializer.Deserialize<AuthenticationResponse>(result,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;

        Jwt = authenticationResponse.token;
        ClaimsPrincipal principal = CreateClaimsPrincipal();
        OnAuthStateChanged.Invoke(principal);

        return authenticationResponse;
    }
    


    private ClaimsPrincipal CreateClaimsPrincipal()
    {
        if (string.IsNullOrEmpty(Jwt))
        {
            return new ClaimsPrincipal();
        }

        IEnumerable<Claim> claimsFromJwt = ParseClaimsFromJwt(Jwt);

        ClaimsIdentity identity = new ClaimsIdentity(claimsFromJwt, "jwt");

        ClaimsPrincipal principal = new(identity);
        return principal;
    }

    public Task<ClaimsPrincipal> GetAuthAsync()
    {
        ClaimsPrincipal principal = CreateClaimsPrincipal();
        return Task.FromResult(principal);
    }

    //updating the balance


    public static async Task<string?> GetJwtToken()
    {
        return await Task.FromResult(Jwt);
    }

    private static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        string payload = jwt.Split('.')[1];
        byte[] jsonBytes = ParseBase64WithoutPadding(payload);
        Dictionary<string, object>? keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
        return keyValuePairs!.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()!));
    }

    private static byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2:
                base64 += "==";
                break;
            case 3:
                base64 += "=";
                break;
        }

        return Convert.FromBase64String(base64);
    }

    public Task LogoutAsync()
    {
        Jwt = null;
        ClaimsPrincipal claimsPrincipal = new();
        OnAuthStateChanged.Invoke(claimsPrincipal);
        return Task.CompletedTask;
    }

  

    public void LoadClientWithToken()
    {
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Jwt);
    }
    
}