using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SonaliBankUniversity.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SonaliBankUniversity.DAL
{
    public class UniversityContext : DbContext
    {

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherOffice> TeacherOffices { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Person> People { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Course>()
    .HasMany(c => c.Teachers).WithMany(i => i.Courses)
    .Map(t => t.MapLeftKey("CourseID")
        .MapRightKey("TeacherID")
        .ToTable("CourseTeacher"));

            modelBuilder.Entity<Department>().MapToStoredProcedures();
        }
    }
}