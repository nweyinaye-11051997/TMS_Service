using TaskManagementSystem.IDao;
using TaskManagementSystem.Models;
using TaskManagementSystem.ServiceInterface;

namespace TaskManagementSystem.ServiceImpl
{
    public class TaskService : ServiceImpl<TaskEntity>, ITaskService
    {
        private readonly IDao<TaskEntity> _taskDao;
        public TaskService(IDao<TaskEntity> dao) : base(dao)
        {
            _taskDao = dao;
        }

        public async Task<IEnumerable<TaskEntity>> GetAllAsync()
        {
            return await _taskDao.GetAllAsync();
        }

        public async Task<TaskEntity> GetByIdAsync(int id)
        {
            return await _taskDao.GetByIdAsync(id);
        }

        public async Task AddAsync(TaskEntity entity)
        {
            await _taskDao.AddAsync(entity);
        }

        public async Task UpdateAsync(TaskEntity entity)
        {
            await _taskDao.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _taskDao.DeleteAsync(id);
        }

        public Task<TaskEntity?> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}
