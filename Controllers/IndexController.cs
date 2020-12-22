using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeHub.Models.Entity;
using CodeHub.Models.Dao;
using Newtonsoft.Json;

namespace CodeHub.Controllers
{
    public class IndexController : Controller
    {
        private UserDao userDao = new UserDao();

        [HttpGet]
        public ActionResult welcome()
        {
            return View();
        }

        [HttpGet]
        public ActionResult register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult registerUser(User user)
        {

            User userCheck = userDao.selectUserByName(user.name);
            if (userCheck!=null)
            {
                return Content(JsonConvert.SerializeObject(new { result = "failed"}));
            }
            userDao.instertNewUser(user);
            return Content(JsonConvert.SerializeObject(new { result = "success"}));
        }

        [HttpGet]
        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult loginPost()
        {
            string name = Request["name"];
            string password = Request["password"];
            User userCheck = userDao.selectUserByName(name);
            if (userCheck == null)
            {
                return Redirect("~/Index/login");
            }
            if (password != userCheck.password)
            {
                return Redirect("~/Index/login");
            }
            Session.Timeout = 24 * 60 * 60;
            Session.Add("user", userCheck);
            return Redirect("~/Index/welcome");
        }

        [HttpGet]
        public ActionResult logout()
        {
            Session["user"] = null;
            return Content(JsonConvert.SerializeObject(new { result = "登出" }));
        }
    }
}