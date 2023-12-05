using FCW0VU_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCW0VU_HFT_2023241.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected HRDbContext ctx;

        public Repository(HRDbContext ctx)
        {
            this.ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }

        public void Create(T item)
        {
            ctx.Set<T>().Add(item);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            var x = Read(id);
            ctx.Set<T>().Remove(x);
            ctx.SaveChanges();
        }

        public T Read(int Id)
        {
            return ctx.Set<T>().FirstOrDefault(x => x.Id == Id);
        }

        public IQueryable<T> ReadAll()
        {
            return ctx.Set<T>();
        }

        public void Update(T item)
        {
            var old = Read(item.Id);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
