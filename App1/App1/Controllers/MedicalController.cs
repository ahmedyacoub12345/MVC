using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App1.Controllers
{
    public class MedicalController : Controller
    {
        // GET: Medical
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Logout()
        {
            return View();
        }
        public ActionResult Contact() 
        {
            return View();
        }
        public ActionResult Register() 
        {
            return View();
        }

    }
}