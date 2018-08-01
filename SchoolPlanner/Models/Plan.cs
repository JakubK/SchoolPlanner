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
                Cell left = new Cell();
                left.X = 0;
                left.Y = 1;


                left.SpanY = 3;
                cells.Add(left);

                Cell top = new Cell();
                top.X = 1;
                top.Y = 0;

                top.SpanX = 3;
                cells.Add(top);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}