using SchoolPlanner.Models;
using SchoolPlanner.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlanner.ViewModels
{
    public class PlanPageViewModel : BaseViewModel
    {
        private static PlanPageViewModel instance = new PlanPageViewModel();
        public static PlanPageViewModel Instance { get { return instance; } }

        private PlanPageViewModel()
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
    }
}