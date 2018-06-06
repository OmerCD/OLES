using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OLES.Classes;
using OLESClass;

namespace OLES.Controllers
{
    [Authorize(Roles = "Lecturer")]
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Test test)
        {
            Teacher currentUser = (Teacher)(HttpContext.User as CustomAuth).User;
            currentUser.Tests.Add(test);
            DbFactory.TeacherCRUD.Update(currentUser._id, currentUser);
            return View();
        }
        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(string _id)
        {
            Teacher currentUser = (Teacher)(HttpContext.User as CustomAuth)?.User;
            currentUser.Tests.Remove(currentUser.Tests.FirstOrDefault(x => x._id == _id));
            DbFactory.TeacherCRUD.Update(currentUser._id, currentUser);
            return View();
        }
        [HttpGet]
        public ActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(string _id,Test test)
        {
            Teacher currentUser = (Teacher)(HttpContext.User as CustomAuth)?.User;
            currentUser.Tests.Remove(currentUser.Tests.FirstOrDefault(x => x._id == _id));
            currentUser.Tests.Add(test);
            DbFactory.TeacherCRUD.Update(currentUser._id, currentUser);
            return View();
        }
    }
}