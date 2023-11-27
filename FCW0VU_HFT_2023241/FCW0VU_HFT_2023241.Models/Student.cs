using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FCW0VU_HFT_2023241.Models
{
    [Table("Students")]
    public class Student : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [StringLength(240)]
        public string Name { get; set; }

        [StringLength(6)]
        public string Neptun { get; set; }

        [ForeignKey(nameof(University))]
        public int UniversityID { get; set; }

        [ForeignKey(nameof(Course))]
        public int CourseID { get; set; }

        public Student() { }
        
        public Student(int studentID, string name, string neptun)
        {
            Id = studentID;
            Name = name;
            Neptun = neptun;
        }

        public Student(string data)
        {
            Id = int.Parse(data.Split('#')[0]);
            Name = data.Split('#')[1];
            Neptun = data.Split('#')[2];
        }
    }
}
