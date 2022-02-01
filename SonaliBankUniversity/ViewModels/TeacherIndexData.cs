using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SonaliBankUniversity.Models;
namespace SonaliBankUniversity.ViewModels
{
    public class TeacherIndexData
    {
        public IEnumerable<Teacher> Instructors { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; }
        public IOrderedQueryable<Teacher> Teachers { get; internal set; }
    }
}