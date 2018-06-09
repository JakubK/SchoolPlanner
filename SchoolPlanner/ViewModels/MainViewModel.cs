using SchoolPlanner.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SchoolPlanner.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public Window Window;
        public MainViewModel(Window w)
        {
            this.Window = w;
        }
    }
}
