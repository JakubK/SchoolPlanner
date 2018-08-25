using SchoolPlanner.Converters;
using SchoolPlanner.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPlanner
{
    public class IntsToCellRequestConverter : BaseMultiValueConverter<IntsToCellRequestConverter>
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return new CellRequest
            {
                X = (int)values[0],
                Y = (int)values[1],
                CellType = (CellType)values[2]
            };
        }

        public override object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
