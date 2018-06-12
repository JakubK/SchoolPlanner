using SchoolPlanner.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SchoolPlanner.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public Window Window;

        private Path MaximizeIcon, RestoreIcon;

        public Path MaximizePath { get; set; }


        public MainViewModel(Window w)
        {
            this.Window = w;

            RestoreIcon = (Path)Application.Current.FindResource("RestoreIcon");
            MaximizeIcon = (Path)Application.Current.FindResource("MaximizeIcon");

            MaximizePath = MaximizeIcon;

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
                {
                    this.Window.Padding = new Thickness(7);
                    MaximizePath = RestoreIcon;
                }
                else
                {
                    this.Window.Padding = new Thickness(0);
                    MaximizePath = MaximizeIcon;
                }

                OnPropertyChanged(nameof(MaximizePath));
            });

            Plans = new List<string>();

            Plans.Add("III AI");
            Plans.Add("III BI");
            Plans.Add("III CI");
            Plans.Add("III DI");
            Plans.Add("III DI");
            Plans.Add("III DI");
            Plans.Add("III DI");
            Plans.Add("III DI");

            Plans.Add("I AI");
        }

        public ICommand CloseCommand { get; set; }
        public ICommand MaximizeCommand { get; set; }
        public ICommand MinimizeCommand { get; set; }

        public ICommand StateChangedCommand { get; set; }

        public List<string> Plans { get; set; }

    }
}