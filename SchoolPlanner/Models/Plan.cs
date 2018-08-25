using SchoolPlanner.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SchoolPlanner.Models
{
    public class Plan : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public bool Saved { get; set; }
        public bool Located { get; set; }

        private ObservableCollection<CellViewModel> cells = new ObservableCollection<CellViewModel>();
        public ObservableCollection<CellViewModel> Cells
        {
            get { return cells; }
            set {
                cells = value;
                OnPropertyChanged(nameof(Cells));
            }
        }

        private CellViewModel addColumn;
        public CellViewModel AddColumn
        {
            get { return addColumn; }
            set
            {
                addColumn = value;
                OnPropertyChanged(nameof(AddColumn));
            }
        }

        private CellViewModel addRow;
        public CellViewModel AddRow
        {
            get { return addRow; }
            set
            {
                addRow = value;
                OnPropertyChanged(nameof(AddRow));
            }
        }

        public Plan(string name, bool saved = false, bool located = false)
        {
            this.Name = name;
            this.Saved = saved;
            this.Located = located;
            
            if(!Located && !Saved) //Create basic Cell structure if we created a new file (administrative cells are ommited here)
            {
                for (int y = 1; y < 3; y++)
                {
                    for (int x = 1; x < 3; x++)
                    {
                        CellViewModel cell = new CellViewModel();
                        cell.X = x;
                        cell.Y = y;
                        cell.Text = "Text";
                        cell.Background = Brushes.Violet;
                        Cells.Add(cell);
                    }
                }

                //Create administrative cells

                int xCells = 3;
                for(int x = 1;x < xCells;x++)
                {
                    Cells.Add(new CellViewModel()
                    {
                        X = x,
                        Y = 0,
                        Background = Brushes.Blue,
                        CellType = CellType.ColumnRemove,
                        Text = "Remove column " + x
                    });
                }

                int yCells = 3;
                for (int y = 1; y < yCells; y++)
                {
                    Cells.Add(new CellViewModel()
                    {
                        X = 0,
                        Y = y,
                        Background = Brushes.Blue,
                        CellType = CellType.RowRemove,
                        Text = "Remove row " + y

                    });
                }

                CellViewModel bottom = new CellViewModel();
                bottom.X = 0;
                bottom.Y = 3;
                bottom.SpanX = 3;
                bottom.Background = Brushes.Yellow;
                bottom.Text = "Append new Row";
                bottom.CellType = CellType.RowAppend;
                addRow = bottom;
                Cells.Add(bottom);

                CellViewModel right = new CellViewModel();
                right.X = 3;
                right.Y = 0;
                right.SpanY = 3;
                right.Background = Brushes.Yellow;
                right.Text = "Append new Column";
                right.CellType = CellType.ColumnAppend;
                addColumn = right;
                Cells.Add(right);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}