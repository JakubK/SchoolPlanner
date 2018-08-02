using SchoolPlanner.Models;
using SchoolPlanner.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace SchoolPlanner.ViewModels
{
    public class CellViewModel : BaseViewModel
    {
        private int x;
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
                OnPropertyChanged(nameof(X));
            }
        }

        private int y;
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
                OnPropertyChanged(nameof(Y));
            }
        }
        public int SpanY { get; set; } = 1;
        public int SpanX { get; set; } = 1;

        private string text;
        public string Text {
            get { return text; }
            set { text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        public Color Foreground { get; set; }
        public Brush Background { get; set; }

        public ICommand ClickCellCommand { get; set; }

        public CellViewModel()
        {
            ClickCellCommand = new ParameterRelayCommand(param => DoSomething(param));
        }

        private void DoSomething(object param)
        {
            CellRequest rq = (CellRequest)param;
            System.Diagnostics.Debug.WriteLine(rq.X + " and " + rq.Y);
        }
    }
}