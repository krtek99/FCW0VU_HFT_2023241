﻿using FCW0VU_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCW0VU_HFT_2023241.Repository.Repositories
{
    public class LocationRepository : Repository<Location>
    {
        public LocationRepository(HRDbContext ctx) : base(ctx)
        {
        }
    }
}
