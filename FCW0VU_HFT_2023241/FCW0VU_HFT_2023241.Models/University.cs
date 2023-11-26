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
    public class University
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UniversityID { get; set; }

        [StringLength(240)]
        public string Name { get; set; }

        [StringLength(240)]
        public string Location { get; set; }

        public int Founding_Date { get; set; }

        public int Student_Count { get; set; }

        public University() { }

        public University(int universityID, string name, string location, int founding_Date, int student_Count)
        {
            UniversityID = universityID;
            Name = name;
            Location = location;
            Founding_Date = founding_Date;
            Student_Count = student_Count;
        }

        public University(string data)
        {
            UniversityID = int.Parse(data.Split('#')[0]);
            Name = data.Split('#')[1];
            Location = data.Split('#')[2];
            Founding_Date = int.Parse(data.Split('#')[3]);
            Student_Count = int.Parse(data.Split('#')[4]);
        }
    }
}
