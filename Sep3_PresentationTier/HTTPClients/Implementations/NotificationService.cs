using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Domains.Entity;
using HTTPClients.ClientInterfaces;

namespace HTTPClients.Implementations;

/// <summary>
/// Represents a service for managing notifications through HTTP requests.
/// </summary>
public class NotificationService : INotificationService
{
    private readonly HttpClient client;

    /// <summary>
    /// Initializes a new instance of the <see cref="NotificationService"/> class.
    /// </summary>
    /// <param name="client">The HTTP client used for making requests.</param>
    public NotificationService(HttpClient client)
    {
        this.client = client;
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserService.Jwt);
    }

    /// <summary>
    /// Creates a new notification asynchronously.
    /// </summary>
    /// <param name="notificationEntity">The notification entity to create.</param>
    /// <returns>The created notification entity.</returns>
    public async Task<NotificationEntity> CreateNotificationAsync(NotificationEntity notificationEntity)
    {
        HttpResponseMessage responseMessage = await client.PostAsJsonAsync("/notifications", notificationEntity);
        string result = await responseMessage.Content.ReadAsStringAsync();
        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        NotificationEntity entity = JsonSerializer.Deserialize<NotificationEntity>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return entity;
    }

    /// <summary>
    /// Fetches all notifications for a receiver asynchronously.
    /// </summary>
    /// <param name="username">The username of the receiver.</param>
    /// <returns>A collection of notification entities.</returns>
    public async Task<ICollection<NotificationEntity>> FetchAllNotificationsByReceiverAsync(string? username)
    {
        HttpResponseMessage responseMessage = await client.GetAsync($"/notifications/username/{username}");
        string result = await responseMessage.Content.ReadAsStringAsync();

        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        ICollection<NotificationEntity> notificationEntity =
            JsonSerializer.Deserialize<ICollection<NotificationEntity>>(result,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                })!;

        return notificationEntity;
    }

    /// <summary>
    /// Fetches a notification by its ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the notification.</param>
    /// <returns>The notification entity.</returns>
    public async Task<NotificationEntity> FetchNotificationById(long id)
    {
        HttpResponseMessage responseMessage = await client.GetAsync($"/notifications/{id}");
        string result = await responseMessage.Content.ReadAsStringAsync();

        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        NotificationEntity notificationEntity =
            JsonSerializer.Deserialize<NotificationEntity>(result,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                })!;

        return notificationEntity;
    }

    /// <summary>
    /// Marks a notification as read asynchronously.
    /// </summary>
    /// <param name="notificationEntity">The notification entity to mark as read.</param>
    public async Task MarkNotificationAsReadAsync(NotificationEntity? notificationEntity)
    {
        HttpResponseMessage responseMessage =
            await client.PostAsJsonAsync($"/notifications/read", notificationEntity);
        string result = await responseMessage.Content.ReadAsStringAsync();
        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
    }

    /// <summary>
    /// Marks all notifications as read asynchronously.
    /// </summary>
    /// <param name="notificationEntities">The list of notification entities to mark as read.</param>
    public async Task MarkAllNotificationsAsReadAsync(
        List<NotificationEntity>? notificationEntities)
    {
        HttpResponseMessage responseMessage =
            await client.PostAsJsonAsync($"/notifications/read-all", notificationEntities);

        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(responseMessage.Content.ReadAsStringAsync().ToString());
        }
    }
}