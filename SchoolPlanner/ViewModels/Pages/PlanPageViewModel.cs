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
                    Text = "Remove Row " + y,
                    Background = Brushes.Blue,
                    CellType = CellType.RowRemove,
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
                    CellType = CellType.ColumnRemove,
                    X = x,
                    Y = 0,
                    SpanX = 1,
                    SpanY = 1
                });
            }
            else if(cellRequest.CellType == CellType.RowRemove)
            {
                //Remove row of the cell
                int startY = cellRequest.Y;
                int maxY = cellRequest.Y;
            
                for (int i = 0;i < Plan.Cells.Count;i++) //find max Y
                {
                    if (Plan.Cells[i].Y > maxY)
                        maxY = Plan.Cells[i].Y;
                }

                for(int y = startY; y <= maxY ;y++)
                {
                    if (y == startY)
                    {
                        var cells = Plan.Cells.Where(x => x.Y == y).ToList();
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
            else if(cellRequest.CellType == CellType.ColumnRemove)
            {
                int startX = cellRequest.X;
                int maxX = cellRequest.X;

                for (int i = 0; i < Plan.Cells.Count; i++) //find max X
                {
                    if (Plan.Cells[i].X > maxX)
                        maxX = Plan.Cells[i].X;
                }

                for (int x = startX; x <= maxX; x++)
                {
                    if (x == startX)
                    {
                        var cells = Plan.Cells.Where(c => c.X == x).ToList();
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