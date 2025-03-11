using TaskManagementSystem.Common;
using TaskManagementSystem.IDao;
using TaskManagementSystem.Models;
using TaskManagementSystem.ServiceInterface;

namespace TaskManagementSystem.ServiceImpl
{
    public class ProjectService : ServiceImpl<ProjectEntity>, IProjectService
    {
        private readonly IDao<ProjectEntity> _dao;
        public ProjectService(IDao<ProjectEntity> dao) : base(dao)
        {
            _dao = dao;
        }
        public async Task AddAsync(ProjectEntity entity)
        {
            entity.Id = GeneralUtil.GeneratedKey;
            entity.CreatedDate = DateTime.Now;
            entity.UpdatedDate = DateTime.Now;
            await _dao.AddAsync(entity);
        }
    }
}
