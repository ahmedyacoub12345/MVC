using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmallE_Commerce_Project.Controllers
{
    public class Admin1Controller : Controller
    {
        // GET: Admin1
        public ActionResult Index()
        {
            List<Dictionary<string, string>> products = Session["Products"] as List<Dictionary<string, string>>;

            if (products == null)
            {
                products = (List<Dictionary<string, string>>)Session["Products"];
            }

            return View(products);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string URL , string Name , string Price)
        {
            List<Dictionary<string, string>> products = Session["Products"] as List<Dictionary<string, string>>;

            if (products == null)
            {
                products = new List<Dictionary<string, string>>();
            }


            Dictionary<string, string> product = new Dictionary<string, string>
            {
                {"Image",URL},
                {"Name",Name},
                {"Price", Price}
                
            };

            products.Add(product);
            Session["Products"] = products;

            return RedirectToAction("Index");
        }

    }
}
