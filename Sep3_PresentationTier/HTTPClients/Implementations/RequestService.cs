using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Entity.Model;
using HTTPClients.ClientInterfaces;

namespace HTTPClients.Implementations;

public class RequestService : IRequestService
{
    private readonly HttpClient client;

    /// <summary>
    /// Initializes a new instance of the <see cref="RequestService"/> class with the specified <see cref="HttpClient"/>.
    /// </summary>
    /// <param name="client">The HTTP client used to make requests.</param>
    public RequestService(HttpClient client)
    {
        this.client = client;
        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", UserService.Jwt);
    }

    /// <summary>
    /// Creates a new request asynchronously.
    /// </summary>
    /// <param name="requestEntity">The request entity to create.</param>
    /// <returns>The created request entity.</returns>
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

    /// <summary>
    /// Updates an existing request asynchronously.
    /// </summary>
    /// <param name="requestEntity">The request entity to update.</param>
    /// <returns>The updated request entity.</returns>
    public async Task<RequestEntity?> UpdateRequestAsync(RequestEntity requestEntity)
    {
        HttpResponseMessage responseMessage = await client.PostAsJsonAsync("/request/update", requestEntity);
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

    /// <summary>
    /// Fetches a request by its ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the request.</param>
    /// <returns>The request entity.</returns>
    public async Task<RequestEntity> FetchRequestById(long id)
    {
        HttpResponseMessage responseMessage = await client.GetAsync($"/request/id/{id}");
        string result = await responseMessage.Content.ReadAsStringAsync();

        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        RequestEntity? createdRequestEntity = JsonSerializer.Deserialize<RequestEntity>(result,
            new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            })!;

        return createdRequestEntity;
    }
}