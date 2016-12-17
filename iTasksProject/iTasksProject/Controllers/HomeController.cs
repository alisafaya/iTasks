using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iTasksProject.Models;

namespace iTasksProject.Controllers
{
    
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "Id,userName,userEmail,subject,message")] ContactMessageModel contactMessageModel)
        {
            if (ModelState.IsValid)
            {
                db.ContactMessageModels.Add(contactMessageModel);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(contactMessageModel);
        }
    }
}