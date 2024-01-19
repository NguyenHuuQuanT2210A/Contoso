using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Models;

namespace ContosoUniversity.Data
{
    public class ContosoUniversityContext : DbContext
    {
        public ContosoUniversityContext (DbContextOptions<ContosoUniversityContext> options)
            : base(options)
        {
        }

        public DbSet<ContosoUniversity.Models.Student> Student { get; set; } = default!;
        public DbSet<ContosoUniversity.Models.Course> Course { get; set; } = default!;
        public DbSet<ContosoUniversity.Models.Enrollment> Enrollment { get; set; } = default!;
        public DbSet<ContosoUniversity.Models.Department> Department { get; set; } = default!;
        public DbSet<ContosoUniversity.Models.Instructor> Instructor { get; set; } = default!;
        public DbSet<ContosoUniversity.Models.OfficeAssignment> OfficeAssignment { get; set; } = default!;
        public DbSet<ContosoUniversity.Models.CourseAssignment> CourseAssignment { get; set; } = default!;
        //public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<Instructor>().ToTable("Instructor");
            modelBuilder.Entity<OfficeAssignment>().ToTable("OfficeAssignment");
            modelBuilder.Entity<CourseAssignment>().ToTable("CourseAssignment");
            //modelBuilder.Entity<Person>().ToTable("Person");

            modelBuilder.Entity<CourseAssignment>()
                .HasKey(c => new { c.CourseID, c.InstructorID });
        }

    }
}
