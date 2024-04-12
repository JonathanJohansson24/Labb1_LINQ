using Labb1_LINQ.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_LINQ.Services
{
    internal class TeacherServices
    {
        public static void GetSpecificTeacher(AppDbContext db)
        {
            Console.ReadKey();
            Console.Clear();
            SubjectService.ShowAllSubjects(db);

            Console.WriteLine("Välj ett ämne där du vill se vilken lärare som undervisar: ");
            string userOption = Console.ReadLine();
            var getTeacher = db.Teachers.Where(t => t.Subjects.Any(s => s.SubjectName == userOption))
                .ToList();


            if (getTeacher.Any())
            {
            Console.WriteLine($"Dessa lärare undervisar i {userOption}: ");

                foreach (var item in getTeacher)
                {
                    Console.WriteLine($"Namn: {item.TeacherName}");
                }
            }
            else
            {
                Console.WriteLine($"Fanns ingen lärare som undervisar i {userOption}");
            }
            Console.ReadKey();
            Console.Clear();
        }
    }
}
