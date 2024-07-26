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
namespace DemoWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SampleDbContext dbContext;
        public MainWindow()
        {
            InitializeComponent();
            dbContext = new SampleDbContext();
            LoadData();
        }
        private void LoadData()
        {
            EmployeeDataGrid.ItemsSource = dbContext.Employees.ToList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var employee = new Employee
            {
                Name = NameTextBox.Text,
                Position = PositionTextBox.Text,
                Age = int.Parse(AgeTextBox.Text),
                Salary = decimal.Parse(SalaryTextBox.Text)
            };
            dbContext.Employees.Add(employee);
            dbContext.SaveChanges();
            LoadData();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeDataGrid.SelectedItem is Employee selectedEmployee)
            {
                selectedEmployee.Name = NameTextBox.Text;
                selectedEmployee.Position = PositionTextBox.Text;
                selectedEmployee.Age = int.Parse(AgeTextBox.Text);
                selectedEmployee.Salary = decimal.Parse(SalaryTextBox.Text);
                dbContext.SaveChanges();
                LoadData();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeDataGrid.SelectedItem is Employee selectedEmployee)
            {
                dbContext.Employees.Remove(selectedEmployee);
                dbContext.SaveChanges();
                LoadData();
            }
        }
    }
}
