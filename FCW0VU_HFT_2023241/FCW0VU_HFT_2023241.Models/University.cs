using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
