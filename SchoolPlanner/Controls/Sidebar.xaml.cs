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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SchoolPlanner
{
    /// <summary>
    /// Logika interakcji dla klasy Sidebar.xaml
    /// </summary>
    [ContentProperty(nameof(Child))]
    public partial class Sidebar : UserControl
    {
        public Sidebar()
        {
            InitializeComponent();
            this.DataContext = new SidebarViewModel(this);
        }

        public UIElement Child
        {
            get { return (UIElement)GetValue(ChildProperty); }
            set { SetValue(ChildProperty, value); }
        }
        private static readonly DependencyProperty ChildProperty = DependencyProperty.Register(nameof(Child), typeof(UIElement), typeof(Sidebar), new PropertyMetadata());
    }
}
