using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace SchoolPlanner.Converters
{
    public abstract class BaseMultiValueConverter<T> : MarkupExtension, IMultiValueConverter where T : class,new()
    {
        public abstract object Convert(object[] values, Type targetType, object parameter, CultureInfo culture);

        public abstract object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture);

        private static T Coverter = null;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Coverter ?? (Coverter = new T());
        }
    }
}
