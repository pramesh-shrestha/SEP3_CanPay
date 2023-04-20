using System.Net.Http.Json;
using System.Text.Json;
using Domains.Entity;
using HTTPClients.ClientInterfaces;

namespace HTTPClients.Implementations;

public class CardService : ICardService
{
    private readonly HttpClient client;

    public CardService(HttpClient client)
    {
        this.client = client;
    }

    public async Task<DebitCard> CreateAsync(DebitCard toCreateCard)
    {
        HttpResponseMessage responseMessage = await client.PostAsJsonAsync("card/create", toCreateCard);
        string result = await responseMessage.Content.ReadAsStringAsync();

        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        DebitCard debitCard = JsonSerializer.Deserialize<DebitCard>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return debitCard;
    }

    public Task<DebitCard> FetchCardByUsernameAsync(string username)
    {
        throw new NotImplementedException();
    }

    public Task<DebitCard> UpdateCardAsync(long id, User user)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCardAsync(long id)
    {
        throw new NotImplementedException();
    }
}