using NotificationService0032.Data;
using NotificationService0032.Models;
using NotificationService0032.Services.IService;

namespace NotificationService0032.Services
{
    public class Notification0032Service : INotification0032Service
    {
        private readonly NotificationDbContext0032 _db;

        public Notification0032Service(NotificationDbContext0032 db)
        {
            _db = db;
        }

        public Notification0032 CreateNotification(Notification0032 notification)
        {
            notification.Id = Guid.NewGuid().ToString();
            notification.CreatedAt = DateTime.UtcNow;
            _db.Notifications.Add(notification);
            _db.SaveChanges();
            return notification;
        }

        public List<Notification0032> GetAllNotifications()
        {
            return _db.Notifications.ToList();
        }

        public Notification0032 GetNotificationById(string id)
        {
            return _db.Notifications.FirstOrDefault(n => n.Id == id);
        }

        public bool MarkAsRead(string id)
        {
            var notification = _db.Notifications.FirstOrDefault(n => n.Id == id);
            if (notification == null) return false;

            notification.Status = "Read";
            notification.ReadAt = DateTime.UtcNow;
            _db.SaveChanges();
            return true;
        }
    }

    public class NotificationPreference0032Service : INotificationPreference0032Service
    {
        private readonly NotificationDbContext0032 _db;

        public NotificationPreference0032Service(NotificationDbContext0032 db)
        {
            _db = db;
        }

        public NotificationPreference0032 GetPreferencesByUserId(string userId)
        {
            return _db.NotificationPreferences.FirstOrDefault(p => p.UserId == userId);
        }

        public NotificationPreference0032 UpdatePreferences(NotificationPreference0032 preferences)
        {
            var existing = _db.NotificationPreferences.FirstOrDefault(p => p.UserId == preferences.UserId);
            if (existing == null)
            {
                preferences.Id = Guid.NewGuid().ToString();
                preferences.UpdatedAt = DateTime.UtcNow;
                _db.NotificationPreferences.Add(preferences);
            }
            else
            {
                existing.EmailEnabled = preferences.EmailEnabled;
                existing.SmsEnabled = preferences.SmsEnabled;
                existing.PushEnabled = preferences.PushEnabled;
                existing.NotificationTypes = preferences.NotificationTypes;
                existing.UpdatedAt = DateTime.UtcNow;
            }

            _db.SaveChanges();
            return preferences;
        }
    }
}
