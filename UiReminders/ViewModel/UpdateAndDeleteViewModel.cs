using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UiReminders.Command;
using UiReminders.Model;

namespace UiReminders.ViewModel
{
    internal class UpdateAndDeleteViewModel : BaseViewModel
    {
        private CalendarViewModel calendarViewModel;

        private MainViewModel mainViewModel;

        public DayBookViewModel dayBookViewModel;

        public ICommand DeleteDayBookCommand { get; set; }

        public ICommand UpdateDayBookCommand { get; set; }

        public ICommand CancelCommand { get; set; }

        public UpdateAndDeleteViewModel(CalendarViewModel calendarViewModel, MainViewModel mainViewModel, DayBookViewModel dayBookViewModel)
        {
            this.calendarViewModel = calendarViewModel;
            this.mainViewModel = mainViewModel;
            this.dayBookViewModel = dayBookViewModel;

            if (dayBookViewModel is not null)
            {
                DeleteDayBookCommand = new GeneralCommand(async (obj) => await DeleteDayBook());
                UpdateDayBookCommand = new GeneralCommand(async (obj) => await UpdateDayBook());
            }
           
            CancelCommand = new GeneralCommand(async (obj) => await ReturnToPrevWindow());
        }

        private async Task UpdateDayBook()
        {
            try
            {
                await calendarViewModel.remindersModel.UpdateDayBookModel(dayBookViewModel.DayBookModel);
                MessageBox.Show("Success update reminder");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task DeleteDayBook()
        {
                try
                {
                    await calendarViewModel.remindersModel.DeleteDayBookModel(dayBookViewModel.Id);
                    calendarViewModel.DayBooksViewModel.Remove(dayBookViewModel);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        /// <summary>
        /// This method will generate a time signature for the text
        /// that will be entered on the indicated day
        /// </summary>
        public DateTime DateMessage
        {
            get { return dayBookViewModel.DateMessage; }

            set
            {
                dayBookViewModel.DateMessage = value;
                dayBookViewModel.DayBookModel.DateMessage = value; 
                OnPropertyChanged(nameof(DateMessage));
            }
        }

        /// <summary>
        /// This method will represent the string that will
        /// be entered for a specified day
        /// </summary>

        public string Message
        {
            get { return dayBookViewModel.Message; }

            set
            {
                dayBookViewModel.Message = value;
                dayBookViewModel.DayBookModel.Message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        /// <summary>
        /// For a get preview window
        /// </summary>
        /// <returns></returns>
        private async Task ReturnToPrevWindow()
        {
            await Task.Run(() => mainViewModel.NavigationStore = calendarViewModel);
        }

    }
}
