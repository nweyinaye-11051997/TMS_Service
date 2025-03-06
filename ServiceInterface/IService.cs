using TaskManagementSystem.Models;

namespace TaskManagementSystem.ServiceInterface
{
    public interface IService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(string id);

        Task<List<TaskEntity>> GetAllAssignTaskAsync();
    }
}
