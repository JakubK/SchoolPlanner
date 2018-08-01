using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SchoolPlanner.Models
{
    public class Cell : INotifyPropertyChanged
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int SpanY { get; set; } = 1;
        public int SpanX { get; set; } = 1;

        private string text = "Text";
        public string Text
        {
            get { return text; }
            set { text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        public Color Foreground { get; set; }
        public Color Background { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}