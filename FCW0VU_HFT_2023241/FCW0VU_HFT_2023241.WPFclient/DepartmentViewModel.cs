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
    public class DepartmentViewModel : ObservableRecipient
    {
        public RestCollection<Department> Departments { get; set; }

        private Department selectedDepartment;

        public Department SelectedDepartment
        {
            get { return selectedDepartment; }
            set 
            { 
                if (value != null) 
                {
                    selectedDepartment = new Department()
                    {
                        Name = value.Name,
                        Income = value.Income,
                        Expenses = value.Expenses,
                        Id = value.Id
                    };
                    OnPropertyChanged();
                    (DeleteDepartmentCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand CreateDepartmentCommand { get; set; }
        public ICommand UpdateDepartmentCommand { get; set; }
        public ICommand DeleteDepartmentCommand { get; set; }

        public DepartmentViewModel()
        {
            if (!IsInDesignMode)
            {
                Departments = new RestCollection<Department>("http://localhost:13109/", "Department", "hub");

                CreateDepartmentCommand = new RelayCommand(() =>
                {
                    Departments.Add(new Department() 
                    { 
                        Name = selectedDepartment.Name,
                        Income = selectedDepartment.Income,
                        Expenses = selectedDepartment.Expenses,
                    });
                });

                UpdateDepartmentCommand = new RelayCommand(() =>
                {
                    Departments.Update(SelectedDepartment);
                });

                DeleteDepartmentCommand = new RelayCommand(() =>
                {
                    Departments.Delete(SelectedDepartment.Id);
                }, 
                () =>
                {
                     return SelectedDepartment != null;
                });

                selectedDepartment = new Department();
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
