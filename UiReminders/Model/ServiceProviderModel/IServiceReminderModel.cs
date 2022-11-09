using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UiReminders.Model.ServiceProviderModel
{
    internal interface IServiceReminderModel
    {
        Task<IEnumerable<DayBookModel>> GetDayBooksModel();

        Task<int> AddDayBook(DayBookModel dayBookModel);

        Task<DayBookModel> GetDayBookModel(int id);

        Task DeleteDayBook(int id);

        Task UpdateDayBook(DayBookModel dayBookModel);
    }
}
