using FCW0VU_HFT_2023241.Models;
using FCW0VU_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCW0VU_HFT_2023241.Logic
{
    public class LocationLogic : ILocationLogic
    {
        IRepository<Location> repo;

        public LocationLogic(IRepository<Location> repo)
        {
            this.repo = repo;
        }

        //crud
        #region crud
        public void Create(Location item)
        {
            if (item.Name.Length <= 0)
            {
                throw new ArgumentException("The name can not be empty.");
            }
            this.repo.Create(item);
        }

        public void Delete(int Id)
        {
            Location l = Read(Id);
            if (l != null)
            {
                this.repo.Delete(Id);
            }
        }

        public Location Read(int Id)
        {
            var emp = repo.Read(Id);
            return this.repo.Read(Id);
        }

        public IEnumerable<Location> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Location item)
        {
            this.repo.Update(item);
        }
        #endregion
    }
}
