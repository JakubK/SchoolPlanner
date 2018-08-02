using SchoolPlanner.Models;
using SchoolPlanner.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolPlanner.ViewModels
{
    public class PlanPageViewModel : BaseViewModel
    {
        private static PlanPageViewModel instance = new PlanPageViewModel();
        public static PlanPageViewModel Instance { get { return instance; } }

        private PlanPageViewModel()
        {
            RemoveCellCommand = new ParameterRelayCommand(id => RemoveCell(id));
        }

        private void RemoveCell(object id)
        {

        }

        private Plan plan;
        public Plan Plan
        {
            get { return plan; }
            set
            {
                plan = value;
                OnPropertyChanged(nameof(Plan));
            }
        }

        public ICommand RemoveCellCommand { get; set; }

        public ICommand AddRowCommand { get; set; }
        public ICommand AddColumnCommand { get; set; }

        public ICommand DropColumnCommand { get; set; }
        public ICommand DropRowCommand { get; set; }

        public ICommand SwitchPlanCommand { get; set; }

        public ICommand CellClickCommand { get; set; }
    }
}