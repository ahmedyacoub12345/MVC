using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CodeFirstProject.Models;

public class TasksController : Controller
{
    private SchoolContext db = new SchoolContext();

    public ActionResult Index()
    {
        return View(db.Tasks.ToList());
    }

    public ActionResult Create()
    {
        ViewBag.Classes = new SelectList(db.Classes, "Id", "Name"); // Populate ViewBag
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Task task)
    {
        if (ModelState.IsValid)
        {
            db.Tasks.Add(task);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        ViewBag.Classes = new SelectList(db.Classes, "Id", "Name", task.ClassId); // Repopulate ViewBag on error
        return View(task);
    }


    public ActionResult Edit(int id)
    {
        var task = db.Tasks.Find(id);
        if (task == null)
        {
            return HttpNotFound();
        }

        ViewBag.Classes = new SelectList(db.Classes, "Id", "Name", task.ClassId); // Populate ViewBag
        return View(task);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Task task)
    {
        if (ModelState.IsValid)
        {
            db.Entry(task).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        ViewBag.Classes = new SelectList(db.Classes, "Id", "Name", task.ClassId); // Repopulate ViewBag on error
        return View(task);
    }


    public ActionResult Delete(int id)
    {
        var task = db.Tasks.Find(id);
        return View(task);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        var task = db.Tasks.Find(id);
        db.Tasks.Remove(task);
        db.SaveChanges();
        return RedirectToAction("Index");
    }
}
