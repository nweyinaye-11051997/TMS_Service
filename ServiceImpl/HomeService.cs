using TaskManagementSystem.IDao;
using TaskManagementSystem.Models;
using TaskManagementSystem.ServiceInterface;

namespace TaskManagementSystem.ServiceImpl
{
    public class HomeService : ServiceImpl<CountModel>, IHomeService
    {
        private readonly IDao<CountModel> _dao;
        public HomeService(IDao<CountModel> dao) : base(dao)
        {
            this._dao = dao;
        }

        public Task<CountModel> GetTotalCount()
        {
           return _dao.GetTotalCount();
        }

        
    }
}
