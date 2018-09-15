using SchoolPlanner.Models;
using SchoolPlanner.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace SchoolPlanner.ViewModels
{
    public class CellViewModel : BaseViewModel
    {
        private Style style;
        public Style Style
        {
            get { return style; }
            set
            {
                style = value;
                OnPropertyChanged(nameof(Style));
            }
        }

        private CellType cellType = CellType.Regular;
        public CellType CellType
        {
            get { return cellType; }
            set
            {
                cellType = value;
                OnPropertyChanged(nameof(CellType));
            }
        }

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

        private int spanY = 1;
        public int SpanY
        {
            get
            {
                return spanY;
            }
            set
            {
                spanY = value;
                OnPropertyChanged(nameof(SpanY));
            }
        }

        private int spanX = 1;
        public int SpanX
        {
            get
            {
                return spanX;
            }
            set
            {
                spanX = value;
                OnPropertyChanged(nameof(SpanX));
            }
        }
        private string text;
        public string Text
        {
            get { return text; }
            set
            {
                text = value;
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
            PlanPageViewModel.Instance.CellClickCommand.Execute(param);
        }
    }
}