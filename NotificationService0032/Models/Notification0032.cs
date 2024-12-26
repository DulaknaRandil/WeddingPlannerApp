namespace NotificationService0032.Models
{
    public class Notification0032
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string EventId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Type { get; set; } // Task, RSVP, Vendor, Budget, etc.
        public string Priority { get; set; } // High, Medium, Low
        public string Status { get; set; } // Sent, Failed, Read
        public DateTime? ReadAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? SentAt { get; set; }
    }
}
