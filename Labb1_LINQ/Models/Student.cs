using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_LINQ.Models
{
    internal class Student
    {
        [Key]
        public int StudID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }


        // Navigation one student can only belong to one course, wich is what i call the classname atm. 
        public Course Course { get; set; }
        public int CourseID { get; set; }

        //One student can have many different subjects. 
        public ICollection<Subject> Subjects { get; set; }



    }
}
