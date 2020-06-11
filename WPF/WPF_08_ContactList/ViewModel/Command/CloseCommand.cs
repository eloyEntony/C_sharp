using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_08_ContactList.ViewModel.Command
{
    public class CloseCommand : ICommand
    {
        public ContactVM VM { get; set; }

        public CloseCommand()
        {
                
        }

        public CloseCommand(ContactVM vm)
        {
            VM = vm;
        }

        public event EventHandler CanExecuteChanged;
        //{
        //    add
        //    {
        //        CommandManager.RequerySuggested += value;
        //    }
        //    remove
        //    {
        //        CommandManager.RequerySuggested -= value;
        //    }
        //}

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.Close();
        }
    }
}
