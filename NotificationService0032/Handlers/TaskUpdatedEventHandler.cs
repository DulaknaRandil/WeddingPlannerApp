using EventBus0032.Interfaces;
using TaskService0032.Messaging.Events;

namespace NotificationService0032.Handlers
{
    public class TaskUpdatedEventHandler : IEventHandler<TaskUpdatedEvent>
    {
        public Task Handle(TaskUpdatedEvent @event)
        {
            Console.WriteLine($"[NotificationService] Task Updated: {@event.Title}, Status: {@event.Status}");
            // Implement notification logic
            return Task.CompletedTask;
        }
    }
}
