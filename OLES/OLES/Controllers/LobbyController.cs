using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using OLES.Classes;
using OLES.Classes.Database;
using OLESClass;

namespace OLES.Controllers
{
    [Authorize(Roles = "Lecturer")]
    public class LobbyController : Controller
    {
        // GET: Lobby
        public ActionResult Index()
        {
            ViewBag.LobbyId = "123456";
            return View();
        }

        public ActionResult CreateLobby()
        {
            Teacher currentTeacher = (Teacher)DbFactory.GenericFactory.TeacherGenericCRUD.GetOne(HttpContext.User.Identity.Name);
            return View(currentTeacher.Tests);
        }

        [HttpPost]
        public ActionResult CreateLobby(string testName,int questionCount)
        {
            Teacher currentTeacher = (Teacher)DbFactory.GenericFactory.TeacherGenericCRUD.GetOne(HttpContext.User.Identity.Name);
            var currentTest = currentTeacher.Tests.FirstOrDefault(x => x.Name == testName);
            GlobalVariables.CurrentLobby = currentTeacher.CreateLobby(currentTest, questionCount);
            return RedirectToAction("TestIT", "Home");
        }
        [HttpGet]
        public ActionResult SeeLobies()
        {
            var user = DbFactory.GenericFactory.LobbyGenericCRUD.GetOne(HttpContext.User.Identity.Name);
            var filter = new BsonDocument { { "_id", user._id } };
            return View(DbFactory.GenericFactory.LobbyGenericCRUD.GetAll(filter));
        }
    }
}