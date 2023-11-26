using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCW0VU_HFT_2023241.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [StringLength(240)]
        public string Name { get; set; }

        [StringLength(6)]
        public string Neptun { get; set; }

        [ForeignKey(nameof(University))]
        public int UniversityID { get; set; }

        [ForeignKey(nameof(Course))]
        public int CourseID { get; set; }
    }
}
