using NotificationService0032.Models;

namespace NotificationService0032.Services.IService
{
    public interface INotification0032Service
    {
        Notification0032 CreateNotification(Notification0032 notification);
        List<Notification0032> GetAllNotifications();
        Notification0032 GetNotificationById(string id);
        bool MarkAsRead(string id);
    }

    public interface INotificationPreference0032Service
    {
        NotificationPreference0032 GetPreferencesByUserId(string userId);
        NotificationPreference0032 UpdatePreferences(NotificationPreference0032 preferences);
    }
}
