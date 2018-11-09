//using Homework.Tool;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System.Data;
//using System.Diagnostics;

//namespace Homework.Controllers
//{
//    public class CustomsController : Controller
//    {
//        UserRepository customRepository = new UserRepository();//直接数据库操作
//        //CustomRepositoryStored customRepository = new CustomRepositoryStored();//数据库存储过程

//        public IActionResult Index()
//        {
//            return View();
//        }
//        //GET: /customs/id
//        public string GetCustoms(int id)
//        {
//            Debug.WriteLine("GetCustoms");
//            DataSet item = customRepository.Get(id);

//            if (item == null)
//            {
//                return null;
//            }
//            string msg = DatasetToJson.Dataset2Json(item);
//            Debug.WriteLine(msg);
//            return msg;
//        }
//        public int AddCustoms([FromBody]dynamic Json)
//        {
//            CustomModel customModel = new CustomModel
//            {
//                id = Json.id,
//                cname = Json.cname,
//                departID = Json.departID,
//                age = Json.age,
//                ename = Json.ename,
//                password = Json.password
//            };
//            Debug.WriteLine(customModel.id + "|" + customModel.cname + "|" + customModel.departID + "|" + customModel.age + "|" + customModel.ename + "|" + customModel.password);
//            return customRepository.Add(customModel);
//        }

//        public int UpdateCustoms([FromBody]dynamic Json)
//        {
//            CustomModel customModel = new CustomModel
//            {
//                id = Json.id,
//                cname = Json.cname,
//                departID = Json.departID,
//                age = Json.age,
//                ename = Json.ename,
//                password = Json.password
//            };
//            Debug.WriteLine(customModel.id + "|" + customModel.cname + "|" + customModel.departID + "|" + customModel.age + "|" + customModel.ename + "|" + customModel.password);
//            return customRepository.Update(customModel);
//        }
//        public int DeleteCustoms(int id)
//        {
//            return customRepository.Remove(id);
//        }
//        public string getstring()
//        {
//            return "Hello World is old now. It’s time for wassup bro ";
//        }
//    }
//}