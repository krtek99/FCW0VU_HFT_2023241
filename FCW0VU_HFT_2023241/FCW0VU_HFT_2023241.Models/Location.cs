using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FCW0VU_HFT_2023241.Models
{
    [Table("Locations")]
    public class Location : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [StringLength(240)]
        public string Name { get; set; }

        public string Address { get; set; }

        public Location() { }

        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<Department> Departments { get; set; }
        public Location(int courseID, string name, string address)
        {
            Id = courseID;
            Name = name;
            Address = address;
        }

        public Location(string data)
        {
            Id = int.Parse(data.Split('#')[0]);
            Name = data.Split('#')[1];
            Address = data.Split('#')[2];
        }
    }
}
