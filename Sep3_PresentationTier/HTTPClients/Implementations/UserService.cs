using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Json;
using Domains.Entity;
using HTTPClients.Auth;
using HTTPClients.ClientInterfaces;

namespace HTTPClients.Implementations;

using Domains;

/// <summary>
/// Service implementation for managing user-related operations.
/// </summary>
public class UserService : IUserService
{
    private readonly HttpClient client;

    // Action to be invoked when the authentication state changes.
    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; } = null!;
    public static string? Jwt { get; private set; } = "";

    /// <summary>
    /// Creates a new instance of the UserService class.
    /// </summary>
    /// <param name="client">The HttpClient instance.</param>
    public UserService(HttpClient client)
    {
        this.client = client;
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Jwt);
    }

    /// <summary>
    /// Creates a new user asynchronously.
    /// </summary>
    /// <param name="toCreateUserEntity">The user entity to create.</param>
    /// <returns>The created user entity.</returns>
    public async Task<UserEntity> CreateAsync(UserEntity toCreateUserEntity)
    {
        HttpResponseMessage responseMessage = await client.PostAsJsonAsync("/users", toCreateUserEntity);
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

    /// <summary>
    /// Fetches all users asynchronously.
    /// </summary>
    /// <returns>A collection of user entities.</returns>
    public async Task<IEnumerable<UserEntity?>> FetchAllUsersAsync()
    {
        HttpResponseMessage responseMessage = await client.GetAsync("/users");
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

    /// <summary>
    /// Fetches a user by username asynchronously.
    /// </summary>
    /// <param name="username">The username of the user.</param>
    /// <returns>The user entity.</returns>
    public async Task<UserEntity> FetchUserByUsernameAsync(string? username)
    {
        HttpResponseMessage responseMessage = await client.GetAsync($"/users/{username}");
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


    /// <summary>
    /// Updates a user asynchronously.
    /// </summary>
    /// <param name="userEntity">The updated user entity.</param>
    /// <returns>The updated user entity.</returns>
    public async Task<UserEntity> UpdateUserAsync(UserEntity userEntity)
    {
        HttpResponseMessage response = await client.PutAsJsonAsync("/users", userEntity);
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


    /// <summary>
    /// Validates a user's credentials.
    /// </summary>
    /// <param name="username">The username of the user.</param>
    /// <param name="password">The password of the user.</param>
    /// <returns>The authentication response.</returns>
    public async Task<AuthenticationResponse> ValidateUser(string username, string password)
    {
        LoginDto loginDto = new LoginDto
        {
            Username = username,
            Password = password
        };

        HttpResponseMessage responseMessage = await client.PostAsJsonAsync("/users/authenticate", loginDto);
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

    /// <summary>
    /// Gets the authentication principal.
    /// </summary>
    /// <returns>The authentication principal.</returns>
    public Task<ClaimsPrincipal> GetAuthAsync()
    {
        ClaimsPrincipal principal = CreateClaimsPrincipal();
        return Task.FromResult(principal);
    }


    /// <summary>
    /// Parses the claims from a JWT token's payload.
    /// </summary>
    /// <param name="jwt">The JWT token.</param>
    /// <returns>An enumerable collection of claims.</returns>
    private static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        string payload = jwt.Split('.')[1];
        byte[] jsonBytes = ParseBase64WithoutPadding(payload);
        Dictionary<string, object>? keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
        return keyValuePairs!.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()!));
    }

    /// <summary>
    /// Parses a Base64 string without padding into a byte array.
    /// </summary>
    /// <param name="base64">The Base64 string.</param>
    /// <returns>The byte array representation of the Base64 string.</returns>
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

    /// <summary>
    /// Logs out the user.
    /// </summary>
    /// <returns>A task representing the logout operation.</returns>
    public Task LogoutAsync()
    {
        Jwt = null;
        ClaimsPrincipal claimsPrincipal = new();
        OnAuthStateChanged.Invoke(claimsPrincipal);
        return Task.CompletedTask;
    }
}