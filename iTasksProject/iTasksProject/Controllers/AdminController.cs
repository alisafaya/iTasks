using iTasksProject.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iTasksProject.Controllers
{
    [Authorize(Roles ="admin")]
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

        public ActionResult AddRoleToUser(string Id)
        {
            var rolestore = new RoleStore<IdentityRole>(db);
            var rolemanager = new RoleManager<IdentityRole>(rolestore);
            if (rolemanager.RoleExists("admin") == false)
            {
                rolemanager.Create(new IdentityRole("admin"));
            }
            var userstore = new UserStore<ApplicationUser>(db);
            var usermanager = new UserManager<ApplicationUser>(userstore);

            var user = db.Users.Find(Id);

            if (user != null)
            {
                if (!usermanager.IsInRole(user.Id, "admin"))
                {
                    usermanager.AddToRole(user.Id, "admin");
                }
            }
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");
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
            else
            {
                string path = Server.MapPath("..") + Url.Content("~/Content/iTasksTemplate") + "/img/default-profile.png";
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                StreamReader sw = new StreamReader(fs);

                byte[] photo = new byte[fs.Length];
                fs.Read(photo, 0, (int)fs.Length);
                return File(photo, "image/jpg", "ProfilePhoto.jpg");
            }
        } 

        public ActionResult userImage(string Id)
        {
            var image = db.Users.Find(Id).ProfilePhoto;
            if (image != null)
            {
                return File(image, "image/jpg", "ProfilePhoto.jpg");
            }
            else
            {
                string path = Server.MapPath("..") + Url.Content("~/Content/iTasksTemplate") + "/img/default-profile.png";
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                StreamReader sw = new StreamReader(fs);

                byte[] photo = new byte[fs.Length];
                fs.Read(photo, 0, (int)fs.Length);
                return File(photo, "image/jpg", "ProfilePhoto.jpg");
            }
        }

        // GET: Profile Image
        public ActionResult CoverImage()
        {
            var image = db.Users.Find(User.Identity.GetUserId()).CoverPhoto;
            if (image != null)
            {
                return File(image, "image/jpg", "CoverPhoto.jpg");
            }
            else
            {
                string path = Server.MapPath("..") + Url.Content("~/Content/iTasksTemplate") + "/img/default-cover.jpg";
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                StreamReader sw = new StreamReader(fs);

                byte[] photo = new byte[fs.Length];
                fs.Read(photo, 0, (int)fs.Length);
                return File(photo, "image/jpg", "CoverPhoto.jpg");
            }
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