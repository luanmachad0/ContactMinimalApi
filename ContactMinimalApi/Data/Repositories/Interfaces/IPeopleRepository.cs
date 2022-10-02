using ContactMinimalApi.Models;

namespace ContactMinimalApi.Data.Repositories.Interfaces
{
    public interface IPeopleRepository
    {
        Task<People> Get(int id);
        Task<IEnumerable<People>> GetAll();
        Task Create(People model);
        Task Update(People model);
        Task Delete(int id);
    }
}
