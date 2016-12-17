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

        // GET: Profile Image
        public ActionResult ProfileImage()
        {
            var image = db.Users.Find(User.Identity.GetUserId()).ProfilePhoto;
            if (image != null)
            {
                return File(image, "image/jpg", "ProfilePhoto.jpg");
            }
            else return null;
        }

        // GET: Profile Image
        public ActionResult CoverImage()
        {
            var image = db.Users.Find(User.Identity.GetUserId()).CoverPhoto;
            if (image != null)
            {
                return File(image, "image/jpg", "CoverPhoto.jpg");
            }
            else return null;
        }

        public ActionResult ProfileImage(string id)
        {
            var image = db.Users.Find(id).ProfilePhoto;
            if (image != null)
            {
                return File(image, "image/jpg", "ProfilePhoto.jpg");
            }
            else return null;
        }

        // GET: Profile Image
        public ActionResult CoverImage(string id)
        {
            var image = db.Users.Find(id).CoverPhoto;
            if (image != null)
            {
                return File(image, "image/jpg", "CoverPhoto.jpg");
            }
            else return null;
        }

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
                    db.Users.Find(User.Identity.GetUserId()).CoverPhoto = array;
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
        [HttpGet]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCover()
        {
            var image = db.Users.Find(User.Identity.GetUserId()).CoverPhoto;
            if (image != null)
            {
                db.Users.Find(User.Identity.GetUserId()).CoverPhoto = null;
                db.SaveChanges();
                return RedirectToAction("Index", "Manage");
            }
            else return null;
        }

        //Delete cover image
        [HttpGet]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProfile()
        {
            var image = db.Users.Find(User.Identity.GetUserId()).ProfilePhoto;
            if (image != null)
            {
                db.Users.Find(User.Identity.GetUserId()).ProfilePhoto = null;
                db.SaveChanges();
                return RedirectToAction("Index", "Manage");
            }
            else return null;
        }
    }
}