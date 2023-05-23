using System.Net.Http.Json;
using System.Text.Json;
using Domains.Entity;
using HTTPClients.ClientInterfaces;

namespace HTTPClients.Implementations;

public class BillPaymentService : IBillPaymentService
{
    private readonly HttpClient client;

    public BillPaymentService(HttpClient client)
    {
        this.client = client;
    }
    
    
    
    public async Task<BillPaymentEntity> CreateAsync(BillPaymentEntity billPaymentEntity)
    {
        HttpResponseMessage responseMessage = await client.PostAsJsonAsync("/billPayment/create", billPaymentEntity);
        string result = await responseMessage.Content.ReadAsStringAsync();

        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        BillPaymentEntity billPayment = JsonSerializer.Deserialize<BillPaymentEntity>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return billPayment;
    }

    public async Task<BillPaymentEntity> FetchBillPaymentsById(long id)
    {
        HttpResponseMessage response = await client.GetAsync("/billPayment/{id}}");
        string result = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        BillPaymentEntity billPaymentEntity = JsonSerializer.Deserialize<BillPaymentEntity>(result,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
        return billPaymentEntity;
    }

    
    public async Task<ICollection<BillPaymentEntity>> FetchAllTransactionsInvolvingUser(string? username)
    {
        HttpResponseMessage response = await client.GetAsync("/billPayment/user/{username}");
        string result = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        ICollection<BillPaymentEntity> billPayment = JsonSerializer.Deserialize<ICollection<BillPaymentEntity>>(
            result,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
        
        return billPayment;
    }
}