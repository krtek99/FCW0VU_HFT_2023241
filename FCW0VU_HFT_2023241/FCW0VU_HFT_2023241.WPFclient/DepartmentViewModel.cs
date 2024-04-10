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
    public class DepartmentViewModel
    {
        public RestCollection<Department> Departments { get; set; }

        public DepartmentViewModel()
        {
            if (!IsInDesignMode)
            {
                Departments = new RestCollection<Department>("http://localhost:13109/", "Department");
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
