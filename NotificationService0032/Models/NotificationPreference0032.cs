namespace NotificationService0032.Models
{
    public class NotificationPreference0032
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public bool EmailEnabled { get; set; }
        public bool SmsEnabled { get; set; }
        public bool PushEnabled { get; set; }
        public List<string> NotificationTypes { get; set; } // Types of notifications to receive
        public DateTime UpdatedAt { get; set; }
    }
}
