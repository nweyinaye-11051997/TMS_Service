
using TaskManagementSystem.Common;
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

        public async Task<List<TaskEntity>> SearchByField(string? TaskName, string? ProjectID, int? Priority, string? Status)
        {

            return await _taskDao.SearchByField(TaskName,ProjectID,Priority,Status);
        }

       
        public async Task AddAsync(TaskEntity entity)
        {
            entity.Id = GeneralUtil.GeneratedKey;
            entity.CreatedDate = DateTime.Now;
            entity.UpdatedDate = DateTime.Now;
            await _taskDao.AddAsync(entity);
        }

        public async Task<List<TaskEntity>> GetAllAssignTaskAsync()
        {
           return await _taskDao.GetAllAssignTaskAsync();
        }


    }
}
