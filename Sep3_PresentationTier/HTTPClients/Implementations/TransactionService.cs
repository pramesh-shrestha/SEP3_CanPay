using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Domains.Entity;
using HTTPClients.ClientInterfaces;

namespace HTTPClients.Implementations;

public class TransactionService : ITransactionService
{
    private readonly HttpClient client;

    /// <summary>
    /// Initializes a new instance of the <see cref="TransactionService"/> class with the specified <see cref="HttpClient"/>.
    /// </summary>
    /// <param name="client">The HTTP client used to make requests.</param>
    public TransactionService(HttpClient client)
    {
        this.client = client;
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserService.Jwt);
    }

    /// <summary>
    /// Creates a new transaction asynchronously.
    /// </summary>
    /// <param name="transactionEntity">The transaction entity to create.</param>
    /// <returns>The created transaction entity.</returns>
    public async Task<TransactionEntity> CreateTransactionAsync(TransactionEntity transactionEntity)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/transactions", transactionEntity);
        string result = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        TransactionEntity entity = JsonSerializer.Deserialize<TransactionEntity>(result,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;


        return entity;
    }


    /// <summary>
    /// Fetches all transactions involving a user asynchronously.
    /// </summary>
    /// <param name="username">The username of the user.</param>
    /// <returns>A collection of transaction entities.</returns>
    public async Task<ICollection<TransactionEntity>> FetchAllTransactionInvolvingUserAsync(string? username)
    {
        HttpResponseMessage response = await client.GetAsync($"/transactions/{username}");
        string result = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        ICollection<TransactionEntity> transactionEntity = JsonSerializer.Deserialize<ICollection<TransactionEntity>>(
            result,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;

        return transactionEntity;
    }
}