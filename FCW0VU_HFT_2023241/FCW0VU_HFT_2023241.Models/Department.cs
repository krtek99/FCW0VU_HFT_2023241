using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FCW0VU_HFT_2023241.Models
{
    [Table("Departments")]
    public class Department : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [StringLength(240)]
        public string Name { get; set; }

        [ForeignKey(nameof(Location))]
        public int LocationId { get; set; }

        public int Income { get; set; }

        public int Expenses { get; set; }

        [NotMapped]
        public virtual Location Location { get; set; }

        [NotMapped]
        public virtual ICollection<Employee> Employees { get; set; }
        public Department() { }

        public Department(int universityID, string name, int locationid, int income, int expenses)
        {
            Id = universityID;
            Name = name;
            LocationId = locationid;
            Income = income;
            Expenses = expenses;
        }

        public Department(string data)
        {
            Id = int.Parse(data.Split('#')[0]);
            Name = data.Split('#')[1];
            LocationId = int.Parse(data.Split('#')[2]);
            Income = int.Parse(data.Split('#')[3]);
            Expenses = int.Parse(data.Split('#')[4]);
        }
    }
}
