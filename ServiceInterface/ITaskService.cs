using TaskManagementSystem.Models;

namespace TaskManagementSystem.ServiceInterface
{
    public interface ITaskService : IService<TaskEntity>
    {

        Task<List<TaskEntity>> GetAllAssignTaskAsync();
        Task<List<TaskEntity>> SearchByField(string? TaskName, string? ProjectID, int? Priority, string? Status);
    }
}
