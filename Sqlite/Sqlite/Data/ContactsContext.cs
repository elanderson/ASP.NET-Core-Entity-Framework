using EfSqlite.Models;
using Microsoft.EntityFrameworkCore;

namespace EfSqlite.Data
{
    public sealed class ContactsContext : DbContext
    {
        private static bool _created;

        public DbSet<Contact> Contacts { get; set; }

        public ContactsContext()
        {

        }

        public ContactsContext(DbContextOptions<ContactsContext> options)
            : base(options)
        {
            if (_created) return;
            Database.Migrate();
            _created = true;
        }
    }
}
