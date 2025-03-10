using TaskManagementSystem.Models;

namespace TaskManagementSystem.ServiceInterface
{
    public interface IHomeService : IService<CountModel>
    {
        Task<CountModel> GetTotalCount();
    }
}
