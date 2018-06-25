using SchoolPlanner.Models;
using SchoolPlanner.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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

            this.CreatePlanCommand = new RelayCommand(CreatePlan);

            this.SelectionChangedCommand = new RelayCommand(() => SwitchPlan());
        }

        private void CreatePlan()
        {
            Plans.Add(new Plan("Unnamed Plan"));
        }

        private void SwitchPlan()
        {
            PlanPageViewModel.Instance.Plan = Plans[PlansListViewViewModel.Instance.SelectedIndex];
        }

        public ICommand CloseCommand { get; set; }
        public ICommand MaximizeCommand { get; set; }
        public ICommand MinimizeCommand { get; set; }
        public ICommand StateChangedCommand { get; set; }

        public ICommand CreatePlanCommand { get; set; }

        public ICommand SelectionChangedCommand { get; set; }


        private ObservableCollection<Plan> plans = new ObservableCollection<Plan>();

        public ObservableCollection<Plan> Plans
        {
            get { return plans; }
            set
            {
                plans = value;
                OnPropertyChanged(nameof(Plans));
            }
        }
    }
}