﻿using FCW0VU_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCW0VU_HFT_2023241.Repository
{
    public interface IRepository<T> where T : Entity
    {
        void Create(T item);
        T Read(int Id);
        IQueryable<T> ReadAll();
        void Update(T item);
        void Delete(int Id);
    }
}
