using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Homework6.Models;
using System.Data;
using Homework6.Service;
using Microsoft.AspNetCore.Http;

namespace Homework6.Controllers
{
    public class HomeController : Controller
    {
        UserRepository userRepository = new UserRepository();

        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("user") != null)
            {
                HttpContext.Session.SetString("user", "");
                //HttpContext.Session.Clear();
            }
            return View();
        }
        public RedirectToRouteResult LoginSigin(UserModel user)
        {
            DataSet data = userRepository.SelectByUserno(user.userno);
            if (data.Tables[0].Rows.Count == 0)//内容是否获取到
            {
                Debug.WriteLine("账号密码错误");
                return RedirectToRoute(new
                {
                    controller = "Home",
                    action = "Login",
                });//重定向 
            }
            if (data.Tables[0].Rows[0][1].ToString() == user.password)//对比密码
            {
                Debug.WriteLine("登录成功");
                HttpContext.Session.SetString("user", user.userno);
                user.type = (int)data.Tables[0].Rows[0][2];
                switch (user.type)
                {
                    case 1:
                        return RedirectToRoute(new
                        {
                            controller = "Student",
                            action = "Index",
                        });//重定向     
                    case 2:
                        return RedirectToRoute(new
                        {
                            controller = "Admin",
                            action = "Index",
                        });//重定向     
                }     

            }
            return RedirectToRoute(new
            {
                controller = "Home",
                action = "Login",
            });//重定向        
        }

        public RedirectToActionResult Register(UserModel user)
        {
            if (userRepository.Insert(user) == 1)
            {
                Debug.WriteLine("注册成功");
            }
            return RedirectToAction("Login");//重定向        
        }



        public IActionResult About()
        {
            ViewData["Message"] = HttpContext.Session.GetString("user");
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
