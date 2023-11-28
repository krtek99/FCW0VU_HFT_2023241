using FCW0VU_HFT_2023241.Models;
using FCW0VU_HFT_2023241.Repository;
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
            public string depname { get; set; }
        }
        public IEnumerable<EmployeesPerDepartmentInfo> EmployeesPerDepartment() 
        {
            var asd = from x in this.repo.ReadAll()
                      group x by x.Department.Name into g
                      select new EmployeesPerDepartmentInfo
                      {
                          EmpCount = g.Count(),
                          depname = g.Key
                      };
            return asd;
        }
    }
}
