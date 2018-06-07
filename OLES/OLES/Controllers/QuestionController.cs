using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OLES.Classes;
using OLESClass;

namespace OLES.Controllers
{
    public class QuestionController : Controller
    {
        // GET: Question
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SeeQuestion()
        {
            if (GlobalVariables.CurrentQuestions.Any())
            {
                if (GlobalVariables.CurrentQuestions.Count == 1)
                {
                    ViewBag.IsLast = true;
                }
                else if (GlobalVariables.CurrentQuestions.Count > 1)
                {
                    ViewBag.IsLast = false;
                }
                var currentQuest = GlobalVariables.CurrentQuestions.Dequeue();
                return View(currentQuest);
            }
            return null;
        }

        [HttpPost]
        public ActionResult SeeQuestion(FormCollection answers)
        {
            //todo get answer
            //todo send question answer to the liveResultScreen
            //todo
            if (GlobalVariables.CurrentQuestions.Any())
            {
                if (GlobalVariables.CurrentQuestions.Count == 1)
                {
                    ViewBag.IsLast = true;
                }
                else if (GlobalVariables.CurrentQuestions.Count > 1)
                {
                    ViewBag.IsLast = false;
                }
                var currentQuest = GlobalVariables.CurrentQuestions.Dequeue();
                return View(currentQuest);
            }
            return null;
        }
    }
}