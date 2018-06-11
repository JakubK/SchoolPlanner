using SchoolPlanner.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SchoolPlanner
{
    /// <summary>
    /// Logika interakcji dla klasy PlansListView.xaml
    /// </summary>
    public partial class PlansListView : UserControl
    {
        public PlansListView()
        {
            InitializeComponent();
            this.DataContext = new PlansListViewViewModel(this);
        }

        public double ListHeight
        {
            get { return (double)GetValue(ListHeightProperty); }
            set { SetValue(ListHeightProperty, value); }
        }
        private static readonly DependencyProperty ListHeightProperty = DependencyProperty.Register(nameof(ListHeight), typeof(double), typeof(PlansListView), new PropertyMetadata());

        public IEnumerable<string> ItemSource
        {
            get { return (IEnumerable<string>)GetValue(ItemSourceProperty); }
            set { SetValue(ItemSourceProperty, value); }
        }
        private static readonly DependencyProperty ItemSourceProperty = DependencyProperty.Register(nameof(ItemSource), typeof(IEnumerable<string>), typeof(PlansListView), new PropertyMetadata());
    }
}
