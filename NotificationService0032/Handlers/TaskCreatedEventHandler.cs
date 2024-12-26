using EventBus0032.Interfaces;
using TaskService0032.Messaging.Events;

namespace NotificationService0032.Handlers
{
    public class TaskCreatedEventHandler : IEventHandler<TaskCreatedEvent>
    {
        public Task Handle(TaskCreatedEvent @event)
        {
            Console.WriteLine($"[NotificationService] Task Created: {@event.Title}, Due: {@event.DueDate}");
            // Implement notification logic
            return Task.CompletedTask;
        }
    }
}
