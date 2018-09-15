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
    /// Logika interakcji dla klasy DynamicGrid.xaml
    /// </summary>
    public partial class DynamicGrid : Grid
    {
        public DynamicGrid()
        {
            InitializeComponent();
        }

        protected override void OnVisualChildrenChanged(DependencyObject visualAdded, DependencyObject visualRemoved)
        {
            base.OnVisualChildrenChanged(visualAdded, visualRemoved);

            if(PlanPageViewModel.Instance.Plan.Cells[PlanPageViewModel.Instance.Plan.Cells.Count-1].X == this.ColumnDefinitions.Count-1)
            {
                this.ColumnDefinitions.Add(new ColumnDefinition()
                {
                    Width = new GridLength(200,GridUnitType.Pixel)
                });
            }

            if(PlanPageViewModel.Instance.Plan.Cells[PlanPageViewModel.Instance.Plan.Cells.Count-1].Y == this.RowDefinitions.Count-1)
            {
                this.RowDefinitions.Add(new RowDefinition()
                {
                    Height = new GridLength(200, GridUnitType.Pixel)
                });
            }
        }
    }
}
