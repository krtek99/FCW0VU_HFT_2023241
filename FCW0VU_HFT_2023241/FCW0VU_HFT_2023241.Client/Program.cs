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

            ;
        }
    }
}
