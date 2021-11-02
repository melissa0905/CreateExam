using BusinessLogicLayer;
using CreateExam.Models;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateExam.Controllers
{
    public class TestController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            var model = new TestViewModel
            {
                TestList = TestBusiness.GetTestList(Convert.ToInt32(HttpContext.Session.GetInt32("userId")))
            };
            return View(model);
        }
        [Authorize]
        public IActionResult DeleteTest(int id)
        {
            var test = TestBusiness.GetTest(id);
            TestBusiness.DeleteTest(test);
            return RedirectToAction("Index");
        }
        [Authorize]
        public IActionResult SolveTest(int id)
        {
            var test = TestBusiness.GetTest(id);
            List<Question> questions = QuestionBusiness.GetTestQuestion(id);
            var model = new TestViewModel { QuestionList = questions, Test = test };
            return View(model);
        }
    }
}
