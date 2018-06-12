using SchoolPlanner.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolPlanner.ViewModels
{
    public class PropertiesEditorViewModel : BaseViewModel
    {
        public PropertiesEditorViewModel()
        {
            TogglePropertiesCommand = new RelayCommand(() => PropertiesHeight = PropertiesHeight == 300 ? 0 : 300);
        }

        private double propertiesHeight = 300;
        public double PropertiesHeight
        {
            get { return propertiesHeight; }
            set
            {
                propertiesHeight = value;
                OnPropertyChanged(nameof(PropertiesHeight));
            }
        }

        public ICommand TogglePropertiesCommand { get; set; }

    }
}
