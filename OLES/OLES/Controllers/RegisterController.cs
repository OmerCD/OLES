using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using OLES.Classes.Database;
using OLESClass;

namespace OLES.Controllers
{
    public class RegisterController : Controller
    {
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Student student)
        {
            ViewBag.IsRegistered = DbFactory.StudentCRUD.Insert(student);
            return View();
        }
        [AllowAnonymous]
        public ActionResult IsUniqueEmail(string email)
        {
            var userExist = DbFactory.UserCRUD.CheckColumn("EMail", email);
            return Json(!userExist, JsonRequestBehavior.AllowGet);
        }
        [AllowAnonymous]
        public ActionResult IsUniqueUserName(string userName)
        {
            var userExist = DbFactory.UserCRUD.CheckColumn("UserName",userName);
            return Json(!userExist, JsonRequestBehavior.AllowGet);
        }
    }
}