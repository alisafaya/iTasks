using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using iTasksProject.Models;

namespace iTasksProject.Controllers
{
    [Authorize]
    public class iTasksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: iTasks
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var user = db.Users.Find(userId);
            var model = new iTaskViewModel();
            model.tasks = db.iTasks.Select(m => m).Where(m => m.User.Id == user.Id).ToList();
            model.task = new iTask();
            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            iTask iTask = db.iTasks.Find(id);
            db.iTasks.Remove(iTask);
            db.SaveChanges();
            var userId = User.Identity.GetUserId();
            var user = db.Users.Find(userId);
            var model = new iTaskViewModel();
            model.tasks = db.iTasks.Select(m => m).Where(m => m.User.Id == user.Id).ToList();
            model.task = db.iTasks.Find(id);
            return View("Index", model);
        }


        // POST: iTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(iTaskViewModel iTask)
        {
            var userId = User.Identity.GetUserId();
            var user = db.Users.Find(userId);
            var model = new iTaskViewModel();
            model.tasks = db.iTasks.Select(m => m).Where(m => m.User.Id == user.Id).ToList();
            model.task = null;
            if (ModelState.IsValid)
            {
                if (db.iTasks.Find(iTask.task.Id) != null)
                {
                    db.iTasks.Remove(iTask.task);
                }
                iTask.task.User = user;
                db.iTasks.Add(iTask.task);
                db.SaveChanges();
                return RedirectToAction("Index" , model );
            }
            model.task = iTask.task;
            return View("Index",model);
        }

        // GET: iTasks/Edit/5
        public ActionResult MarkComplete(int id)
        {
            if (ModelState.IsValid)
            {
                bool complete = db.iTasks.Find(id).Complete;
                db.iTasks.Find(id).Complete = !complete;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        // GET: iTasks/Delete/5
        public ActionResult Delete(int? id)
        {
            iTask iTask = db.iTasks.Find(id);
            db.iTasks.Remove(iTask);
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
