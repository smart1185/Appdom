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

namespace SearchEmployeeExtended
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    [Serializable]
    public partial class MainWindow : Window
    {
        public EntityModel1 db = new EntityModel1();
        public string input = "";
        public string input2 = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            input = tbxInput.Text;

            var empList = db.EmployeesListDB.Where(f => f.LastName == input || f.EmployeeName == input).ToList();
            lvEmployeeList.ItemsSource = empList;
        }

        private void btnSearch2_Click(object sender, RoutedEventArgs e)
        {
            input2 = tbxInput2.Text;

            var empList = db.EmployeesListDB.Where(f => f.Email == input2 || f.Phone == input2).ToList();
            lvEmployeeList.ItemsSource = empList;
        }
    }
}
