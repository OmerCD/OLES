using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        public ActionResult Register(Student student)
        {
            ViewBag.IsRegistered = DbFactory.StudentCRUD.Insert(student);
            return View();
        }
    }
}