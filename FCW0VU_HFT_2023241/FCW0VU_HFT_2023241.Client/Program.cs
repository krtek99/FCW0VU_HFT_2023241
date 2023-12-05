using FCW0VU_HFT_2023241.Logic;
using FCW0VU_HFT_2023241.Repository;
using System;

namespace FCW0VU_HFT_2023241.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ctx = new HRDbContext();
            var repo = new EmployeeRepository(ctx);
            var logic = new EmployeeLogic(repo);

            var asd = logic.ReadAll();

            var asdasdas = logic.GetEmployeesPerDepartment();
            
            var afg = logic.GetAvgSalaryPerDepartment();
            
            var gsdfs = logic.GetLargestSalaryPerDepartment();
            

            Console.WriteLine("GetEmployeesPerDepartment:");
            foreach ( var s in asdasdas)
            {
                Console.WriteLine(s.Key + "     " + s.Value);
            }

            Console.WriteLine("\nGetAvgSalaryPerDepartment");
            foreach (var s in afg)
            {
                Console.WriteLine(s.Key + "     " + s.Value);
            }

            Console.WriteLine("\nGetLargestSalaryPerDepartment");
            foreach (var s in gsdfs)
            {
                Console.WriteLine(s.Key + "     " + s.Value);
            }
        }
    }
}
