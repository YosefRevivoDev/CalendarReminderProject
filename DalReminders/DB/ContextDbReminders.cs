using DalReminders.DataObject;
using Microsoft.EntityFrameworkCore;


namespace DalReminders.DB
{
    public class ContextDbReminders : DbContext
    {
        public DbSet<DayBook> DayBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Reminders;Trusted_Connection=True");
        }

    }
}
