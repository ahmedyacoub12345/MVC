using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task3.Controllers
{
    public class PagesController : Controller
    {
        // GET: Pages
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Login(FormCollection form)
        {
            string email = form["Email"];
            string password = form["Password"];
            if (email != null && password != null) 
            {
                return View("HomeAfterLogin");
            }

            return View();
        }
        public ActionResult Logout()
        {
            return View("Home");
        }
        public ActionResult Contact(FormCollection form)
        {
            ViewBag.Name= form["name"];
            ViewBag.Email = form["email"];
            ViewBag.Message = form["message"];


            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult HomeAfterLogin()
        {
            return View();
        }
        
    }
}