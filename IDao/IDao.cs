using TaskManagementSystem.Models;

namespace TaskManagementSystem.IDao
{
    public interface IDao<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(string id);
        Task<List<TaskEntity>> GetAllAssignTaskAsync();
        Task<List<TaskEntity>> SearchByField(string? TaskName, string? ProjectID, int? Priority, string? Status);
        Task UpdateAssignTaskAsync(AssignTaskEntity updatedEntity);

        Task<CountModel> GetTotalCount();
    }
}
