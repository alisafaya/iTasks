using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using iTasksProject.Models;
using System.IO;
using Microsoft.AspNet.Identity;

namespace iTasksProject.Controllers
{
    public class ContactMessageModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ContactMessageModels
        public ActionResult Index()
        {
            return View(db.ContactMessageModels.ToList());
        }

        // GET: ContactMessageModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactMessageModel contactMessageModel = db.ContactMessageModels.Find(id);
            if (contactMessageModel == null)
            {
                return HttpNotFound();
            }
            return View(contactMessageModel);
        }

        // GET: ContactMessageModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactMessageModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        // GET: ContactMessageModels/Edit/5
        public ActionResult Edit()
        {
            return null;
        }

        // POST: ContactMessageModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        // GET: ContactMessageModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactMessageModel contactMessageModel = db.ContactMessageModels.Find(id);
            if (contactMessageModel == null)
            {
                return HttpNotFound();
            }
            return View(contactMessageModel);
        }

        // POST: ContactMessageModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactMessageModel contactMessageModel = db.ContactMessageModels.Find(id);
            db.ContactMessageModels.Remove(contactMessageModel);
            db.SaveChanges();
            return RedirectToAction("Index");
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
