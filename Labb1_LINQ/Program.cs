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
