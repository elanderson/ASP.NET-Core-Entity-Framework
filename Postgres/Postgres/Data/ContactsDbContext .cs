using Microsoft.EntityFrameworkCore;

namespace Postgres.Data
{
    public class ContactsDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public ContactsDbContext(DbContextOptions<ContactsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().ForNpgsqlUseXminAsConcurrencyToken();

            base.OnModelCreating(modelBuilder);
        }
    }
}