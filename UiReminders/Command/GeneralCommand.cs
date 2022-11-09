using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UiReminders.Model;
using UiReminders.ViewModel;

namespace UiReminders.Command
{
    public class GeneralCommand : ICommand
    {
        public Predicate<object> canExecuteCommand { get; set; }

        private Func<object, Task> func { get; set; }

        public event EventHandler CanExecuteChanged;

        public GeneralCommand(Func<object, Task> func)
        {
            this.func = func;
        }

        public bool CanExecute(object parameter)
        {
            return canExecuteCommand is null ? true : canExecuteCommand.Invoke(parameter);
        }

        public async void Execute(object parameter)
        {
            await func?.Invoke(parameter);
        }
    }
}
