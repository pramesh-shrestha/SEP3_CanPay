using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Domains.Entity;
using HTTPClients.ClientInterfaces;

namespace HTTPClients.Implementations;

public class TransactionService : ITransactionService
{
    private readonly HttpClient client;
    public string? Jwt { get; set; }


    public TransactionService(HttpClient client)
    {
        this.client = client;
        LoadClientWithToken();
    }

    public async Task<TransactionEntity> CreateTransactionAsync(TransactionEntity transactionEntity)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/transaction/create", transactionEntity);
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

        Console.WriteLine(entity.TransactionId.GetTypeCode());

        return entity;
    }

    public async Task<TransactionEntity> FetchTransactionByIdAsync(long id)
    {
        HttpResponseMessage response = await client.GetAsync($"/transaction/{id}");
        string result = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        TransactionEntity transactionEntity = JsonSerializer.Deserialize<TransactionEntity>(result,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
        return transactionEntity;
    }

    public async Task<TransactionEntity> FetchAllTransactionBySenderAsync(string username)
    {
        HttpResponseMessage response = await client.GetAsync($"/transaction/sender/{username}");
        string result = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        TransactionEntity transactionEntity = JsonSerializer.Deserialize<TransactionEntity>(result,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
        return transactionEntity;
    }

    public async Task<TransactionEntity> FetchAllTransactionByReceiverAsync(string username)
    {
        HttpResponseMessage response = await client.GetAsync($"/transaction/receiver/{username}");
        string result = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        TransactionEntity transactionEntity = JsonSerializer.Deserialize<TransactionEntity>(result,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
        return transactionEntity;
    }

    public async Task<TransactionEntity> FetchAllTransactionInvolvingBothUsersAsync(string username)
    {
        HttpResponseMessage response = await client.GetAsync($"/transaction/{username}");
        string result = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        TransactionEntity transactionEntity = JsonSerializer.Deserialize<TransactionEntity>(result,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
        return transactionEntity;
    }

    public async Task<TransactionEntity> FetchTransactionByDateAsync(string date)
    {
        HttpResponseMessage response = await client.GetAsync($"/transaction/date/{date}");
        string result = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        TransactionEntity transactionEntity = JsonSerializer.Deserialize<TransactionEntity>(result,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
        return transactionEntity;
    }

    public async Task DeleteTransactionAsync(long id)
    {
        HttpResponseMessage response = await client.DeleteAsync($"/transaction/delete/{id}");

        if (!response.IsSuccessStatusCode)
        {
            string result = await response.Content.ReadAsStringAsync();
            throw new Exception(result);
        }
    }

    private async void LoadClientWithToken()
    {
        Jwt = await UserService.GetJwtToken();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Jwt);
    }
}