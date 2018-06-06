using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using OLES.Classes;
using OLES.Classes.Database;
using OLESClass;

namespace OLES.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        //public ActionResult Index()
        //{
        //    return PartialView();
        //}
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            var currentUser = DbFactory.UserCRUD.CheckLogin(user);
          
            if (currentUser != null)
            {
                
                CustomAuth auth = new CustomAuth(currentUser);
                if (HttpContext.User != null)
                {
                    HttpContext.User = auth;
                    FormsAuthentication.SetAuthCookie(currentUser._id, false);
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                ModelState.AddModelError("","Invalid User Name or Password");
            }

            return View();
        }
    }
}