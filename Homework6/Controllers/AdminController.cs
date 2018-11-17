using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homework6.Service;
using Homework6.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Homework6.Controllers
{
    public class AdminController : Controller
    {
        TestpapersRepository testpapersRepository = new TestpapersRepository();
        TestpaperitemRepository testpaperitemRepository = new TestpaperitemRepository();

        // GET: Admin
        public ActionResult Index()
        {
            ViewData["Userno"] = HttpContext.Session.GetString("user");
            ViewBag.Papers = testpapersRepository.SelectAll();
            return View();
        }
        public ActionResult Paper(int paperid)
        {
            ViewData["Userno"] = HttpContext.Session.GetString("user");
            ViewBag.Paperitem = testpaperitemRepository.SelectByPaperid(paperid);
            ViewBag.Papers = testpapersRepository.SelectByid(paperid);
            return View();
        }
        public ActionResult PaperAdd()
        {
            ViewData["Userno"] = HttpContext.Session.GetString("user");
            return View();
        }
        
        public ActionResult PaperEdit(int paperid)
        {
            ViewBag.Papers = testpapersRepository.SelectByid(paperid);
            ViewData["Userno"] = HttpContext.Session.GetString("user");
            return View();
        }
        public RedirectToRouteResult AddTestPaper(TestpapersModel testpapers)
        {
            Debug.WriteLine(testpapers.papername + "!!!!!!!!!!!!");
            testpapersRepository.Insert(testpapers);
            return RedirectToRoute(new
            {
                controller = "Admin",
                action = "PaperAdd",
            });//重定向  
        }

        public RedirectToRouteResult PaperDel(int paperid)
        {
            testpapersRepository.Delete(paperid);
            return RedirectToRoute(new
            {
                controller = "Admin",
                action = "Index",
            });//重定向  
        }
        public int AddQuestion([FromBody]dynamic Json)
        {
            TestpaperitemModel testpaperitemModel = new TestpaperitemModel
            {
                question = Json.question,
                paperid = Json.paperid,
                select1_score = Json.select1_score,
                select2_score = Json.select2_score,
                select3_score = Json.select3_score,
                select4_score = Json.select4_score
            };
            return testpaperitemRepository.Insert(testpaperitemModel);
        }
        public int QuestionEdit([FromBody]dynamic Json)
        {
            TestpaperitemModel testpaperitemModel = new TestpaperitemModel
            {
                question = Json.question,
                paperid = Json.paperid,
                select1_score = Json.select1_score,
                select2_score = Json.select2_score,
                select3_score = Json.select3_score,
                select4_score = Json.select4_score
            };
            return testpaperitemRepository.Update(testpaperitemModel);
        }
        public RedirectToRouteResult QuestionDel(int questionid)
        {
            testpaperitemRepository.Delete(questionid);
            return RedirectToRoute(new
            {
                controller = "Admin",
                action = "Paper",
            });//重定向          
        }
    }
}