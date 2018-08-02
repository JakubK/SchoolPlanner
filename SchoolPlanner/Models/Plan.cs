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

        private ObservableCollection<Cell> cells;
        public ObservableCollection<Cell> Cells
        {
            get { return cells; }
            set {
                cells = value;
                OnPropertyChanged(nameof(Plan));
            }
        }

        public Plan(string name, bool saved = false, bool located = false)
        {
            this.Name = name;
            this.Saved = saved;
            this.Located = located;

            if(!Located && !Saved) //Create basic Cell structure if we created a new file (administrative cells are ommited here)
            {
                cells = new ObservableCollection<Cell>();
                for (int y = 0; y < 2; y++)
                {
                    for (int x = 0; x < 2; x++)
                    {
                        Cell cell = new Cell();
                        cell.X = x + 1;
                        cell.Y = y + 1;
                       // cell.Text = "Text";

                        if (x == 0 || y == 0)
                        {
                            cell.Background = Colors.Azure;
                            cell.Foreground = Colors.White;
                        }

                        cells.Add(cell);
                    }
                }

                //Create administrative cells

                int xCells = 3;
                for(int x = 1;x < xCells;x++)
                {
                    cells.Add(new Cell()
                    {
                        X = x,
                        Y = 0
                    });
                }

                int yCells = 3;
                for (int y = 1; y < yCells; y++)
                {
                    cells.Add(new Cell()
                    {
                        X = 0,
                        Y = y
                    });
                }

                Cell bottom = new Cell();
                bottom.X = 0;
                bottom.Y = 3;
                bottom.SpanX = 4;
                cells.Add(bottom);

                Cell right = new Cell();
                right.X = 3;
                right.Y = 0;
                right.SpanY = 4;
                cells.Add(right);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}