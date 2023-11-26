using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCW0VU_HFT_2023241.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseID { get; set; }

        [StringLength(240)]
        public string Name { get; set; }

        public int Credit { get; set; }

        public Course() { }

        public Course(int courseID, string name, int credit)
        {
            CourseID = courseID;
            Name = name;
            Credit = credit;
        }

        public Course(string data)
        {
            CourseID = int.Parse(data.Split('#')[0]);
            Name = data.Split('#')[1];
            Credit = int.Parse(data.Split('#')[2]);
        }
    }
}
