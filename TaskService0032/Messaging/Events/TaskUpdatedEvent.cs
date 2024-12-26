using EventBus0032.Events;

namespace TaskService0032.Messaging.Events
{
    public class TaskUpdatedEvent : IntegrationEvent
    {
        public string TaskId { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
    }
}
