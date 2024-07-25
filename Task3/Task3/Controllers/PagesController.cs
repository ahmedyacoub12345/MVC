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
            string[] emails = { "ahmed@yahoo.com", "anas@yahoo.com" };
            string[] passwords = { "123456", "987654321" };

            Session["Email"] = form["Email"];

            string inputEmail = form["Email"];
            string inputPasswords = form["Password"];

            foreach (string email in emails)
            {
                if (inputEmail == email)
                {
                    Session["is_login"] = true;
                    break;
                }
                else
                {
                    Session["is_login"] = false;
                }
            }


            foreach (string password in passwords)
            {
                if (password == inputPasswords)
                {
                    Session["is_login"] = true;

                    return RedirectToAction("Home");
                }
                else
                {
                    Session["is_login"] = false;

                }

            }

            return View();

            //string email = form["Email"];
            //string password = form["Password"];
            //if (email != null && password != null) 
            //{
            //    return View("HomeAfterLogin");
            //}

            //return View();
        }
        public ActionResult Logout()
        {
            Session["is_login"] = false;
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