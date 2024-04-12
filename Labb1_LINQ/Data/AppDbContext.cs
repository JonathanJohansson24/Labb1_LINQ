using Labb1_LINQ.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.AppConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_LINQ.Data
{
    internal class AppDbContext : DbContext
    {

        public DbSet<Course> Courses { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Teacher> Teachers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source = DESKTOP-53F8V9T;Initial Catalog = Labb1_LINQ;Integrated Security=True;TrustServerCertificate=Yes;");
        }
    }
}
