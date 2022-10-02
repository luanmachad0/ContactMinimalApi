using ContactMinimalApi.Models;

namespace ContactMinimalApi.Data.Repositories.Interfaces
{
    public interface IContactRepository
    {
        Task<List<Contact>> Get(int id);
        Task<IEnumerable<Contact>> GetAll();
        Task Create(Contact model);
        Task Update(Contact model);
        Task Delete(int id);
    }
}
