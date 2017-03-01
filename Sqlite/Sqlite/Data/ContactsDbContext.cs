using EfSqlite.Models;
using Microsoft.EntityFrameworkCore;

namespace EfSqlite.Data
{
    public sealed class ContactsDbContext : DbContext
    {
        private static bool _created;

        public DbSet<Contact> Contacts { get; set; }

        public ContactsDbContext(DbContextOptions<ContactsDbContext> options)
            : base(options)
        {
            if (_created) return;
            Database.Migrate();
            _created = true;
        }
    }
}
