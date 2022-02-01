using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SonaliBankUniversity.DAL;
using SonaliBankUniversity.ViewModels;
using System.Data.Entity.Infrastructure;

namespace SonaliBankUniversity.Controllers
{
    public class HomeController : Controller
    {
        private UniversityContext db = new UniversityContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            string query = "SELECT EnrollmentDate, COUNT(*) AS StudentCount "
                + "FROM Person "
                + "WHERE Discriminator = 'Student' "
                + "GROUP BY EnrollmentDate";
            IEnumerable<EnrollmentDateGroup> data = db.Database.SqlQuery<EnrollmentDateGroup>(query);
            return View(data.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}