using ContactMinimalApi.Data.Repositories.Interfaces;
using ContactMinimalApi.Infra;
using ContactMinimalApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactMinimalApi.Data.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactDbContext _context;

        public ContactRepository(ContactDbContext context) => _context = context;

        public async Task Create(Contact model)
        {
            _context.Contacts.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var contactToDelete = await _context.Contacts.FindAsync(id);

            if (contactToDelete == null)
                throw new NullReferenceException();

            _context.Contacts.Remove(contactToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Contact>> Get(int id) => await _context.Contacts.Where(c => c.PeopleId == id).ToListAsync();

        public async Task<IEnumerable<Contact>> GetAll() => await _context.Contacts.ToListAsync();

        public async Task Update(Contact model)
        {
            var contactToUpdate = await _context.Contacts.FindAsync(model.Id);

            if (contactToUpdate == null)
                throw new NullReferenceException();

            contactToUpdate.Name = model.Name;

            await _context.SaveChangesAsync();
        }
    }
}
