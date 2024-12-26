using Microsoft.EntityFrameworkCore;
using TaskService0032.Data;
using TaskService0032.Models;
using TaskService0032.Services.IService;
using EventBus0032.Interfaces;

using TaskService0032.Messaging.Events;

namespace TaskService0032.Services
{
    public class Task0032Service : ITaskService0032
    {
        private readonly TaskDbContext0032 _context;
        private readonly IEventBus _eventBus;

        public Task0032Service(TaskDbContext0032 context, IEventBus eventBus)
        {
            _context = context;
            _eventBus = eventBus;
        }

        public async Task<Task0032> CreateTaskAsync(Task0032 task)
        {
            task.Id = Guid.NewGuid().ToString();
            task.CreatedAt = DateTime.UtcNow;
            task.UpdatedAt = DateTime.UtcNow;
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            // Publish TaskCreatedEvent
            var taskCreatedEvent = new TaskCreatedEvent
            {
                TaskId = task.Id,
                Title = task.Title,
                DueDate = task.DueDate,
                Priority = task.Priority
            };
            _eventBus.Publish(taskCreatedEvent);

            return task;
        }

        public async Task<List<Task0032>> GetAllTasksAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<Task0032> GetTaskByIdAsync(string id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task<Task0032> UpdateTaskAsync(string id, Task0032 updatedTask)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return null;

            task.Title = updatedTask.Title;
            task.Description = updatedTask.Description;
            task.DueDate = updatedTask.DueDate;
            task.Priority = updatedTask.Priority;
            task.Status = updatedTask.Status;
            task.AssignedTo = updatedTask.AssignedTo;
            task.Category = updatedTask.Category;
            task.IsCompleted = updatedTask.IsCompleted;
            task.CompletedDate = updatedTask.CompletedDate;
            task.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            // Publish TaskUpdatedEvent
            var taskUpdatedEvent = new TaskUpdatedEvent
            {
                TaskId = task.Id,
                Title = task.Title,
                Status = task.Status,
                Priority = task.Priority
            };
            _eventBus.Publish(taskUpdatedEvent);

            return task;
        }

        public async Task<bool> DeleteTaskAsync(string id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return false;

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<TaskCheckList0032>> GetTaskCheckListAsync(string taskId)
        {
            return await _context.TaskCheckLists.Where(c => c.TaskId == taskId).ToListAsync();
        }

        public async Task<TaskCheckList0032> AddCheckListItemAsync(TaskCheckList0032 item)
        {
            item.Id = Guid.NewGuid().ToString();
            _context.TaskCheckLists.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> UpdateCheckListItemAsync(string id, TaskCheckList0032 updatedItem)
        {
            var item = await _context.TaskCheckLists.FindAsync(id);
            if (item == null) return false;

            item.ItemDescription = updatedItem.ItemDescription;
            item.IsCompleted = updatedItem.IsCompleted;
            item.CompletedDate = updatedItem.CompletedDate;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
