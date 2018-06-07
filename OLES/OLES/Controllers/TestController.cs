using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OLES.Classes;
using OLES.Classes.Database;
using OLESClass;

namespace OLES.Controllers
{

    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            Teacher currentUser = (DbFactory.TeacherCRUD.GetOne(HttpContext.User.Identity.Name));
            return View(currentUser.Tests);
        }
        //   [Authorize(Roles = "Lecturer")]
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.CurrentTest = GlobalVariables.CurrentTest;
            return View();

        }

        //  [Authorize(Roles = "Lecturer")]
        [HttpPost]
        public ActionResult Create(Test test)
        {
            Teacher currentUser = (DbFactory.TeacherCRUD.GetOne(HttpContext.User.Identity.Name));
            test.Questions = GlobalVariables.CurrentTest.Questions;
            currentUser.Tests.Add(test);

            DbFactory.TeacherCRUD.Update(currentUser._id, currentUser);
            return RedirectToAction("Index","Test");
        }
        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(string _id)
        {
            Teacher currentUser = (DbFactory.TeacherCRUD.GetOne(HttpContext.User.Identity.Name));
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
        public ActionResult Update(string _id, Test test)
        {
            Teacher currentUser = (DbFactory.TeacherCRUD.GetOne(HttpContext.User.Identity.Name));
            currentUser.Tests.Remove(currentUser.Tests.FirstOrDefault(x => x._id == _id));
            currentUser.Tests.Add(test);
            DbFactory.TeacherCRUD.Update(currentUser._id, currentUser);
            return View();
        }

        public ActionResult CreateQuestion()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult CreateQuestion(Question question, FormCollection answers)
        {
            var questionTexts = answers["AnswerText"].Split(',');
            var questionAnswer = answers["Checked"].Split(',');
            for (int i = 0; i < questionTexts.Length; i++)
            {
                var currentAnswer = new Answer(questionTexts[i], Convert.ToBoolean(questionAnswer[i]));
                question.Answers.Add(currentAnswer);
            }
            GlobalVariables.CurrentTest.Questions.Add(question);
            return RedirectToAction("Create", "Test");
        }
        public ActionResult CreateAnswer()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult CreateAnswer(FormCollection answers)
        {

            return null;
        }
    }
}