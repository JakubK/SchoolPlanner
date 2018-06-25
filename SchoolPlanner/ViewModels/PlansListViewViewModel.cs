using SchoolPlanner.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolPlanner.ViewModels
{
    public class PlansListViewViewModel : BaseViewModel
    {
        private static PlansListViewViewModel instance = new PlansListViewViewModel();
        public static PlansListViewViewModel Instance { get { return instance; } }

        private PlansListViewViewModel()
        {
            SwitchItemsCommand = new RelayCommand(() => ListHeight = ListHeight == 200 ? 0 : 200);
        }

        private double listHeight = 0;
        public double ListHeight
        {
            get { return listHeight; }
            set
            {
                listHeight = value;
                OnPropertyChanged(nameof(ListHeight));
            }
        }

        private int selectedIndex = 0;
        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                selectedIndex = value;
                OnPropertyChanged(nameof(SelectedIndex));
            }
        }

        public ICommand SwitchItemsCommand { get; set; }
    }
}