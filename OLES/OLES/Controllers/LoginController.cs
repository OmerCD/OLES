using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using OLES.Classes;
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
        public JsonResult CheckLogin(string userName, string password)
        {
            var user = DbFactory.UserCRUD.CheckLogin(userName, password);
            if (user!=null)
            {
                CustomAuth auth = new CustomAuth(user);
                if (HttpContext.User != null)
                {
                    HttpContext.User = auth;
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(false,JsonRequestBehavior.AllowGet);
        }
    }
}