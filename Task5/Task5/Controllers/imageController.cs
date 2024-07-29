using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Task5.Models;

namespace Task5.Controllers
{
    public class imageController : Controller
    {
        private imageTaskEntities db = new imageTaskEntities();

        // GET: image
        public ActionResult Index()
        {
            return View(db.imgs.ToList());
        }

        // GET: image/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            img img = db.imgs.Find(id);
            if (img == null)
            {
                return HttpNotFound();
            }
            return View(img);
        }

        // GET: image/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: image/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Age")] img image, HttpPostedFileBase upload)
        {
            if (!Directory.Exists(Server.MapPath("~/Images/")))
            {
                Directory.CreateDirectory(Server.MapPath("~/Images/"));
            }
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(upload.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images/"), fileName);

                    

                    upload.SaveAs(path);
                    image.image = fileName;
                }

                db.imgs.Add(image);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(image); // Return view with model if model state is not valid
        }

        // GET: image/Edit/5
        public ActionResult Edit(int? id)
        {
            img image = db.imgs.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        // POST: image/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Age")] img image, HttpPostedFileBase upload)

        {
            if (upload != null && upload.ContentLength > 0)
            {
                var fileName = Path.GetFileName(upload.FileName);
                var path = Path.Combine(Server.MapPath("~/Images/"), fileName);

                if (!Directory.Exists(Server.MapPath("~/Images/")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Images/"));
                }

                upload.SaveAs(path);
                image.image = fileName;
            }

            db.Entry(image).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: image/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            img img = db.imgs.Find(id);
            if (img == null)
            {
                return HttpNotFound();
            }
            return View(img);
        }

        // POST: image/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            img img = db.imgs.Find(id);
            db.imgs.Remove(img);
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
