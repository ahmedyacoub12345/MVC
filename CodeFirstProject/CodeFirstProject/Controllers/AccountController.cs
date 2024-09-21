using CodeFirstProject.Models;
using CodeFirstProject.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CodeFirstProject.Controllers
{
    public class AccountController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);
                if (user != null)
                {
                    // Set session variable for authenticated user
                    Session["Username"] = user.Username;
                    return RedirectToAction("Index", "Classes"); // Redirect to home or dashboard
                }
                ModelState.AddModelError("", "Invalid username or password.");
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            Session.Clear(); // Clear session on logout
            return RedirectToAction("Login");
        }

        
    }
}
