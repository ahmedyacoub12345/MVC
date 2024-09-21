using CodeFirstProject.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CodeFirstProject.Models;

public class StudentsController : Controller
{
    private SchoolContext db = new SchoolContext();

    public ActionResult Index()
    {
        return View(db.Students.ToList());
    }

    public ActionResult Create()
    {
        ViewBag.ClassId = new SelectList(db.Classes, "Id", "Name");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Student student)
    {
        if (ModelState.IsValid)
        {
            db.Students.Add(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // If we reach this point, something failed, redisplay the form
        ViewBag.ClassId = new SelectList(db.Classes, "Id", "Name", student.ClassId);
        return View(student);
    }



    public ActionResult Edit(int id)
    {
        var student = db.Students.Find(id);
        if (student == null)
        {
            return HttpNotFound();
        }

        ViewBag.ClassId = new SelectList(db.Classes, "Id", "Name", student.ClassId);
        return View(student);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Student student)
    {
        if (ModelState.IsValid)
        {
            db.Entry(student).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        ViewBag.ClassId = new SelectList(db.Classes, "Id", "Name", student.ClassId);
        return View(student);
    }


    public ActionResult Delete(int id)
    {
        var student = db.Students.Find(id);
        return View(student);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        var student = db.Students.Find(id);
        db.Students.Remove(student);
        db.SaveChanges();
        return RedirectToAction("Index");
    }
}
