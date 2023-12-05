using FCW0VU_HFT_2023241.Models;
using System.Collections.Generic;

namespace FCW0VU_HFT_2023241.Logic
{
    public interface IDepartmentLogic
    {
        void Create(Department item);
        void Delete(int Id);
        IEnumerable<KeyValuePair<string, string>> GetDepartmentNameDetails(int departmentID);
        Department Read(int Id);
        IEnumerable<Department> ReadAll();
        void Update(Department item);
    }
}