using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_LINQ.Models
{
    internal class Subject
    {
        [Key]
        public int SubjectID { get; set; }

        public string SubjectName { get; set; }


        // Navigation a subject can have multiple teachers
        public ICollection<Teacher> Teachers { get; set; }

        // Subject can have multiple students
        public ICollection<Student> Students { get; set; }

    }
}
