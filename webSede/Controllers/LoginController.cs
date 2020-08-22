using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webSede.Models;

namespace webSede.Controllers
{
    public class LoginController : Controller
    {
        private dbsedesEntities db = new dbsedesEntities();
        // GET: Login
        public ActionResult Index(string message="")
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logear( string email, string password)
        {
            if(!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
               var user= db.Usuario.FirstOrDefault(e => e.email == email && e.password == password);

                if(user!=null)
                {
                    return Index();

                }
                else
                {
                    RedirectToAction("Index", "Home");
                }


            }
            else
            {
                return Index();
            }

            return View();

        }
    }
}