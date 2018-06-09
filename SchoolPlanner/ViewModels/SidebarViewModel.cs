﻿using SchoolPlanner.ViewModels.Base;
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
                    Width = 40;
                else
                    Width = Sidebar.MaxWidth;
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

        public ICommand ExpandCommand { get; set; }
    }
}
