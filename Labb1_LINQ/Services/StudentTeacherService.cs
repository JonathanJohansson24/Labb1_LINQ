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
        // Först, joina studenter med kurser
            var teacherAndStudent = db.Students
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
            Console.WriteLine("Den personen vi kommer byta handledare för är Olof, \nhans nuvarance handledare heter Per-Inge och kommer bytas till Anas\n\n");
            // Identifiera läraren "Anas"
            var anas = db.Teachers.FirstOrDefault(t => t.TeacherName == "Anas");
            // Identifiera läraren "Per-Inge"
            var perInge = db.Teachers.FirstOrDefault(t => t.TeacherName == "Per-Inge");
            // Hämta studenten "Olof"
            var olof = db.Students.Include(s => s.Course)
                                    .ThenInclude(c => c.Teachers)
                                     .FirstOrDefault(s => s.FirstName == "Olof");


            // Kollar ifall alla objekten hittas i databasen annars lokaliserar den vilken som inte hittas. 
            if (anas == null || perInge == null || olof == null)
            {
                Console.WriteLine($"Hittade Anas: {anas != null}, Hittade Per-Inge: {perInge != null}, Hittade Olof: {olof != null}");
                return;
            }

            // Hämta kursen där både "Anas" undervisar och "Olof" är inskriven
            var course = olof.Course;

            if (course.Teachers.Any(t => t.TeacherID == perInge.TeacherID))
            {
                //Om "Per-Inge" är lärare för denna klass, byt till "Anas"
                //course.Teachers.Remove(anas);  // Ta bort "Anas"
                //course.Teachers.Add(perInge);  // Lägg till "Per-Inge"
                //db.SaveChanges();              // Spara ändringarna
                Console.WriteLine($"Per-Inge har bytts ut mot Anas  i klassen: {course.Name} där Olof är inskriven.");
            }
            
            Console.ReadKey();
            Console.Clear();
        }
    }
}
