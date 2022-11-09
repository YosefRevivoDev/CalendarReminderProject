using DalReminders.DataObject;
using Microsoft.EntityFrameworkCore;


namespace DalReminders.DB
{
    internal class ContextDbReminders : DbContext
    {
        //IServiceProvider
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Reminders;Trusted_Connection=True");
        }

        public DbSet<DayBook> DayBooks { get; set; }
    }
}
