using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UiReminders.Model;

namespace UiReminders.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel(RemindersModel remindersModel)
        {
            NavigationStore = new CalendarViewModel(remindersModel, this);
        }

        private BaseViewModel navigationStore;

        public BaseViewModel NavigationStore
        {
            get => navigationStore;

            set
            {
                navigationStore = value;
                OnPropertyChanged(nameof(NavigationStore));

            }
        }

    }
}
