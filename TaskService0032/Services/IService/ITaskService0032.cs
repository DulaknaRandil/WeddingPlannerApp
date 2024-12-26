using TaskService0032.Models;

namespace TaskService0032.Services.IService
{
    public interface ITaskService0032
    {
        Task<Task0032> CreateTaskAsync(Task0032 task);
        Task<List<Task0032>> GetAllTasksAsync();
        Task<Task0032> GetTaskByIdAsync(string id);
        Task<Task0032> UpdateTaskAsync(string id, Task0032 updatedTask);
        Task<bool> DeleteTaskAsync(string id);
        Task<List<TaskCheckList0032>> GetTaskCheckListAsync(string taskId);
        Task<TaskCheckList0032> AddCheckListItemAsync(TaskCheckList0032 item);
        Task<bool> UpdateCheckListItemAsync(string id, TaskCheckList0032 updatedItem);
    }
}
