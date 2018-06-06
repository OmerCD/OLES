﻿using System;
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
            return View();
        }
     //   [Authorize(Roles = "Lecturer")]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
      //  [Authorize(Roles = "Lecturer")]
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

        public ActionResult CreateQuestion()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult CreateQuestion(Question question)
        {
            return PartialView();
        }
        public ActionResult CreateAnswer()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult CreateAnswer(List<Answer> answers)
        {
          
            
            return PartialView();
        }
    }
}