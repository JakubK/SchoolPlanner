using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolPlanner.ViewModels.Base
{
    public class RelayCommand : ICommand
    {
        private Action Action;
        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action action)
        {
            this.Action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Action();
        }
    }
}
