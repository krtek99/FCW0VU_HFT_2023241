using FCW0VU_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCW0VU_HFT_2023241.Repository
{
    internal class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(HRDbContext ctx) : base(ctx) { }
    }
}
