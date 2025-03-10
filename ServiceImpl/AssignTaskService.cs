using TaskManagementSystem.Common;
using TaskManagementSystem.IDao;
using TaskManagementSystem.Models;
using TaskManagementSystem.ServiceInterface;

namespace TaskManagementSystem.ServiceImpl
{
    public class AssignTaskService : ServiceImpl<AssignTaskEntity>, IAssignTaskService
    {
        private readonly IDao<AssignTaskEntity> _asigntaskDao;
        public AssignTaskService(IDao<AssignTaskEntity> assigntaskdao) : base(assigntaskdao)
        {
            _asigntaskDao = assigntaskdao;
        }

    
        public async Task UpdateAssignTaskAsync(AssignTaskEntity updatedEntity)
        {
             await _asigntaskDao.UpdateAssignTaskAsync(updatedEntity);
        }
        public async Task AssignTaskAsync(AssignTaskEntity task)
        {
            task.Id = GeneralUtil.GeneratedKey;
            task.CreatedDate = DateTime.Now;
            task.UpdatedDate = DateTime.Now;
            await _asigntaskDao.AddAsync(task);
        }
    }
}
