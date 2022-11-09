using DalReminders.DataObject;

namespace DalReminders.DalReminders
{
    public interface IDalReminders
    {
        /// <summary>
        /// Add remind to scheduler
        /// </summary>
        /// <param name="dayBook"></param>
        Task<int> AddDayBook(DayBook dayBook);

        /// <summary>
        /// remove remind from scheduler
        /// </summary>
        /// <param name="id"></param>
        Task RemoveDayBook(int id);

        /// <summary>
        /// update remind in scheduler
        /// </summary>
        /// <param name="dayBook"></param>
        Task UpdateDayBook(DayBook dayBook);

        /// <summary>
        /// bring one day in list remind scheduler
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<DayBook> GetDayBook(int id);

        /// <summary>
        /// bring all days in list remind scheduler
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<DayBook>> GetAllDayBooks();

        /// <summary>
        /// bring all days in list remind scheduler with check predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<IEnumerable<DayBook>> GetAllDayBooks(Predicate<DayBook> predicate);
    }
}
