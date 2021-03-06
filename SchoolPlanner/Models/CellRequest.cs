﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlanner.Models
{
    public class CellRequest
    {
        public int X { get; set; }
        public int Y { get; set; }

        public CellType CellType { get; set; }
    }

    public enum CellType
    {
        Regular,
        RowAppend,
        ColumnAppend,
        ColumnRemove,
        RowRemove
    }
}
