namespace MaoNaMassa.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MaoNaMassa.Data.Models;

    public interface INotificationManager
    {
        Task CreateAsync(Notification notification, string userId);

        Task MarkNotificationAsReadAsync(string notificationId);

        Task MarkAllNotificationsAsReadAsync(string userId);

        Task<IEnumerable<T>> GetAllUserNotificationsAsync<T>(string userId);

        int GetNotificationsCount(string userId);
    }
}
