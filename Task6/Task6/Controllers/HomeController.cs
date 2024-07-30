using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task6.Models;

namespace Task6.Controllers
{
    public class HomeController : Controller
    {
        private RegisterEntities db= new RegisterEntities();
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
        public ActionResult Register() 
        { 
            return View(); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(string Name, string Email, string Password, string confirmPass, [Bind(Include = "Name,Email,Password")] User user, HttpPostedFileBase upload)
        {
            if (!Directory.Exists(Server.MapPath("~/Images/")))
            {
                Directory.CreateDirectory(Server.MapPath("~/Images/"));
            }
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(upload.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images/"), fileName);

                    upload.SaveAs(path);
                    user.Image = fileName;
                }

                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View();
        }
        public ActionResult Login(string Email, string Password)
        {
            var user = db.Users.Where(x => x.Email == Email && x.Password == Password).FirstOrDefault();
            if (user != null)
            {
                Session["is_login"] = true;
                HttpCookie cookie = new HttpCookie("Users");

                cookie.Values["ID"] = user.ID.ToString();
                cookie.Values["Name"] = user.Name;
                cookie.Values["Email"] = user.Email;
                cookie.Values["Password"] = user.Password;
                cookie.Values["Image"] = user.Image;

                Response.Cookies.Add(cookie);

                return RedirectToAction("Index");


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
                ViewBag.Image = cookie.Values["Image"];
            }

            return View();
        }
        public ActionResult EditProfile()
        {
            HttpCookie cookie = Request.Cookies["Users"];
            if (cookie != null)
            {
                ViewBag.ID = cookie.Values["ID"];
                ViewBag.UserName = cookie.Values["Name"];
                ViewBag.UserEmail = cookie.Values["Email"];
                ViewBag.UserImage = cookie.Values["Image"];
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile(string name, HttpPostedFileBase upload, string currentPassword, string newPassword, string confirmNewPassword)
        {
            HttpCookie cookie = Request.Cookies["Users"];
            if (cookie != null)
            {
                int userId = int.Parse(cookie.Values["ID"]);
                var user = db.Users.Find(userId);

                if (user != null && user.Password == currentPassword)
                {
                    user.Name = name;

                    if (upload != null && upload.ContentLength > 0)
                    {
                        string fileName = Path.GetFileName(upload.FileName);
                        string path = Path.Combine(Server.MapPath("~/Images"), fileName);
                        upload.SaveAs(path);
                        user.Image = fileName;
                    }

                    if (!string.IsNullOrEmpty(newPassword) && newPassword == confirmNewPassword)
                    {
                        user.Password = newPassword;
                    }

                    db.SaveChanges();


                    cookie.Values["Name"] = user.Name;
                    cookie.Values["Image"] = user.Image;
                    Response.Cookies.Set(cookie);

                    return RedirectToAction("Profile");
                }
                else
                {
                    ViewBag.ErrorMessage = "Current password is incorrect.";
                }
            }
            return View();
        }
    }
}