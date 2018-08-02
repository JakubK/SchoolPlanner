using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolPlanner.ViewModels.Base
{
    public class ParameterRelayCommand : ICommand
    {
        private Action<object> mAction;

        public ParameterRelayCommand(Action<object> action)
        {
            mAction = action;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            mAction(parameter);
        }
    }
}
