using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_LINQ.Models
{
    internal class Teacher
    {
        [Key]
        public int TeacherID { get; set; }

        public string TeacherName { get; set; }


        // Navigation, one teacher can have many subjects. 
        public ICollection<Subject> Subjects { get; set; }

        public Course Course { get; set; }

        public int CourseID { get; set; }



        
    }

}
