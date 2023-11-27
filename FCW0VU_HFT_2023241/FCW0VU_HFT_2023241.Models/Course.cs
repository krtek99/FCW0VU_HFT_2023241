using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCW0VU_HFT_2023241.Models
{
    [Table("Courses")]
    public class Course : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [StringLength(240)]
        public string Name { get; set; }

        public int Credit { get; set; }

        public Course() { }

        public Course(int courseID, string name, int credit)
        {
            Id = courseID;
            Name = name;
            Credit = credit;
        }

        public Course(string data)
        {
            Id = int.Parse(data.Split('#')[0]);
            Name = data.Split('#')[1];
            Credit = int.Parse(data.Split('#')[2]);
        }
    }
}
