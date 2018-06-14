using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlanner.Models
{
    public class Plan
    {
        public string Name { get; set; }
        public bool Saved { get; set; }

        public Plan(string name, bool saved = false)
        {
            this.Name = name;
            this.Saved = false;
        }
    }
}
