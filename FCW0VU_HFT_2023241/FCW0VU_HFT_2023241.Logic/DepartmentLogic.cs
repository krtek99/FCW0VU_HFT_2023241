using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FCW0VU_HFT_2023241.Models;
using FCW0VU_HFT_2023241.Repository;

namespace FCW0VU_HFT_2023241.Logic
{
    //crud
    #region crud
    public class DepartmentLogic
    {
        IRepository<Department> repo;
        public DepartmentLogic(IRepository<Department> item) 
        {
            this.repo = item;
        }
        public void Create(Department item)
        {
            if (item.Name.Length <= 0)
            {
                throw new ArgumentException("The name can not be empty.");
            }
            this.repo.Create(item);
        }

        public void Delete(int Id)
        {
            this.repo.Delete(Id);
        }

        public Department Read(int Id)
        {
            var emp = repo.Read(Id);
            if (emp == null)
            {
                throw new ArgumentException("This department does not exist.");
            }
            return this.repo.Read(Id);
        }

        public IEnumerable<Department> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Department item)
        {
            this.repo.Update(item);
        }
        #endregion

        public IEnumerable<KeyValuePair<string, string>> GetDepartmentNameDetails(int departmentID)
        {
            var output = repo.ReadAll()
                .Where(x => x.Id == departmentID)
                .Select(x => new KeyValuePair<string, string>(x.Name, x.Location.Name + ", " + x.Location.Address)).FirstOrDefault();

            if(output.Key == null || output.Value == null)
            {
                throw new Exception("No department was found with the given ID");
            }
            else 
            {
                List<KeyValuePair<string, string>> a = new List<KeyValuePair<string, string>>();
                a.Add(output);

                return a;
            }
        }
    }
}
