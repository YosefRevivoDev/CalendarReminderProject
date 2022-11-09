using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using UiReminders.Model;
using UiReminders.ViewModel;

namespace UiReminders
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();

            RemindersModel remindersModel = new();

            try
            {
                await Task.Run(() => remindersModel.initDayBooksModel());

                MainViewModel mainViewModel = new(remindersModel);

                mainWindow.DataContext = mainViewModel;

                mainWindow.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
