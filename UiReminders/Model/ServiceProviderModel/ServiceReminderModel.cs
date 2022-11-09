using DalReminders.DataObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UiReminders.Model.ServiceProviderModel
{
    internal class ServiceReminderModel : IServiceReminderModel
    {
        private DalReminders.DalReminders.IDalReminders dalReminders = new DalReminders.DalReminders.DalReminders();

        public async Task<int> AddDayBook(DayBookModel dayBookModel)
        {
             return await dalReminders.AddDayBook(ConvertDayBookModelToDayBook(dayBookModel));
        }

        public async Task<DayBookModel> GetDayBookModel(int id)
        {
            return ConvertDayBookToDayBookModel(await dalReminders.GetDayBook(id));
        }

        /// <summary>
        /// Bring all reminder days from DB after convert
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DayBookModel>> GetDayBooksModel()
        {
            List<DayBookModel> dayBooksModel = new List<DayBookModel>();
            
            IEnumerable<DayBook> dayBooks = await dalReminders.GetAllDayBooks();

            foreach (DayBook dayBook in dayBooks)
            {
                dayBooksModel.Add(ConvertDayBookToDayBookModel(dayBook));
            }

            return dayBooksModel;
        }

        private DayBookModel ConvertDayBookToDayBookModel(DayBook dayBook)
        {
            return new DayBookModel(dayBook.Id, dayBook.DateMessage, dayBook.Message);
        }

        private DayBook ConvertDayBookModelToDayBook(DayBookModel dayBookModel)
        {
            return new DayBook(dayBookModel.DateMessage, dayBookModel.Message);
        }

        public async Task DeleteDayBook(int id)
        {
           await dalReminders.RemoveDayBook(id); 
        }

        public async Task UpdateDayBook(DayBookModel dayBookModel)
        {
            DayBook dayBook = ConvertDayBookModelToDayBook(dayBookModel);
            dayBook.Id = dayBookModel.Id;
            await dalReminders.UpdateDayBook(dayBook);
        }
    }
}
