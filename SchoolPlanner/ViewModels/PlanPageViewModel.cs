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
        public PlanPageViewModel()
        {
            Message = "Hello";
        }

        public string Message { get; set; }
    }
}