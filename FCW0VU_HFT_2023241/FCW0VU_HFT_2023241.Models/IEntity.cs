using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCW0VU_HFT_2023241.Models
{
    internal interface IEntity<TId>
    {
        TId Id { get; set; }
    }
}
