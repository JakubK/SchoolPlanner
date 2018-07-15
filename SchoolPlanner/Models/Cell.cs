using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SchoolPlanner.Models
{
    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }

        public string Text { get; set; }

        public Color Foreground { get; set; }
        public Color Background { get; set; }
    }
}
