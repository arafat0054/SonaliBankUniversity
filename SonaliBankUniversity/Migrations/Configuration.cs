namespace SonaliBankUniversity.Migrations
{
    using SonaliBankUniversity.DAL;
    using SonaliBankUniversity.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SonaliBankUniversity.DAL.UniversityContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SonaliBankUniversity.DAL.UniversityContext context)
        {
            var students = new List<Student>
            {
                new Student { FirstName = "Arafat",   LastName = "Rahman",
                    EnrollmentDate = DateTime.Parse("2017-03-17") },
                new Student { FirstName = "Sabbir", LastName = "Ahmed",
                    EnrollmentDate = DateTime.Parse("2017-02-21") },
                new Student { FirstName = "Montasir",   LastName = "Rahman",
                    EnrollmentDate = DateTime.Parse("2017-03-11") },
                new Student { FirstName = "Abul",    LastName = "Khair",
                    EnrollmentDate = DateTime.Parse("2016-09-11") },
                new Student { FirstName = "Alamgir",      LastName = "Kabir",
                    EnrollmentDate = DateTime.Parse("2018-09-01") },
                new Student { FirstName = "Nahiyan",    LastName = "Khan",
                    EnrollmentDate = DateTime.Parse("2015-09-21") },
                new Student { FirstName = "Tamim",    LastName = "Iqbal",
                    EnrollmentDate = DateTime.Parse("2019-09-08") },
                new Student { FirstName = "Virat",     LastName = "Kohli",
                    EnrollmentDate = DateTime.Parse("2020-09-01") }
            };


            students.ForEach(s => context.Students.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            var Teachers = new List<Teacher>
            {
                new Teacher { FirstName = "Shariar",     LastName = "Monzur",
                    HireDate = DateTime.Parse("2004-03-11") },
                new Teacher { FirstName = "Asque",    LastName = "Rahman",
                    HireDate = DateTime.Parse("2002-07-06") },
                new Teacher { FirstName = "Rajan",   LastName = "Bardhan",
                    HireDate = DateTime.Parse("2009-07-01") },
                new Teacher { FirstName = "Sifat", LastName = "Ahmed",
                    HireDate = DateTime.Parse("2011-01-15") },
                new Teacher { FirstName = "Maksuda",   LastName = "Rabeya",
                    HireDate = DateTime.Parse("2004-02-12") }
            };
            Teachers.ForEach(s => context.Teachers.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            var departments = new List<Department>
            {
                new Department { Name = "English",     
                    StartDate = DateTime.Parse("2007-09-01"),
                    TeacherID  = Teachers.Single( i => i.LastName == "Rabeya").ID },
                new Department { Name = "CSE", Budget = 1000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    TeacherID  = Teachers.Single( i => i.LastName == "Rahman").ID },
                new Department { Name = "Engineering", Budget = 3500,
                    StartDate = DateTime.Parse("2007-09-01"),
                    TeacherID  = Teachers.Single( i => i.LastName == "Bardhan").ID },
                new Department { Name = "Web Internet",   Budget = 10000,
                    StartDate = DateTime.Parse("2007-09-01"),
                    TeacherID  = Teachers.Single( i => i.LastName == "Monzur").ID }
            };
            departments.ForEach(s => context.Departments.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course {CourseID = 1050, Title = ".net mvc",      Credits = 3,
                  DepartmentID = departments.Single( s => s.Name == "Engineering").DepartmentID,
                  Teachers = new List<Teacher>()
                },
                new Course {CourseID = 4022, Title = "JavaScript", Credits = 3,
                  DepartmentID = departments.Single( s => s.Name == "CSE").DepartmentID,
                  Teachers = new List<Teacher>()
                },
                new Course {CourseID = 4041, Title = "HTML", Credits = 3,
                  DepartmentID = departments.Single( s => s.Name == "Web Internet").DepartmentID,
                  Teachers = new List<Teacher>()
                },
                new Course {CourseID = 1045, Title = "Calculus",       Credits = 3,
                  DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID,
                  Teachers = new List<Teacher>()
                },
                new Course {CourseID = 3141, Title = "bootstrap",   Credits = 1,
                  DepartmentID = departments.Single( s => s.Name == "Design").DepartmentID,
                  Teachers = new List<Teacher>()
                },
                new Course {CourseID = 2021, Title = "Composition",    Credits = 3,
                  DepartmentID = departments.Single( s => s.Name == "English").DepartmentID,
                  Teachers = new List<Teacher>()
                },
                new Course {CourseID = 2042, Title = "Fundamental",     Credits = 4,
                  DepartmentID = departments.Single( s => s.Name == "C").DepartmentID,
                  Teachers = new List<Teacher>()
                },
            };
            courses.ForEach(s => context.Courses.AddOrUpdate(p => p.CourseID, s));
            context.SaveChanges();

            var teacherOffice = new List<TeacherOffice>
            {
                new TeacherOffice {
                    TeacherID = Teachers.Single( i => i.LastName == "Rahman").ID,
                    Location = "Banani 17" },
                new TeacherOffice {
                    TeacherID = Teachers.Single( i => i.LastName == "Bardhan").ID,
                    Location = "Gulshan 2" },
                new TeacherOffice {
                    TeacherID = Teachers.Single( i => i.LastName == "Monzur").ID,
                    Location = "Banani 14" },
            };
            teacherOffice.ForEach(s => context.TeacherOffices.AddOrUpdate(p => p.TeacherID, s));
            context.SaveChanges();



            var enrollments = new List<Enrollment>
            {
                new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Rahman").ID,
                    CourseID = courses.Single(c => c.Title == ".net mvc" ).CourseID,
                    Grade = Grade.A
                },
                 new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Rahman").ID,
                    CourseID = courses.Single(c => c.Title == "JavaScript" ).CourseID,
                    Grade = Grade.C
                 },
                 new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Rahman").ID,
                    CourseID = courses.Single(c => c.Title == "bootstrap" ).CourseID,
                    Grade = Grade.B
                 },
                 new Enrollment {
                     StudentID = students.Single(s => s.LastName == "Ahmed").ID,
                    CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID,
                    Grade = Grade.B
                 },
                 new Enrollment {
                     StudentID = students.Single(s => s.LastName == "Ahmed").ID,
                    CourseID = courses.Single(c => c.Title == "Fundamental" ).CourseID,
                    Grade = Grade.B
                 },
                 new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Ahmed").ID,
                    CourseID = courses.Single(c => c.Title == "Composition" ).CourseID,
                    Grade = Grade.B
                 },
                 new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Khan").ID,
                    CourseID = courses.Single(c => c.Title == "HTML" ).CourseID
                 },
                 new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Khan").ID,
                    CourseID = courses.Single(c => c.Title == "JavaScript").CourseID,
                    Grade = Grade.B
                 },
                new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Khair").ID,
                    CourseID = courses.Single(c => c.Title == "HTML").CourseID,
                    Grade = Grade.B
                 },
                 new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Khair").ID,
                    CourseID = courses.Single(c => c.Title == "Composition").CourseID,
                    Grade = Grade.B
                 },
                 new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Kabir").ID,
                    CourseID = courses.Single(c => c.Title == "JavaScript").CourseID,
                    Grade = Grade.B
                 }
            };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                    s =>
                         s.Student.ID == e.StudentID &&
                         s.Course.CourseID == e.CourseID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();


        }
        void AddOrUpdateTeacher(UniversityContext context, string courseTitle, string TeacherName)
        {
            var crs = context.Courses.SingleOrDefault(c => c.Title == courseTitle);
            var inst = crs.Teachers.SingleOrDefault(i => i.LastName == TeacherName);
            if (inst == null)
                crs.Teachers.Add(context.Teachers.Single(i => i.LastName == TeacherName));
        }
    }
}
