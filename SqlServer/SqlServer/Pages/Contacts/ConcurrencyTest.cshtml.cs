using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SqlServer.Data;

namespace SqlServer.Pages.Contacts
{
    public class ConcurrencyTestModel : PageModel
    {
        public void OnGet()
        {
            var context1 = new ContactsDbContext(new DbContextOptionsBuilder<ContactsDbContext>().UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-SqlServer-53bc9b9d-9d6a-45d4-8429-2a2761773502;Trusted_Connection=True;MultipleActiveResultSets=true").Options);
            var contactFromContext1 = context1.Contacts.FirstOrDefault(c => c.Name == "Test");

            if (contactFromContext1 == null)
            {
                contactFromContext1 = new Contact
                                      {
                                          Name = "Test"
                                      };

                context1.Add(contactFromContext1);
                context1.SaveChanges();
            }

            var context2 = new ContactsDbContext(new DbContextOptionsBuilder<ContactsDbContext>().UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-SqlServer-53bc9b9d-9d6a-45d4-8429-2a2761773502;Trusted_Connection=True;MultipleActiveResultSets=true").Options);
            var contactFromContext2 = context2.Contacts.FirstOrDefault(c => c.Name == "Test");

            contactFromContext1.Address = DateTime.Now.ToString();
            contactFromContext2.Address = DateTime.UtcNow.ToString();

            context1.SaveChanges();
            context2.SaveChanges();
        }
    }
}