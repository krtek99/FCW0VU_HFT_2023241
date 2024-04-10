using FCW0VU_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FCW0VU_HFT_2023241.WPFclient
{
    public class EmployeeViewModel
    {
        public RestCollection<Employee> Employees { get; set; }

        public EmployeeViewModel()
        {
            if (!IsInDesignMode)
            {
                Employees = new RestCollection<Employee>("http://localhost:13109/", "Employee");
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
