using FCW0VU_HFT_2023241.Models;
using FCW0VU_HFT_2023241.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCW0VU_HFT_2023241.Repository.Repositories
{
    internal class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(EducationDbContext ctx) : base(ctx)
        {
        }
    }
}
