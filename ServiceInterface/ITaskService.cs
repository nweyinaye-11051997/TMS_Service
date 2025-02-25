using TaskManagementSystem.Models;

namespace TaskManagementSystem.ServiceInterface
{
    public interface ITaskService : IService<TaskEntity>
    {
        Task<TaskEntity?> GetByEmailAsync(string email);
    }
}
