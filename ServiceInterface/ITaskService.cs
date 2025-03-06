using TaskManagementSystem.Models;

namespace TaskManagementSystem.ServiceInterface
{
    public interface ITaskService : IService<TaskEntity>
    {
        Task<TaskEntity?> GetByEmailAsync(string email);

        Task AssignTaskAsync(AssignTaskEntity task);

        Task<List<TaskEntity>> SearchByField(string? TaskName, string? ProjectID, int? Priority, string? Status);
    }
}
