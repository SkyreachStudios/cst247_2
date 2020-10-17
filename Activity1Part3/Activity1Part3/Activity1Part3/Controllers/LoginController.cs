using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Activity1Part3.Models;
using Activity1Part3.Services.Business;

namespace Activity1Part3.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(UserModel model) {
            // Validate the Form POST 
            if (!ModelState.IsValid)
                return View("Login");


            SecurityService service = new SecurityService();


            bool status = service.Authenticate(model);

            if (status)
            {
                return View("LoginPassed",model);
            }
            else
            {
                return View("LoginFailed");
            }

        }


    }
}