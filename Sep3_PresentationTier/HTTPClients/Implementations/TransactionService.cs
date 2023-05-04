using System.Net.Http.Json;
using System.Text.Json;
using Domains.Entity;
using HTTPClients.ClientInterfaces;

namespace HTTPClients.Implementations;

public class TransactionService : ITransactionService {

    private HttpClient client;

    public TransactionService(HttpClient client) {
        this.client = client;
    }

    public async Task<TransactionEntity> CreateTransactionAsync(TransactionEntity transactionEntity) {
        HttpResponseMessage response = await client.PatchAsJsonAsync("/transaction/create", transactionEntity);
        string result = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode) {
            throw new Exception(result);
        }

        TransactionEntity entity = JsonSerializer.Deserialize<TransactionEntity>(result,
            new JsonSerializerOptions {
                PropertyNameCaseInsensitive = true
            })!;
        return entity;
    }

    public Task<TransactionEntity> FetchTransactionByIdAsync(long id) {
        throw new NotImplementedException();
    }

    public Task<TransactionEntity> FetchAllTransactionBySender(string username) {
        throw new NotImplementedException();
    }

    public Task<TransactionEntity> FetchAllTransactionByReceiver(string username) {
        throw new NotImplementedException();
    }

    public Task<TransactionEntity> FetchAllTransactionInvolvingBothUsers(string username) {
        throw new NotImplementedException();
    }
}