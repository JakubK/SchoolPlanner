using SchoolPlanner.Models;
using SchoolPlanner.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            CellClickCommand = new ParameterRelayCommand(query => CellClick(query));

            AppendRowCommand = new ParameterRelayCommand(cellRequest => AppendRow((CellRequest)cellRequest));
            AppendColumnCommand = new ParameterRelayCommand(cellRequest => AppendColumn((CellRequest)cellRequest));

            RemoveRowCommand = new ParameterRelayCommand(cellRequest => RemoveRow((CellRequest)cellRequest));
            RemoveColumnCommand = new ParameterRelayCommand(cellRequest => RemoveColumn((CellRequest)cellRequest));
        }

        private void AppendRow(CellRequest cellRequest)
        {
            int y = cellRequest.Y;
            Plan.AddRow.Y++;
            Plan.AddColumn.SpanY++;

            for (int i = 1; i <= Plan.AddRow.SpanX; i++)
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
                Text = "Remove Row " + y,
                Background = Brushes.Blue,
                CellType = CellType.RowRemove,
                X = 0,
                Y = y,
                SpanX = 1,
                SpanY = 1
            });
        }

        private void AppendColumn(CellRequest cellRequest)
        {
            int x = cellRequest.X;
            Plan.AddColumn.X++;
            Plan.AddRow.SpanX++;
            for (int i = 1; i <= Plan.AddColumn.SpanY; i++)
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
                CellType = CellType.ColumnRemove,
                X = x,
                Y = 0,
                SpanX = 1,
                SpanY = 1
            });
        }

        private void RemoveRow(CellRequest cellRequest)
        {
            //Remove row of the cell
            if (Plan.AddColumn.SpanY > 1)
            {
                int startY = cellRequest.Y;
                int maxY = Plan.AddRow.Y;

                for (int y = startY; y <= maxY; y++)
                {
                    if (y == startY)
                    {
                        var cells = Plan.Cells.Where(x => x.Y == y && x != Plan.AddColumn).ToList();
                        for (int i = 0; i < cells.Count(); i++)
                        {
                            Plan.Cells.Remove(cells[i]);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < Plan.Cells.Count; i++)
                        {
                            if (Plan.Cells[i].Y == y)
                            {
                                Plan.Cells[i].Y--;
                            }
                        }
                    }
                }
                Plan.AddColumn.SpanY--;
            }
        }

        private void RemoveColumn(CellRequest cellRequest)
        {
            if (Plan.AddRow.SpanX > 1)
            {
                int startX = cellRequest.X;
                int maxX = Plan.AddColumn.X;

                for (int x = startX; x <= maxX; x++)
                {
                    if (x == startX)
                    {
                        var cells = Plan.Cells.Where(c => c.X == x && c != Plan.AddRow).ToList();
                        for (int i = 0; i < cells.Count(); i++)
                        {
                            Plan.Cells.Remove(cells[i]);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < Plan.Cells.Count; i++)
                        {
                            if (Plan.Cells[i].X == x)
                            {
                                Plan.Cells[i].X--;
                            }
                        }
                    }
                }
                Plan.AddRow.SpanX--;
            }
        }

        private void CellClick(object query)
        {
            CellRequest cellRequest = (CellRequest)query;
            if (cellRequest.CellType == CellType.RowAppend)
            {
                AppendRowCommand.Execute(cellRequest);
            }
            else if(cellRequest.CellType == CellType.ColumnAppend)
            {
                AppendColumnCommand.Execute(cellRequest);
            }
            else if(cellRequest.CellType == CellType.RowRemove)
            {
                RemoveRowCommand.Execute(cellRequest);
            }
            else if(cellRequest.CellType == CellType.ColumnRemove)
            {
                RemoveColumnCommand.Execute(cellRequest);
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

        public ICommand AppendRowCommand { get; set; }

        public ICommand AppendColumnCommand { get; set; }

        public ICommand RemoveColumnCommand { get; set; }

        public ICommand RemoveRowCommand { get; set; }

        public ICommand SwitchPlanCommand { get; set; }

        public ICommand CellClickCommand { get; set; }
    }
}