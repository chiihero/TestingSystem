using System.Data;
using System.Diagnostics;
using Homework.Tool;
using Homework6.Models;
using Homework6.Service;
using Microsoft.AspNetCore.Mvc;

namespace Homework6.Controllers
{
    public class StudentController : Controller
    {
        TestpapersRepository testpapersRepository = new TestpapersRepository();
        TestpaperitemRepository testpaperitemRepository = new TestpaperitemRepository();
        GradeRepository gradeRepository = new GradeRepository();

        public IActionResult Index(string id)
        {
            ViewData["Userno"] = id;

            ViewBag.Papers = testpapersRepository.SelectAll();
            return View();
        }
        public ActionResult Paper(string id, int paperid)
        {
            Debug.WriteLine(id + "   " + paperid);
            ViewData["Userno"] = id;

            ViewBag.Paperitem = testpaperitemRepository.SelectByPaperid(paperid);
            ViewBag.Papers = testpapersRepository.SelectByid(paperid);

            return View();
        }

        public string AddGrade([FromBody]dynamic Json)
        {
            GradeModel gradeModel = new GradeModel();
            gradeModel.userno = Json.userno;
            gradeModel.paperid = Json.papers;
            gradeModel.grade = Json.grade;
            Debug.WriteLine(gradeModel.grade + "!!!!!!!!!!!!");

            gradeRepository.Insert(gradeModel);

            return null;
        }
   
    }
}