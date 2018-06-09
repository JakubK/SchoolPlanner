using SchoolPlanner.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SchoolPlanner.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public Window Window;
        public MainViewModel(Window w)
        {
            this.Window = w;

            this.CloseCommand = new RelayCommand(() => Window.Close());
            this.MaximizeCommand = new RelayCommand(() => Window.WindowState = WindowState.Maximized);
            this.MinimizeCommand = new RelayCommand(() => Window.WindowState = WindowState.Minimized);
        }

        public ICommand CloseCommand { get; set; }
        public ICommand MaximizeCommand { get; set; }
        public ICommand MinimizeCommand { get; set; }
    }
}
