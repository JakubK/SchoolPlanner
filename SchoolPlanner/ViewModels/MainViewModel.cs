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
            this.MaximizeCommand = new RelayCommand(() =>
                {
                    if (Window.WindowState == WindowState.Normal)
                        Window.WindowState = WindowState.Maximized;
                    else
                        Window.WindowState = WindowState.Normal;
                }
            );
            this.MinimizeCommand = new RelayCommand(() => Window.WindowState = WindowState.Minimized);

            this.StateChangedCommand = new RelayCommand(() =>
            {
                if (Window.WindowState == WindowState.Maximized)
                    this.Window.Padding = new Thickness(7);
                else
                    this.Window.Padding = new Thickness(0);
            });
        }

        public ICommand CloseCommand { get; set; }
        public ICommand MaximizeCommand { get; set; }
        public ICommand MinimizeCommand { get; set; }

        public ICommand StateChangedCommand { get; set; }
    }
}