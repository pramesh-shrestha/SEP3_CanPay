using System.Net.Http.Json;
using System.Text.Json;
using Domains.Entity;
using HTTPClients.ClientInterfaces;

namespace HTTPClients.Implementations;

/// <summary>
/// Represents a service for managing bill payments.
/// </summary>
public class BillPaymentService : IBillPaymentService
{
    private readonly HttpClient client;

    /// <summary>
    /// Initializes a new instance of the <see cref="BillPaymentService"/> class.
    /// </summary>
    /// <param name="client">The HttpClient instance used for making HTTP requests.</param>
    public BillPaymentService(HttpClient client)
    {
        this.client = client;
    }

    /// <summary>
    /// Creates a new bill payment.
    /// </summary>
    /// <param name="billPaymentEntity">The bill payment entity to create.</param>
    /// <returns>The created bill payment entity.</returns>
    public async Task<BillPaymentEntity> CreateAsync(BillPaymentEntity? billPaymentEntity)
    {
        HttpResponseMessage responseMessage = await client.PostAsJsonAsync("/billPayments", billPaymentEntity);
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


    /// <summary>
    /// Fetches all transactions involving a specific user.
    /// </summary>
    /// <param name="username">The username of the user.</param>
    /// <returns>A collection of bill payment entities involving the user.</returns>
    public async Task<ICollection<BillPaymentEntity>> FetchAllTransactionsInvolvingUser(string? username)
    {
        HttpResponseMessage response = await client.GetAsync($"/billPayments/{username}");
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