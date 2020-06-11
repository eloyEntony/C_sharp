using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPF_08_ContactList.ViewModel.Command
{
    public class ChangeThemes : ICommand
    {
        public ContactVM VM { get; set; }
        public ChangeThemes(ContactVM vm)
        {
            VM = vm;
        }
        public ChangeThemes() { }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
           return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is MenuItem)
            {
                MenuItem menuItem = parameter as MenuItem;
                VM.ChangeTheme(menuItem);
            }
        }
    }
}
