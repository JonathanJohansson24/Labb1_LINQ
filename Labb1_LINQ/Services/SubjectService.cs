using Labb1_LINQ.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_LINQ.Services
{
    internal class SubjectService
    {

        public static void FindSubject(AppDbContext db)            // METOD FÖR ATT KOLLA OM ETT SPECIFIKT ÄMNE FINNS MED ELLER INTE
        {
            Console.ReadKey();
            Console.Clear();
            ShowAllSubjects(db);
            Console.WriteLine("Var god mata in namnet på den kurs du vill få mer info om");

            string option = Console.ReadLine();

            var findSubject = db.Subjects
                                .Where(s => s.SubjectName
                                .Contains(option))
                                 .Select(s => new
                                 {
                                     s.SubjectName,
                                     Teachers = s.Teachers.Select(t => t.TeacherName)
                                 }).ToList();

            if (findSubject.Any())
            {
                foreach (var item in findSubject)
                {
                    Console.WriteLine($"Kursen: {item.SubjectName}. \t Lärare i kursen: {string.Join(", ", item.Teachers)}");
                }
            }
            else
            {
                Console.WriteLine("Ämnet finns inte på skolan");
            }
            Console.ReadKey();
            Console.Clear();
        }

        public static void UpdateSubject(AppDbContext db)
        {
            Console.ReadKey();
            Console.Clear();
            ShowAllSubjects(db);
            Console.WriteLine("Var god välj kursen du vill byta namn på: ");
            string choice = Console.ReadLine();
            var updateObject = db.Subjects.FirstOrDefault(s => s.SubjectName == choice);

            if (updateObject != null)
            {
                
                
                Console.Clear();
                Console.WriteLine("Vad vill du döpa om kursen till?");
                string updatedName = Console.ReadLine(); 
                //updateObject.SubjectName = updatedName;
                Console.WriteLine($"Kursen har bytt namn till {updatedName}   \nTryck på valfri tagent för att se den uppdaterade listan av kurser");
                Console.ReadKey();
                ShowAllSubjects(db);
            }

            else
            {
                Console.WriteLine("Inget ämne med det angivna namnet existerar");
            }
            Console.ReadKey();
            Console.Clear();

        }
        public static void ShowAllSubjects(AppDbContext db)
        {
            Console.WriteLine("Dessa kursen är de vi har just nu:");
                foreach (var item in db.Subjects)
                    {
                        Console.WriteLine($"Kurs: {item.SubjectName}");
                    }

        }
    }
}
