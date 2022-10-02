using ContactMinimalApi.Data.Repositories.Interfaces;
using ContactMinimalApi.Infra;
using ContactMinimalApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactMinimalApi.Data.Repositories
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly ContactDbContext _context;

        public PeopleRepository(ContactDbContext context) => _context = context;

        public async Task Create(People model)
        {
            _context.Peoples.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var peopleToDelete = await _context.Peoples.FindAsync(id);

            if (peopleToDelete == null)
                throw new NullReferenceException();

            _context.Peoples.Remove(peopleToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<People> Get(int id) => await _context.Peoples.FindAsync(id);

        public async Task<IEnumerable<People>> GetAll() => await _context.Peoples.ToListAsync();

        public async Task Update(People model)
        {
            var peopleToUpdate = await _context.Peoples.FindAsync(model.Id);

            if (peopleToUpdate == null)
                throw new NullReferenceException();

            peopleToUpdate.Name = model.Name;

            await _context.SaveChangesAsync();
        }
    }
}
