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
            // Retrieve the list of products from session
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
                // Retrieve the list of products from session or create a new list if none exists
                var products = Session["products"] as List<Product> ?? new List<Product>();

                if (product != null)
                {
                    // Add the new product to the list
                    products.Add(product);

                    // Save the updated list back to session
                    Session["products"] = products;
                }

                // Redirect to Index to display the updated list
                return RedirectToAction("Index");
            }

            // If the model state is not valid, return to the Create view
            return View(product);
        }
    }
}
