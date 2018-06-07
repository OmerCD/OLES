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
            Session["LastLobbyOwner"] = GlobalVariables.CurrentLobby.LobbyOwner;

            if (GlobalVariables.CurrentQuestions != null && GlobalVariables.CurrentQuestions.Any())
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
                Session["LastQuestionId"] = currentQuest._id;
                return View(currentQuest);
            }
            return null;
        }

        [HttpPost]
        public ActionResult SeeQuestion(FormCollection answers)
        {
            Session["GivenAnswers"] = answers;
            Session["LastLobbyOwner"] = GlobalVariables.CurrentLobby.LobbyOwner;
            //todo get answer
            //todo send question answer to the liveResultScreen
            //todo
            var neVerir = answers["showAll"].Split(',');
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
                Session["LastQuestionId"] = currentQuest._id;
                return View(currentQuest);
            }
            return null;
        }

        public JsonResult GetLobbyOwner()
        {
            var lobbyOwner = (string)Session["LastLobbyOwner"];
            
            return Json(lobbyOwner, JsonRequestBehavior.AllowGet);
        }
    }
}