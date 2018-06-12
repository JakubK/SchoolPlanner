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
        public PlansListViewViewModel()
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

        public ICommand SwitchItemsCommand { get; set; }
    }
}
