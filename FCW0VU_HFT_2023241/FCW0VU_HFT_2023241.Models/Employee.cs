using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FCW0VU_HFT_2023241.Models
{
    [Table("Employees")]
    public class Employee : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [StringLength(240)]
        public string Name { get; set; }
        public int Salary { get; set; }

        [ForeignKey(nameof(Department))]
        public int DepartmentId { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual Department Department { get; set; }

        public Employee() { }
        
        public Employee(int studentID, string name, int salary, int departmentid)
        {
            Id = studentID;
            Name = name;
            Salary = salary;
            DepartmentId = departmentid;
        }

        public Employee(string data)
        {
            Id = int.Parse(data.Split('#')[0]);
            Name = data.Split('#')[1];
            Salary = int.Parse(data.Split('#')[2]);
            DepartmentId = int.Parse(data.Split('#')[3]);
        }

        public override string ToString()
        {
            string output = "{" + this.Id + ", " + this.Name + ", " + this.Salary + ", " + this.DepartmentId + "}";
            return output;
        }
    }
}
