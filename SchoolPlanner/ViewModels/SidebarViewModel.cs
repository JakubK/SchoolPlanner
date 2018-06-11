using SchoolPlanner.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolPlanner.ViewModels
{
    public class SidebarViewModel : BaseViewModel
    {
        private Sidebar Sidebar;

        public SidebarViewModel(Sidebar sidebar)
        {
            this.Sidebar = sidebar;

            ExpandCommand = new RelayCommand(() =>
            {
                if (Width == Sidebar.MaxWidth)
                {
                    Width = 40;
                    Expanded = false;
                }
                else
                {
                    Width = Sidebar.MaxWidth;
                    Expanded = true;
                }
            });
        }

        private double width = 40;
        public double Width
        {
            get { return width; }
            set
            {
                width = value;
                OnPropertyChanged(nameof(Width));
            }
        }

        private bool expanded = false;
        public bool Expanded
        {
            get { return expanded; }
            set
            {
                expanded = value;
                OnPropertyChanged(nameof(Expanded));
            }
        }

        public ICommand ExpandCommand { get; set; }
    }
}
