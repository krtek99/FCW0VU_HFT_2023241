using FCW0VU_HFT_2023241.Models;
using FCW0VU_HFT_2023241.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCW0VU_HFT_2023241.Logic
{
    public class EmployeeLogic
    {
        IRepository<Employee> repo;

        //crud
        #region crud
        public EmployeeLogic(IRepository<Employee> repo)
        {
            this.repo = repo;
        }

        public void Create(Employee item)
        {
            if (item.Salary <= 0)
            {
                throw new ArgumentException("The salary has to be more than 0.");
            }
            this.repo.Create(item);
        }

        public void Delete(int Id)
        {
            this.repo.Delete(Id);
        }

        public Employee Read(int Id)
        {
            var emp = repo.Read(Id);
            if (emp == null)
            {
                throw new ArgumentException("This employee does not exist.");
            }
            return this.repo.Read(Id);
        }

        public IEnumerable<Employee> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Employee item)
        {
            this.repo.Update(item);
        }
        #endregion

        //non-crud

        public class EmployeesPerDepartmentInfo
        {
            public int EmpCount { get; set; }
            public string DepName { get; set; }
        }
        public IEnumerable<EmployeesPerDepartmentInfo> GetEmployeesPerDepartment()
        {
            var output = from x in this.repo.ReadAll()
                         group x by x.Department.Name into g
                         select new EmployeesPerDepartmentInfo
                         {
                             EmpCount = g.Count(),
                             DepName = g.Key
                         };
            return output;
        }

        public class AvgSalaryPerDepartmentInfo
        {
            public double AvgSalary { get; set; }
            public string DepName { get; set; }
        }

        public IEnumerable<AvgSalaryPerDepartmentInfo> GetAvgSalaryPerDepartment()
        {
            var output = from x in this.repo.ReadAll()
                         group x by x.Department.Name into g
                         select new AvgSalaryPerDepartmentInfo
                         {
                             DepName = g.Key,
                             AvgSalary = g.Average(x => x.Salary)
                         };

            return output;
        }

        public class LargestSalaryPerDepartmentInfo
        {
            public string DepName { get; set; }
            public Employee Emp { get; set; }
        }
        public IEnumerable<LargestSalaryPerDepartmentInfo> GetLargestSalaryPerDepartment()
        {
            var maxSalariesByDepartment = repo.ReadAll()
                .GroupBy(emp => emp.DepartmentId)
                .Select(group => new
                {
                    DepartmentId = group.Key,
                    MaxSalary = group.Max(emp => emp.Salary)
                })
                .ToList();

            var output = maxSalariesByDepartment
                .SelectMany(maxSalary => repo.ReadAll()
                    .Where(emp => emp.DepartmentId == maxSalary.DepartmentId && emp.Salary == maxSalary.MaxSalary)
                    .Select(emp => new LargestSalaryPerDepartmentInfo
                    {
                        DepName = emp.Department.Name,
                        Emp = emp
                    }))
                .ToList();
            return output;
        }
    }
}
