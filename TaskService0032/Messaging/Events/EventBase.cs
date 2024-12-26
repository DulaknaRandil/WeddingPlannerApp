namespace TaskService0032.Messaging.Events
{
    public abstract class EventBase
    {
        public string EventId { get; set; } = Guid.NewGuid().ToString();
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string EventType { get; set; }
    }
}
