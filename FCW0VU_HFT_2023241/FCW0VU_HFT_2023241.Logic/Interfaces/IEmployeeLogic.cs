using FCW0VU_HFT_2023241.Models;
using System.Collections.Generic;

namespace FCW0VU_HFT_2023241.Logic
{
    public interface IEmployeeLogic
    {
        void Create(Employee item);
        void Delete(int Id);
        IEnumerable<KeyValuePair<string, double>> GetAvgSalaryPerDepartment();
        IEnumerable<KeyValuePair<string, int>> GetEmployeesPerDepartment();
        IEnumerable<KeyValuePair<string, string>> GetLargestSalaryPerDepartment();
        IEnumerable<KeyValuePair<string, int>> GetTotalSalaryCostPerDepartment();
        Employee Read(int Id);
        IEnumerable<Employee> ReadAll();
        void Update(Employee item);
    }
}