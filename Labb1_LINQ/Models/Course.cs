using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_LINQ.Models
{
    internal class Course
    {
        [Key]
        public int CourseID { get; set; }
        public string Name { get; set; }


        // One course, or class in this case can have multiple students. 
        public ICollection<Student> Students { get; set; }

        public ICollection<Teacher> Teachers { get; set; }

    }
}
