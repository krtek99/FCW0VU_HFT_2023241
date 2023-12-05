using FCW0VU_HFT_2023241.Models;
using System.Collections.Generic;

namespace FCW0VU_HFT_2023241.Logic
{
    public interface ILocationLogic
    {
        void Create(Location item);
        void Delete(int Id);
        Location Read(int Id);
        IEnumerable<Location> ReadAll();
        void Update(Location item);
    }
}