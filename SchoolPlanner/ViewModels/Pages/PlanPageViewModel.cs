using SchoolPlanner.Models;
using SchoolPlanner.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace SchoolPlanner.ViewModels
{
    public class PlanPageViewModel : BaseViewModel
    {
        private static PlanPageViewModel instance = new PlanPageViewModel();
        public static PlanPageViewModel Instance { get { return instance; } }

        private PlanPageViewModel()
        {
            RemoveCellCommand = new ParameterRelayCommand(id => RemoveCell(id));

            CellClickCommand = new ParameterRelayCommand(query => CellClick(query));
        }

        private void RemoveCell(object id)
        {

        }

        private void CellClick(object query)
        {
            CellRequest cellRequest = (CellRequest)query;
            if (cellRequest.CellType == CellType.RowAppend)
            {
                int y = cellRequest.Y;
                Plan.AddRow.Y++;
                Plan.AddColumn.SpanY++;

                for(int i = 1;i < Plan.AddRow.SpanX;i++)
                {
                    Plan.Cells.Add(new CellViewModel
                    {
                        Text = "Text",
                        Background = Brushes.Violet,
                        X = i,
                        Y = y,
                        SpanY = 1
                    });
                }

                Plan.Cells.Add(new CellViewModel
                {
                    Text = "Remove Column",
                    Background = Brushes.Blue,
                    X = 0,
                    Y = y,
                    SpanX = 1,
                    SpanY = 1
                });

            }
            else if(cellRequest.CellType == CellType.ColumnAppend)
            {
                int x = cellRequest.X;
                Plan.AddColumn.X++;
                Plan.AddRow.SpanX++;
                Plan.AddRow.SpanY++;
                for (int i = 1; i < Plan.AddColumn.SpanY; i++)
                {
                    Plan.Cells.Add(new CellViewModel
                    {
                        Text = "Text",
                        Background = Brushes.Violet,
                        X = x,
                        Y = i,
                        SpanY = 1
                    });
                }

                Plan.Cells.Add(new CellViewModel
                {
                    Text = "Remove Column",
                    Background = Brushes.Blue,
                    X = x,
                    Y = 0,
                    SpanX = 1,
                    SpanY = 1
                });
            }
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