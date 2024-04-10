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

namespace FCW0VU_HFT_2023241.WPFclient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Emp_Button_Click(object sender, RoutedEventArgs e)
        {
            EmployeeWindow asd = new EmployeeWindow();
            asd.Show();
        }

        private void Dep_Button_Click(object sender, RoutedEventArgs e)
        {
            DepartmentWindow asd = new DepartmentWindow();
            asd.Show();
        }

        private void Loc_Button_Click(object sender, RoutedEventArgs e)
        {
            LocationWindow asd = new LocationWindow();
            asd.Show();
        }
    }
}
