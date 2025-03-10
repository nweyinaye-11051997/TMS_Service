using TaskManagementSystem.IDao;
using TaskManagementSystem.Models;
using TaskManagementSystem.ServiceInterface;

namespace TaskManagementSystem.ServiceImpl
{
    public class HomeService : ServiceImpl<CountModel>, IHomeService
    {
        private readonly IDao<CountModel> _asigntaskDao;
        public HomeService(IDao<CountModel> assigntaskdao) : base(assigntaskdao)
        {
            this._asigntaskDao = assigntaskdao;
        }

        public Task<CountModel> GetTotalCount()
        {
           return _asigntaskDao.GetTotalCount();
        }

        
    }
}
