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
        private PlansListView PlansListView;
        public PlansListViewViewModel(PlansListView plansListView)
        {
            this.PlansListView = plansListView;

            SwitchItemsCommand = new RelayCommand(() => plansListView.ListHeight = plansListView.ListHeight == 200 ? 0 : 200);
        }

        public ICommand SwitchItemsCommand { get; set; }
    }
}
