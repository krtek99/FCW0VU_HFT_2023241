using FCW0VU_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCW0VU_HFT_2023241.Repository.Repositories
{
    internal class UniversityRepository : Repository<University>, IUniversityRepository
    {
        public UniversityRepository(EducationDbContext ctx) : base(ctx)
        {
        }
    }
}
