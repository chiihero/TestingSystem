using System.Data;
using Homework.Tool;
using Homework6.Service;
using Microsoft.AspNetCore.Mvc;

namespace Homework6.Controllers
{
    public class StudentController : Controller
    {
        TestpapersRepository testpapersRepository = new TestpapersRepository();
        TestpaperitemRepository testpaperitemRepository = new TestpaperitemRepository();
        public IActionResult Index()
        {
            DataSet item = testpapersRepository.SelectAll();
            if (item == null)
            {
                return null;
            }
            ViewBag.Papers = item;
            return View();
        }
        public ActionResult Paper(int id)
        {
            ViewData["Message"] = "Your application description page."+ id;
            DataSet item = testpaperitemRepository.SelectByPaperid(id);
            if (item == null)
            {
                return null;
            }
            ViewBag.Paperitem = item;
            return View();
        }
        public string GetAllTestPaper()
        {
            DataSet item = testpapersRepository.SelectAll();
            if (item == null)
            {
                return null;
            }
            return DatasetToJson.Dataset2Json(item);
        }
        public string GetTestPaper(int id)
        {
            DataSet item = testpapersRepository.SelectByid(id);
            if (item == null)
            {
                return null;
            }
            return DatasetToJson.Dataset2Json(item);
        }
        public string GetTestPaperitem(int paperid)
        {
            DataSet item = testpaperitemRepository.SelectByPaperid(paperid);
            if (item == null)
            {
                return null;
            }
            return DatasetToJson.Dataset2Json(item);
        }
    }
}