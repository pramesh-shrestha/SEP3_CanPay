using System.Net.Http.Json;
using System.Text.Json;
using Domains.Entity;
using HTTPClients.ClientInterfaces;

namespace HTTPClients.Implementations;

public class CardService : ICardService
{
    private readonly HttpClient client;

    /// <summary>
    /// Initializes a new instance of the <see cref="CardService"/> class with the specified <see cref="HttpClient"/>.
    /// </summary>
    /// <param name="client">The HTTP client used to make requests.</param>
    public CardService(HttpClient client)
    {
        this.client = client;
    }


    /// <summary>
    /// Creates a new debit card asynchronously.
    /// </summary>
    /// <param name="toCreateCardEntity">The debit card entity to create.</param>
    /// <returns>The created debit card entity.</returns>
    public async Task<DebitCardEntity> CreateAsync(DebitCardEntity toCreateCardEntity)
    {
        HttpResponseMessage responseMessage = await client.PostAsJsonAsync("cards", toCreateCardEntity);
        string result = await responseMessage.Content.ReadAsStringAsync();

        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        DebitCardEntity debitCardEntity = JsonSerializer.Deserialize<DebitCardEntity>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return debitCardEntity;
    }
}