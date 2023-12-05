using FCW0VU_HFT_2023241.Models;
using FCW0VU_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCW0VU_HFT_2023241.Repository.Repositories
{
    public class DepartmentRepository : Repository<Department>
    {
        public DepartmentRepository(HRDbContext ctx) : base(ctx)
        {
        }
    }
}
