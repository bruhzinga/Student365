using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Student365.Models;

namespace Student365.UserControls
{
    /// <summary>
    /// Логика взаимодействия для ScheduleDataGrid.xaml
    /// </summary>
    public partial class ScheduleDataGrid : UserControl
    {
        public ScheduleDataGrid()
        {
            InitializeComponent();
            DataContext = this;
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            "Text", typeof(string), typeof(ScheduleDataGrid), new PropertyMetadata(default(string)));

        public static readonly DependencyProperty ScheduleProperty = DependencyProperty.Register(
            "Schedule", typeof(ObservableCollection<Schedule>), typeof(ScheduleDataGrid),
            new PropertyMetadata(default(ObservableCollection<Schedule>)));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public ObservableCollection<Schedule> Schedule
        {
            get { return (ObservableCollection<Schedule>)GetValue(ScheduleProperty); }
            set { SetValue(ScheduleProperty, value); }
        }
    }
}