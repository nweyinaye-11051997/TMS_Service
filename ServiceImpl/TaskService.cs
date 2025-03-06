using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Common;
using TaskManagementSystem.IDao;
using TaskManagementSystem.Models;
using TaskManagementSystem.ServiceInterface;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TaskManagementSystem.ServiceImpl
{
    public class TaskService : ServiceImpl<TaskEntity>, ITaskService
    {
        private readonly IDao<TaskEntity> _taskDao;
        private readonly IDao<AssignTaskEntity> _asigntaskDao;
        public TaskService(IDao<TaskEntity> dao, IDao<AssignTaskEntity> assigntaskdao) : base(dao)
        {
            _taskDao = dao;
            _asigntaskDao = assigntaskdao;
        }

        public async Task<IEnumerable<TaskEntity>> GetAllAsync()
        {
            return await _taskDao.GetAllAsync();
     
        }
        public async Task<List<TaskEntity>> SearchByField(string? TaskName, string? ProjectID, int? Priority, string? Status)
        {

            return await _taskDao.SearchByField(TaskName,ProjectID,Priority,Status);
        }

        public async Task<TaskEntity> GetByIdAsync(int id)
        {
            return await _taskDao.GetByIdAsync(id);
        }

        public async Task AddAsync(TaskEntity entity)
        {
            entity.Id = GeneralUtil.GeneratedKey;
            entity.CreatedDate = DateTime.Now;
            entity.UpdatedDate = DateTime.Now;
            await _taskDao.AddAsync(entity);
        }

        public async Task UpdateAsync(TaskEntity entity)
        {
            await _taskDao.UpdateAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            await _taskDao.DeleteAsync(id);
        }

        public Task<TaskEntity?> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task AssignTaskAsync(AssignTaskEntity task)
        {
            task.Id = GeneralUtil.GeneratedKey;
            task.CreatedDate = DateTime.Now;
            task.UpdatedDate = DateTime.Now;
            await _asigntaskDao.AddAsync(task);
        }

        public async Task<List<TaskEntity>> GetAllAssignTaskAsync()
        {
           return await _asigntaskDao.GetAllAssignTaskAsync();
        }

        Task<TaskEntity?> ITaskService.GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        
       
    }
}
