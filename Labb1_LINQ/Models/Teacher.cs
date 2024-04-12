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



        public static void GetAllTeachers()
        {
            var subjects = new List<Subject>();
            var teachers = new List<Teacher>()
            {
                new Teacher() { TeacherID = 1, TeacherName = "Anas", CourseID = 1,
                Subjects = new List<Subject>(){ subjects.FirstOrDefault(s => s.SubjectID == 1),
                subjects.FirstOrDefault(s => s.SubjectID == 2),} },

                new Teacher() {TeacherID = 2, TeacherName = "Tobias", CourseID = 2,
                    Subjects = new List<Subject>(){ subjects.FirstOrDefault(s => s.SubjectID == 2)} },

                new Teacher() {TeacherID= 3, TeacherName = "Sara", CourseID = 3,
                    Subjects = new List<Subject>(){ subjects.FirstOrDefault(s => s.SubjectID == 3),
                subjects.FirstOrDefault(s => s.SubjectID == 4),} },

                new Teacher() {TeacherID= 4, TeacherName = "Per-Inge", CourseID = 4,
                    Subjects = new List<Subject>(){ subjects.FirstOrDefault(s => s.SubjectID == 5)} },

                new Teacher() {TeacherID= 5, TeacherName = "Elin", CourseID = 5,
                    Subjects = new List<Subject>(){ subjects.FirstOrDefault(s => s.SubjectID == 5)} },

                new Teacher() {TeacherID= 6, TeacherName = "Elvira", CourseID = 6,
                    Subjects = new List<Subject>(){ subjects.FirstOrDefault(s => s.SubjectID == 6)} }
            };
        }
    }

}
