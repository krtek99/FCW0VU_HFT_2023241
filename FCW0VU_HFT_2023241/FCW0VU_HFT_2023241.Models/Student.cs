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
        public int StudentID { get; set; }

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
            StudentID = studentID;
            Name = name;
            Neptun = neptun;
        }

        public Student(string data)
        {
            StudentID = int.Parse(data.Split('#')[0]);
            Name = data.Split('#')[1];
            Neptun = data.Split('#')[2];
        }
    }
}
