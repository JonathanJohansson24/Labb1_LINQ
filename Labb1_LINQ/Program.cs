using Labb1_LINQ.Data;
using Labb1_LINQ.Models;
using Labb1_LINQ.Services;

namespace Labb1_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using AppDbContext db = new AppDbContext();


            var subjectOne = new Subject() { SubjectName = "Programering 1" };
            var subjectTwo = new Subject() { SubjectName = "Avancerad .NET" };
            var subjectThree = new Subject() { SubjectName = "Databas Utveckling" };
            var subjectFour = new Subject() { SubjectName = "Web Utveckling" };
            var subjectFive = new Subject() { SubjectName = "Matte" };
            //db.Subjects.AddRange(new[] { subjectOne, subjectTwo, subjectThree, subjectFour, subjectFive });

            //var courseOne = new Course() { Name = "SUT23" };
            //var courseTwo = new Course() { Name = "SUT22" };
            //var courseThree = new Course() { Name = "SUT21" };
            //db.Courses.AddRange(new[] { courseOne, courseTwo, courseThree });


            //var teacherOne = new Teacher()
            //{

            //    TeacherName = "Anas",
            //    CourseID = 1,
            //    Subjects = new List<Subject>() { subjectOne }
            //};
            //var teacherTwo = new Teacher()
            //{

            //    TeacherName = "Tobias",
            //    CourseID = 2,
            //    Subjects = new List<Subject>() {subjectTwo}
            //};
            //var teacherThree = new Teacher()
            //{

            //    TeacherName = "Sara",
            //    CourseID = 3,
            //    Subjects = new List<Subject>(){subjectFour, subjectThree}
            //};
            //var teacherFour = new Teacher()
            //{
            //    TeacherName = "Per-Inge",
            //    CourseID = 2,
            //    Subjects = new List<Subject>() {subjectFive}
            //};
            //var teacherFive = new Teacher()
            //{

            //    TeacherName = "Elin",
            //    CourseID = 1,
            //    Subjects = new List<Subject>() { subjectOne }
            //};
            //db.Teachers.AddRange(new[] { teacherOne, teacherTwo, teacherThree, teacherFour, teacherFive });

            //var studentOne = new Student()
            //{

            //    FirstName = "Philip",
            //    LastName = "Jönsson",
            //    CourseID = 1,
            //    Subjects = new List<Subject>() { subjectOne, subjectTwo }
            //};
            //var studentTwo = new Student()
            //{

            //    FirstName = "Olof",
            //    LastName = "Sandberg",
            //    CourseID = 1,
            //    Subjects = new List<Subject>() { subjectOne, subjectFour }
            //};
            //var studentThree = new Student()
            //{

            //    FirstName = "Anna",
            //    LastName = "Söderberg",
            //    CourseID = 1,
            //    Subjects = new List<Subject>() { subjectFour, subjectTwo }
            //};
            //var studentFour = new Student()
            //{

            //    FirstName = "Emma",
            //    LastName = "Nordin",
            //    CourseID = 2,
            //    Subjects = new List<Subject>() { subjectOne, subjectFive }
            //};
            //var studentFive = new Student()
            //{

            //    FirstName = "Asuka",
            //    LastName = "Hana",
            //    CourseID = 3,
            //    Subjects = new List<Subject>() { subjectThree }
            //};
            //db.Students.AddRange(new[] { studentOne, studentTwo, studentThree, studentFour, studentFive });

            //var studentSix = new Student()
            //{
            //    FirstName = "Lasse",
            //    LastName = "Kongo",
            //    CourseID = 3,
            //    Subjects = new List<Subject>() {subjectOne, subjectThree, subjectFive }
            //};
            //db.Students.Add(studentSix);
            //db.SaveChanges();

            //StudentTeacherService.UpdateTeacher(db);
            //TeacherServices.GetSpecificTeacher(db);
            //StudentTeacherService.GetFullCourse(db);
            //SubjectService.FindSubject(db);
            //SubjectService.UpdateSubject(db);

            bool keepGoing = true; 
            while (keepGoing)
            {
                Console.WriteLine($@"
Du kommer nu få sex val: 
1. Hämta alla lärare som undervisar i en specifikt kurs: 
2. Hämta alla klasser inklusive lärare och elever: 
3. Hämta all information om en specifik kurs: 
4. Uppdatera namnet på en specifik kurs: 
5. Ändra handledare i klassen:
6. Avsluta: 

Var god gör ett val genom att knappa in en siffra mellan 1-6");

                int choice = 0; try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Felaktig inmatning, använd endast siffror");
                    Console.ReadKey();
                    Console.Clear();
                }

                switch (choice)
                {
                    case 1:
                        TeacherServices.GetSpecificTeacher(db);
                        break;
                    case 2:
                        StudentTeacherService.GetFullCourse(db);
                        break;
                    case 3:
                        SubjectService.FindSubject(db);
                        break;
                    case 4:
                        SubjectService.UpdateSubject(db);
                        break;
                    case 5:
                        StudentTeacherService.UpdateTeacher(db);
                        break;
                    case 6:
                        Console.WriteLine("Du har valt att avsluta, appen stängs ner");
                        keepGoing = false;
                        break;
                    default:
                        Console.WriteLine("Var god välj en siffra mellan 1-6");
                        break;

                }
            }
        }
    }
}
