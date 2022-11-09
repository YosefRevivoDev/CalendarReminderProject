using DalReminders.DataObject;
using MaterialDesignColors.Recommended;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using UiReminders.Command;
using UiReminders.Model;

namespace UiReminders.ViewModel
{
    public class CalendarViewModel : BaseViewModel
    {
        public RemindersModel remindersModel { get; set; }

        public ObservableCollection<DayBookViewModel> DayBooksViewModel { set; get; }

        private MainViewModel mainViewModel;

        public ICommand DeleteCommand { get; set; }   

        public CalendarViewModel(RemindersModel remindersModel, MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
            this.remindersModel = remindersModel;

            DayBooksViewModel = new ObservableCollection<DayBookViewModel>(
               remindersModel.dayBooksModel.Select(dayBookModel => new DayBookViewModel(dayBookModel)));

            DayBooksViewModel.CollectionChanged += DayBooksViewModel_CollectionChanged;
        }

        private void DayBooksViewModel_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBoxResult.No;

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    messageBoxResult = MessageBox.Show("Success adding reminder");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    messageBoxResult = MessageBox.Show("Success remove reminder");
                    break;
                case NotifyCollectionChangedAction.Replace:
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    break;
                default:
                    break;
            }

            if (messageBoxResult == MessageBoxResult.OK)
            {
                mainViewModel.NavigationStore = this;
            }
        }

        private DateTime selectedDate;

        public DateTime SelectedDate {
         
            get => selectedDate;

            set
            {
                selectedDate = value;
               
            }
        }

        public void UpdateAndDeleteDayBook(DayBookViewModel dayBook)
        {
            mainViewModel.NavigationStore = new UpdateAndDeleteViewModel(this, mainViewModel, dayBook);
        }

        public void AddDayBook()
        {
            mainViewModel.NavigationStore = new AddDayBookViewModel(this, mainViewModel);
        }

        public async Task AddDayBookToDayBooksViewModel(int id)
        {
            try
            {
                DayBooksViewModel.Add(new DayBookViewModel(await remindersModel.GetDayBookModel(id)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
