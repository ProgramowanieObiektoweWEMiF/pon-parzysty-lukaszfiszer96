using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PO_Messenger.Models;
using System.Xml;
namespace PO_Messenger.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View("Index");
        }
        
        [HttpGet]
        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(Users obj)

        {
            if (ModelState.IsValid)
            {
                UsersEntities db = new UsersEntities();
                if (db.Users.Any(p => p.EmialAdress.Equals(obj.EmialAdress)))
                {
                    ModelState.AddModelError(string.Empty, "Email allready exist");
                    return View();
                }
                else
                {
                    db.Users.Add(obj);
                    db.SaveChanges();
                    return View("UserAdded", obj);
                }
            }
            else
                return View();                    
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(Users obj)
        {
            using(UsersEntities db = new UsersEntities())
            {
                var userDetails = db.Users.Where(x => x.EmialAdress == obj.EmialAdress && x.Password == obj.Password).FirstOrDefault();

                if (userDetails == null)
                    return View();
                else
                {
                    Session["userName"] = userDetails.Name;
                    Session["userObj"] = userDetails;

                    return RedirectToAction("UserMain", "Loguser");
                }
            }
                
        }



    }


}