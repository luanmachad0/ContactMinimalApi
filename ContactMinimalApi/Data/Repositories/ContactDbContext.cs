using ContactMinimalApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactMinimalApi.Infra
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options)
            : base(options) { }

        public DbSet<People> Peoples => Set<People>();
        public DbSet<Contact> Contacts => Set<Contact>();
    }
}
