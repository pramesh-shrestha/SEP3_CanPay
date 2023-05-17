using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Entity.Model;
using HTTPClients.ClientInterfaces;

namespace HTTPClients.Implementations;

public class RequestService : IRequestService
{
    private HttpClient client;

    public RequestService(HttpClient client)
    {
        this.client = client;
        this.client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", UserService.Jwt);
    }

    public async Task<RequestEntity?> CreateRequestAsync(RequestEntity requestEntity)
    {
        HttpResponseMessage responseMessage = await client.PostAsJsonAsync("/request/create", requestEntity);
        string result = await responseMessage.Content.ReadAsStringAsync();

        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        RequestEntity? createdRequestEntity = JsonSerializer.Deserialize<RequestEntity>(result,
            new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });

        return createdRequestEntity;
    }
}