using TaskManagementSystem.IDao;
using TaskManagementSystem.Models;
using TaskManagementSystem.ServiceInterface;

namespace TaskManagementSystem.ServiceImpl
{
    public class ServiceImpl<T> : IService<T> where T : class
    {
        private readonly IDao<T> _dao;

        public ServiceImpl(IDao<T> dao)
        {
            _dao = dao;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dao.GetAllAsync();
        }
        public async Task<List<TaskEntity>> GetAllAssignTaskAsync()
        {
            return await _dao.GetAllAssignTaskAsync();
        }
        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dao.GetByIdAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _dao.AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            await _dao.UpdateAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            await _dao.DeleteAsync(id);
        }
    }
}
