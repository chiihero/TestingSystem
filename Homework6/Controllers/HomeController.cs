using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Homework6.Models;
using System.Data;
using Homework.Tool;
using Homework6.Service;

namespace Homework6.Controllers
{
    public class HomeController : Controller
    {
        UserRepository userRepository = new UserRepository();
        //public IActionResult Index()
        //{
        //    return View();
        //}
        public IActionResult Login()
        {
            return View();
        }
        public RedirectToRouteResult LoginSigin(string userno, string password,string type)
        {
            DataSet data = userRepository.SelectByUserno(userno);
            if (data.Tables[0].Rows[0][1].ToString() == password)
            {
                Debug.WriteLine("登录成功");
                if (type == "1")
                    return RedirectToRoute(new
                    {
                        controller = "Student",
                        action = "Index",
                        id = userno,
                    });//重定向     
                if (type=="2")
                    return RedirectToRoute(new
                    {
                        controller = "Admin",
                        action = "Index",
                        id = userno,
                    });//重定向     

            }
            return RedirectToRoute(new { controller = "Home", action = "Login" });//重定向        
        }


            public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
