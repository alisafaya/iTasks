using iTasksProject.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iTasksProject.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: iTasks
        public ActionResult Index()
        {
            var users = db.Users.ToList();
            var messages = db.ContactMessageModels.ToList();
            var model = new AdminViewModel { Users = users, Messages = messages };
            return View("Index",model);
        }

        // GET: iTasks/Delete/5
        public ActionResult DeleteUser(string id)
        {
            if (User.Identity.GetUserId() == id)
            {
                return RedirectToAction("Index");
            }
            ApplicationUser user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteMessage(int? id)
        {
            ContactMessageModel message = db.ContactMessageModels.Find(id);
            db.ContactMessageModels.Remove(message);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ProfileImage()
        {
            var image = db.Users.Find(User.Identity.GetUserId()).ProfilePhoto;
            if (image != null)
            {
                return File(image, "image/jpg", "ProfilePhoto.jpg");
            }
            else return Content(Url.Content("~/Content/iTasksTemplate") + "/img/default-profile.png");
        } 

        public ActionResult userImage(string Id)
        {
            var image = db.Users.Find(Id).ProfilePhoto;
            if (image != null)
            {
                return File(image, "image/jpg", "ProfilePhoto.jpg");
            }
            else return Content(Url.Content("~/Content/iTasksTemplate") + "/img/default-profile.png");
        }

        // GET: Profile Image
        public ActionResult CoverImage()
        {
            var image = db.Users.Find(User.Identity.GetUserId()).CoverPhoto;
            if (image != null)
            {
                return File(image, "image/jpg", "CoverPhoto.jpg");
            }
            else return new EmptyResult();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}