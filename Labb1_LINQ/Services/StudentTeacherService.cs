using Labb1_LINQ.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_LINQ.Services
{
    internal class StudentTeacherService
    {
        public static void GetFullCourse(AppDbContext db)
        {
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Nu kommer alla elever, samt klass och respektive lärare listas: \n\n");
            var teacherAndStudent = db.Students
        // Först, joina studenter med kurser
        .Join(db.Courses,
              student => student.CourseID,
              course => course.CourseID,
              (student, course) => new { student, course })
        // Sedan, joina resultatet med lärare
        .Join(db.Teachers,
              studentCourse => studentCourse.course.CourseID,
              teacher => teacher.CourseID,
              (studentCourse, teacher) => new
              {
                  studentCourse.student.FirstName,
                  studentCourse.course.Name,
                  teacher.TeacherName
              })
        .ToList()
        // Gruppera baserat på studentnamn och kursnamn för att hantera flera lärare per kurs
        .GroupBy(sc => sc.Name)
        .Select(group => new
        {
            CourseName = group.Key,
            StudentName = String.Join(", ", group.Select(x => x.FirstName).Distinct()),
            Teachers = String.Join(", ", group.Select(x => x.TeacherName).Distinct())
        });
            foreach (var item in teacherAndStudent)
            {
                Console.WriteLine($"Klass: {item.CourseName} \nStudent: {item.StudentName} \nLärare: {item.Teachers}\n");
            }
            Console.ReadKey();
            Console.Clear();
        }

        public static void UpdateTeacher(AppDbContext db)
        {
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Den personen vi kommer byta handledare för är Olof, \nhans nuvarance handledare heter Anas och kommer bytas till Per-Inge\n\n");
            // Identifiera läraren "Anas"
            var anas = db.Teachers.FirstOrDefault(t => t.TeacherName == "Anas");
            // Identifiera läraren "Per-Inge"
            var perInge = db.Teachers.FirstOrDefault(t => t.TeacherName == "Per-Inge");
            // Hämta studenten "Olof"
            var olof = db.Students.Include(s => s.Course).ThenInclude(c => c.Teachers).FirstOrDefault(s => s.FirstName == "Olof");

            if (anas == null || perInge == null || olof == null)
            {
                Console.WriteLine("Kunde inte hitta en eller flera av de angivna personerna.");
                return;
            }

            // Hämta kursen där både "Anas" undervisar och "Olof" är inskriven
            var course = olof.Course;

            if (course.Teachers.Any(t => t.TeacherID == anas.TeacherID))
            {
                // Om "Anas" är lärare för denna kurs, byt till "Per-Inge"
                //course.Teachers.Remove(anas);  // Ta bort "Anas"
                //course.Teachers.Add(perInge);  // Lägg till "Per-Inge"
                //db.SaveChanges();              // Spara ändringarna
                Console.WriteLine($"Anas har bytts ut mot Per-Inge i kursen {course.Name} där Olof är inskriven.");
            }
            else
            {
                Console.WriteLine("Anas undervisar inte i Olofs kurs.");
            }
            Console.ReadKey();
            Console.Clear();
        }
    }
}
