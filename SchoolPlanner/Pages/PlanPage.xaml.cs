using SchoolPlanner.ViewModels;
using System;
using System.Collections;
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
    /// Logika interakcji dla klasy GridPage.xaml
    /// </summary>
    public partial class PlanPage : Page
    {
        public PlanPage()
        {
            InitializeComponent();
            this.DataContext = PlanPageViewModel.Instance;
        }

        public IEnumerable Source
        {
            get {
                System.Diagnostics.Debug.WriteLine("get");
                return (IEnumerable)GetValue(SourceProperty); }
            set
            {
                SetValue(SourceProperty, value);
                System.Diagnostics.Debug.WriteLine("asdasdasd");
            }
        }

        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register(nameof(Source), typeof(IEnumerable), typeof(PlanPage));

        private void Grid_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Update");
        }

        private void Grid_LayoutUpdated(object sender, EventArgs e)
        {

        }
    }
}
