using CodeFirstProject.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CodeFirstProject.Models;

public class SubjectsController : Controller
{
    private SchoolContext db = new SchoolContext();

    public ActionResult Index()
    {
        return View(db.Subjects.ToList());
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Subject subject)
    {
        if (ModelState.IsValid)
        {
            db.Subjects.Add(subject);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(subject);
    }

    public ActionResult Edit(int id)
    {
        var subject = db.Subjects.Find(id);
        return View(subject);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Subject subject)
    {
        if (ModelState.IsValid)
        {
            db.Entry(subject).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(subject);
    }

    public ActionResult Delete(int id)
    {
        var subject = db.Subjects.Find(id);
        return View(subject);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        var subject = db.Subjects.Find(id);
        db.Subjects.Remove(subject);
        db.SaveChanges();
        return RedirectToAction("Index");
    }
}
