using DalReminders.DataObject;
using DalReminders.DB;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace DalReminders.DalReminders
{

    public class DalReminders : IDalReminders
    {
        /// <summary>
        /// for connect to DB
        /// </summary>
        private ContextDbReminders contextDbReminders = new ContextDbReminders();

        public DalReminders() { }

        private async Task<int> SaveChanges()
        {
            return await contextDbReminders.SaveChangesAsync();
        }

        /// <summary>
        /// Add remind to scheduler
        /// </summary>
        /// <param name="dayBook"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<int> AddDayBook(DayBook dayBook)
        {
            await contextDbReminders.DayBooks.AddAsync(dayBook);

            if(await SaveChanges() == -1)
            {
                throw new Exception("Wrong saves, Please choose again");
            }

            return dayBook.Id;  
        }

        /// <summary>
        /// bring all days in list remind scheduler
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DayBook>> GetAllDayBooks()
        {
            return await contextDbReminders.DayBooks.ToListAsync();
        }

        /// <summary>
        /// bring all days in list remind scheduler with check predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<IEnumerable<DayBook>> GetAllDayBooks(Predicate<DayBook> predicate)
        {
            IEnumerable<DayBook> dayBooks = await GetAllDayBooks();

            return dayBooks.Where(dayBook => predicate(dayBook));
        }

        /// <summary>
        /// bring one day in list remind scheduler
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DayBook> GetDayBook(int id)
        {
            return await contextDbReminders.DayBooks.FirstAsync(dayBook => dayBook.Id == id);
        }

        /// <summary>
        /// remove remind from scheduler
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task RemoveDayBook(int id)
        {
            contextDbReminders.DayBooks.Remove(await GetDayBook(id));

            if (await SaveChanges() == -1)
            {
                throw new Exception("ERROR Remove from DB, Please try again");
            }
        }

        /// <summary>
        /// update remind in scheduler
        /// </summary>
        /// <param name="dayBook"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task UpdateDayBook(DayBook dayBook)
        {
            DayBook oldDayBook = await GetDayBook(dayBook.Id);
            oldDayBook.DateMessage = dayBook.DateMessage;
            oldDayBook.Message = dayBook.Message;

            if (await SaveChanges() == -1)
            {
                throw new Exception("ERROR Update, Please try again");
            }
        }
    }
}



//Random random = new Random();

//for (DateTime startDate = DateTime.Now.AddMonths(-3);
//    startDate < DateTime.Now; startDate = startDate.AddDays(random.Next(1, 4)))
//{
//    contextDbReminders.Add(new DayBook(startDate, startDate.ToString()));

//}
//contextDbReminders.SaveChanges();