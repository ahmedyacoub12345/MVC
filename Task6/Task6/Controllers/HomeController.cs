using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Task6.Models;

namespace Task6.Controllers
{
    public class HomeController : Controller
    {
        private RegisterEntities DB=new RegisterEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Register() { return View(); }
        [HttpPost]
        public ActionResult Register(string Name,string Email, string Password, string confirmPass, [Bind(Include = "Name,Email,Password")] User user)
        {
            if (ModelState.IsValid) {
                if (Password == confirmPass) {
                    DB.Users.Add(user);
                    DB.SaveChanges();
                    return RedirectToAction("Register");
                
                }
            
            }
            return View();
        }        
        public ActionResult Login(string Email,string Password) 
        { 
            var user=DB.Users.Where(x=>x.Email==Email&&x.Password==Password).FirstOrDefault();
            if (user != null) {
                Session["is_login"] = true;
                HttpCookie cookie = new HttpCookie("Users");

                cookie.Values["ID"] = user.ID.ToString();
                cookie.Values["Name"] = user.Name;
                cookie.Values["Email"] = user.Email;
                cookie.Values["Password"] = user.Password;

                return RedirectToAction("Profile");

            }
            return View();
        }
        public ActionResult Logout() 
        {
            Session["is_login"] = false;
            return RedirectToAction("Index"); 
        }
        public ActionResult Profile()
        {
            HttpCookie cookie = Request.Cookies["Users"];
            if (cookie != null)
            {
                ViewBag.ID = cookie.Values["ID"].ToString();
                ViewBag.Name = cookie.Values["Name"];
                ViewBag.Email = cookie.Values["Email"];
            }

            return View();
        }



    }
}