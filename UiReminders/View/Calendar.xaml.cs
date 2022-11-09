using Syncfusion.UI.Xaml.Scheduler;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UiReminders.Model;
using UiReminders.ViewModel;

namespace UiReminders.View
{
    /// <summary>
    /// Interaction logic for Calendar.xaml
    /// </summary>
    public partial class Calendar : UserControl
    {

        private CalendarViewModel calendarViewModel;

        public Calendar()
        {
            InitializeComponent();
            DataContextChanged += Calendar_DataContextChanged;
        }

        private void Calendar_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (calendarViewModel is null)
            {
                calendarViewModel = (CalendarViewModel)e.NewValue;
                Schedule.ItemsSource = calendarViewModel.DayBooksViewModel;
            }
        }

        private void Schedule_AppointmentEditorOpening(object sender, AppointmentEditorOpeningEventArgs e)
        {
            e.Cancel = true;

            calendarViewModel.SelectedDate = e.DateTime;

            var appointment = e.Appointment;

            if (appointment is null)
                calendarViewModel.AddDayBook();

            else if (appointment.Data is not null)
                calendarViewModel.UpdateAndDeleteDayBook(((DayBookViewModel)appointment.Data));    
        }
    }
}