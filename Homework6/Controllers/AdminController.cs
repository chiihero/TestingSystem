using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homework6.Service;
using Homework6.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework6.Controllers
{
    public class AdminController : Controller
    {
        TestpapersRepository testpapersRepository = new TestpapersRepository();
        TestpaperitemRepository testpaperitemRepository = new TestpaperitemRepository();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Paper()
        {
            return View();
        }
        public int AddTestPaper([FromBody]dynamic Json)
        {
            TestpapersModel testpapersModel = new TestpapersModel
            {
                papername = Json.papername,
                introduce = Json.introduce,
                select1_name = Json.select1_name,
                select1_score = Json.select1_score,
                select2_name = Json.select2_name,
                select2_score = Json.select2_score,
                select3_name = Json.select3_name,
                select3_score = Json.select3_score,
                select4_name = Json.select4_name,
                select4_score = Json.select4_score
            };
            testpapersRepository.Insert(testpapersModel);
            return 1;
        }
        public int AddQuestion([FromBody]dynamic Json)
        {
            TestpaperitemModel testpaperitemModel = new TestpaperitemModel
            {
                question = Json.question,
                paperid = Json.paperid,
            };
            testpaperitemRepository.Insert(testpaperitemModel);
            return 1;
        }
    }
}