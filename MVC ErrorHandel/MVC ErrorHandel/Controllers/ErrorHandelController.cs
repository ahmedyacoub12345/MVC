using MVC_ErrorHandel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ErrorHandel.Controllers
{
    public class ErrorHandelController : Controller
    {
        private E_CommerceEntities db = new E_CommerceEntities();
       
        public ActionResult Index()
        {
            var data = db.Categories.ToList();
            return View(data);
        }
    }
}