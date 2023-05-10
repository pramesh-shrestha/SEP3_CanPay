using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Domains.Entity;
using HTTPClients.ClientInterfaces;

namespace HTTPClients.Implementations;

public class NotificationService : INotificationService
{
    
    private readonly HttpClient client;

    public NotificationService(HttpClient client)
    {
        this.client = client;
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserService.Jwt);
    }

    public async Task<NotificationEntity> CreateNotificationAsync(NotificationEntity notificationEntity)
    {
        HttpResponseMessage responseMessage = await client.PostAsJsonAsync("/notification/create", notificationEntity);
        string result = await responseMessage.Content.ReadAsStringAsync();
        if (!responseMessage.IsSuccessStatusCode)
        {
            Console.WriteLine(responseMessage);
            throw new Exception(result);
        }

        NotificationEntity entity = JsonSerializer.Deserialize<NotificationEntity>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return entity;
    }

    public async Task<ICollection<NotificationEntity>> FetchAllNotificationsByReceiverAsync(string? username)
    {
        HttpResponseMessage responseMessage = await client.GetAsync($"/notification/receiver/{username}");
        string result = await responseMessage.Content.ReadAsStringAsync();

        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        ICollection<NotificationEntity> notificationEntity = JsonSerializer.Deserialize<ICollection<NotificationEntity>>(result,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;

        return notificationEntity;
    }

    // public async Task MarkNotificationAsReadAsync(NotificationEntity notificationEntity)
    // {
    //     HttpResponseMessage responseMessage =
    //         await client.PutAsJsonAsync($"/notifications/markAsRead/{notificationEntity}", notificationEntity);
    //     string result = await responseMessage.Content.ReadAsStringAsync();
    //     if (!responseMessage.IsSuccessStatusCode)
    //     {
    //         throw new Exception(result);
    //     }
    // }
    //
    // public async Task MarkAllNotificationsAsReadAsync(List<NotificationEntity> notificationEntities)
    // {
    //     HttpResponseMessage responseMessage= await client.PutAsJsonAsync($"/notifications/markAllAsRead/{receivingUsername}")
    // }

    public Task<bool> DeleteNotificationAsync(long notificationId)  
    {
        throw new NotImplementedException();
    }
    
   
}