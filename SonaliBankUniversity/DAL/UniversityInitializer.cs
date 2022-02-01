using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SonaliBankUniversity.Models;

namespace SonaliBankUniversity.DAL
{
    public class UniversityInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<UniversityContext>
    {
        protected override void Seed(UniversityContext context)
        {
            var students = new List<Student>
            {
            new Student{FirstName="Arafat",LastName="Rahman",EnrollmentDate=DateTime.Parse("2017-03-17")},
            new Student{FirstName="Sabbir",LastName="Ahmed",EnrollmentDate=DateTime.Parse("2017-02-21")},
            new Student{FirstName="Montasir",LastName="Rahman",EnrollmentDate=DateTime.Parse("2017-03-11")},
            new Student{FirstName="Abul",LastName="Khair",EnrollmentDate=DateTime.Parse("2016-09-11")},
            new Student{FirstName="Alamgir",LastName="Kabir",EnrollmentDate=DateTime.Parse("2018-09-01")},
            new Student{FirstName="Nahiyan",LastName="Khan",EnrollmentDate=DateTime.Parse("2015-09-21")},
            new Student{FirstName="Tamim",LastName="Iqbal",EnrollmentDate=DateTime.Parse("2019-09-08")},
            new Student{FirstName="Virat ",LastName="Kohli",EnrollmentDate=DateTime.Parse("2020-09-01")}
            };

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();
            var courses = new List<Course>
            {
            new Course{CourseID=1050,Title=".net mvc",Credits=3,},
            new Course{CourseID=4022,Title="JavaScript",Credits=3,},
            new Course{CourseID=4041,Title="HTML",Credits=3,},
            new Course{CourseID=1045,Title="Calculus",Credits=3,},
            new Course{CourseID=3141,Title="Bootstrap",Credits=1,},
            new Course{CourseID=2021,Title="Composition",Credits=3,},
            new Course{CourseID=2042,Title="Fundamental",Credits=4,}
            };
            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();
            var enrollments = new List<Enrollment>
            {
            new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
            new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
            new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
            new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
            new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F},
            new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.F},
            new Enrollment{StudentID=3,CourseID=1050},
            new Enrollment{StudentID=4,CourseID=1050,},
            new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F},
            new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C},
            new Enrollment{StudentID=6,CourseID=1045},
            new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A},
            };
            enrollments.ForEach(s => context.Enrollments.Add(s));
            context.SaveChanges();
        }
    }
}