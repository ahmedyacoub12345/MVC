using System.Collections.Generic;
using System.Web.Mvc;

namespace Task2.Controllers
{
    public class ContactController : Controller
    {
        // GET: Home/ContactForm
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(FormCollection form)
        {
            var text = form["Text"];
            var number = form["Number"];
            var radioOption = form["RadioOption"];
            var selectOption = form["SelectOption"];
            var multiSelectOptions = form["MultiSelectOptions"];

            ViewBag.Name = text;
            ViewBag.Age = number;
            ViewBag.Gender = radioOption;
            ViewBag.Specialization = selectOption;
            ViewBag.Major = multiSelectOptions;

            return View("ContactResult");
        }
        public ActionResult ContactResult()
        {
            return View();
        }
    }
}
