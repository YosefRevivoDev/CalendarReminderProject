using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiReminders.Model.ServiceProviderModel;

namespace UiReminders.Model
{
    public class RemindersModel
    {
        private IServiceReminderModel serviceReminderModel = new ServiceReminderModel();

        internal IEnumerable<DayBookModel> dayBooksModel;

        public async Task initDayBooksModel()
        {
            dayBooksModel = await serviceReminderModel.GetDayBooksModel();
        }

        public async Task<int> AddDayBookModel(DayBookModel newDayBookModel)
        {
            return await serviceReminderModel.AddDayBook(newDayBookModel);
        }

        public async Task<DayBookModel> GetDayBookModel(int id)
        {
            return await serviceReminderModel.GetDayBookModel(id);
        }

        internal async Task DeleteDayBookModel(int id)
        {
            await serviceReminderModel.DeleteDayBook(id);
        }

        internal async Task UpdateDayBookModel(DayBookModel dayBookModel)
        {
            await serviceReminderModel.UpdateDayBook(dayBookModel);
        }
    }
}
