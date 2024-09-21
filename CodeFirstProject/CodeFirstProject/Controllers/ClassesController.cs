using CodeFirstProject.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CodeFirstProject.Models;

public class ClassesController : Controller
{
    private SchoolContext db = new SchoolContext();

    public ActionResult Index()
    {
        return View(db.Classes.ToList());
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Class cls)
    {
        if (ModelState.IsValid)
        {
            db.Classes.Add(cls);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(cls);
    }

    public ActionResult Edit(int id)
    {
        var cls = db.Classes.Find(id);
        return View(cls);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Class cls)
    {
        if (ModelState.IsValid)
        {
            db.Entry(cls).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(cls);
    }

    public ActionResult Delete(int id)
    {
        var cls = db.Classes.Find(id);
        return View(cls);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        var cls = db.Classes.Include("Students").Include("Tasks").SingleOrDefault(c => c.Id == id);
        db.Classes.Remove(cls);
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Students(int id)
    {
        var students = db.Students.Where(s => s.ClassId == id).ToList();
        return View(students);
    }


    public ActionResult Tasks(int id)
    {
        var tasks = db.Tasks.Where(t => t.ClassId == id).ToList();
        ViewBag.ClassId = id;
        return View(tasks);
    }
}
