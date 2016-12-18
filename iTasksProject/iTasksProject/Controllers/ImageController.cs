using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using iTasksProject.Models;
using System.IO;

namespace iTasksProject.Controllers
{
    public class ImageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //POST : Upload Profile Image
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProfileImage(HttpPostedFileBase file)
        {
            if (file != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                    db.Users.Find(User.Identity.GetUserId()).ProfilePhoto = array;
                }
                db.SaveChanges();
                return RedirectToAction("Index", "Manage");
            }
            else return HttpNotFound("The Image Cannot be Uploaded");
        }

        //POST : Upload Cover Image
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CoverImage(HttpPostedFileBase file)
        {
            if (file != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                    db.Users.Find(User.Identity.GetUserId()).CoverPhoto = array;
                }
                db.SaveChanges();
                return RedirectToAction("Index", "Manage");
            }
            else return HttpNotFound("The Image Cannot be Uploaded");
        }

        //Delete cover image
        public ActionResult DeleteCover()
        {
            var image = db.Users.Find(User.Identity.GetUserId()).CoverPhoto;
            db.Users.Find(User.Identity.GetUserId()).CoverPhoto = null;
            db.SaveChanges();
            return RedirectToAction("Index", "Manage");
        }

        //Delete cover image
        public ActionResult DeleteProfile()
        {
            var image = db.Users.Find(User.Identity.GetUserId()).ProfilePhoto;
            db.Users.Find(User.Identity.GetUserId()).ProfilePhoto = null;
            db.SaveChanges();
            return RedirectToAction("Index", "Manage");
        }
    }
}