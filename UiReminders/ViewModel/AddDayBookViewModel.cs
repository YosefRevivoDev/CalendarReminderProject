using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UiReminders.Command;

namespace UiReminders.ViewModel
{
    internal class AddDayBookViewModel : BaseViewModel
    {
        private CalendarViewModel calendarViewModel;

        private MainViewModel mainViewModel;

        public ICommand AddCommand { get; set; }

        public ICommand CancelCommand { get; set; }

        public DateTime DateMessage { get; set; }

        public string Message { get; set; }

        public AddDayBookViewModel(CalendarViewModel calendarViewModel, MainViewModel mainViewModel)
        {
            this.calendarViewModel = calendarViewModel;
            this.mainViewModel = mainViewModel;
            DateMessage = calendarViewModel.SelectedDate;
            AddCommand = new GeneralCommand(AddDayBook);
            CancelCommand = new GeneralCommand(async (obj) => await ReturnToPrevWindow());
        }

        private async Task ReturnToPrevWindow()
        {
            await Task.Run(() => mainViewModel.NavigationStore = calendarViewModel);
        }

        private async Task AddDayBook(object obj)
        {
            try
            {
                int id = await calendarViewModel.remindersModel.AddDayBookModel(new Model.DayBookModel(DateMessage, Message));
                await calendarViewModel.AddDayBookToDayBooksViewModel(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
