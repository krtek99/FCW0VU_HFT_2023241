using FCW0VU_HFT_2023241.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FCW0VU_HFT_2023241.WPFclient
{
    public class EmployeeViewModel : ObservableRecipient
    {
        public RestCollection<Employee> Employees { get; set; }
        private Employee selectedEmployee;

        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set
            {
                if (value != null)
                {
                    selectedEmployee = new Employee()
                    { 
                        Name = value.Name,
                        Salary = value.Salary,
                        Id = value.Id
                    };
                    OnPropertyChanged();
                    (DeleteEmployeeCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand CreateEmployeeCommand { get; set; }
        public ICommand UpdateEmployeeCommand { get; set; }
        public ICommand DeleteEmployeeCommand { get; set; }

        public EmployeeViewModel()
        {
            if (!IsInDesignMode)
            {
                Employees = new RestCollection<Employee>("http://localhost:13109/", "Employee", "hub");

                CreateEmployeeCommand = new RelayCommand(() =>
                {
                    Employees.Add(new Employee()
                    {
                        Name = selectedEmployee.Name,
                        Salary = selectedEmployee.Salary,
                    });
                });

                UpdateEmployeeCommand = new RelayCommand(() =>
                {
                    Employees.Update(selectedEmployee);
                });

                DeleteEmployeeCommand = new RelayCommand(() =>
                {
                    Employees.Delete(selectedEmployee.Id);
                },
                () =>
                {
                    return selectedEmployee != null;
                });

                selectedEmployee = new Employee();
            }
        }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
    }
}
