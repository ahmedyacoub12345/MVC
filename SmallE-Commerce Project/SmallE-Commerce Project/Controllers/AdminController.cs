using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SmallE_Commerce_Project.Controllers
{
    public class Product
    {
        public string URL { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
    }

    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            var products = Session["products"] as List<Product> ?? new List<Product>();
            return View(products);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "URL,Name,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                var products = Session["products"] as List<Product> ?? new List<Product>();

                if (product != null)
                {
                    products.Add(product);

                    Session["products"] = products;
                }

                return RedirectToAction("Index");
            }

            return View(product);
        }
    }
}
