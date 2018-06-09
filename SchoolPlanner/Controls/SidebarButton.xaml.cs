using SchoolPlanner.ViewModels.Base;
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
    /// Logika interakcji dla klasy SidebarButton.xaml
    /// </summary>
    public partial class SidebarButton : UserControl
    {
        public SidebarButton()
        {
            InitializeComponent();
        }

        public string PathData
        {
            get { return (string)GetValue(PathDataProperty); }
            set { SetValue(PathDataProperty, value); }
        }
        private static readonly DependencyProperty PathDataProperty = DependencyProperty.Register(nameof(PathData), typeof(string), typeof(SidebarButton), new PropertyMetadata()); 

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        private static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text), typeof(string), typeof(SidebarButton), new PropertyMetadata());

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(nameof(Command), typeof(ICommand), typeof(SidebarButton), new UIPropertyMetadata(null));

        public ICommand Command
        {
            get
            {
                return (ICommand)GetValue(CommandProperty);
            }
            set
            {
                SetValue(CommandProperty, value);
            }
        }
    }
}