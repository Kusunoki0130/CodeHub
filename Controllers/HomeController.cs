using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeHub.Models.Dao;
using CodeHub.Models.Entity;
using CodeHub.utils;
using Newtonsoft.Json;

namespace CodeHub.Controllers
{
    public class HomeController : Controller
    {
        private ArticleDao articleDao = new ArticleDao();
        private UserDao userDao = new UserDao();
        private CommentDao commentDao = new CommentDao();
        private Encode encode = new Encode();
        public ActionResult warehouse(int id)
        {
            User user = userDao.selectUserById(id);
            Dictionary<string, object> dic = articleDao.selectArticleByuserId(id);
            List<Article> tmp = (List<Article>)dic["articles"];
            List<string> names = (List<string>)dic["names"];
            List<Article> articles = new List<Article>();
            foreach(Article article in tmp)
            {
                article.title = encode.numToString(article.title);
                article.abstrac = encode.numToString(article.abstrac);
                article.code = encode.numToString(article.code);
                article.md = encode.numToString(article.md);
                articles.Add(article);
            }
            List<int> ids = userDao.selectFollowByFollowerId(id);
            ViewData["fanIds"] = ids;
            ViewData["articles"] = articles;
            ViewData["names"] = names;
            Dictionary<string, object> dic2 = articleDao.selectArticleByCollect(id);
            ViewData["collect_articles"] = (List<Article>)dic2["articles"];
            ViewData["collect_usernames"] = (List<string>)dic2["usernames"];
            return  View(user);
        }

        [HttpGet]
        public ActionResult follow()
        {
            string str = Request.QueryString["str"];
            System.Diagnostics.Debug.WriteLine(str);
            Dictionary<string, object> dic = encode.getFollow(str);
            int fanId = (int)dic["fan"];
            int followerId = (int)dic["follower"];
            bool isFollow = (bool)dic["isFollow"];
            User fan = userDao.selectUserById(fanId);
            User follower = userDao.selectUserById(followerId);
            if (isFollow)
            {
                fan.addFollow();
                follower.addFan();
                userDao.insertFollow(fanId, followerId);
            }
            else
            {
                fan.subFollow();
                follower.subFan();
                userDao.deleteFollow(fanId, followerId);
            }
            userDao.updateUser(fan);
            userDao.updateUser(follower);
            return Content(JsonConvert.SerializeObject(new { result = "操作成功" }));
        }

        [HttpGet]
        public ActionResult news(int id)
        {
            List<int> fanIds = userDao.selectFollowByFollowerId(id);
            List<User> fans = new List<User>();
            foreach(int i in fanIds)
            {
                fans.Add(userDao.selectUserById(i));
                System.Diagnostics.Debug.WriteLine(i);
            }
            List<int> followerIds = userDao.selectFollowByFanId(id);
            List<User> followers = new List<User>();
            System.Diagnostics.Debug.WriteLine(1111111);
            foreach (int i in followerIds)
            {
                followers.Add(userDao.selectUserById(i));
                System.Diagnostics.Debug.WriteLine(i);
            }
            ViewData["fans"] = fans;
            ViewData["followers"] = followers;
            Dictionary<string, object> dic1 = articleDao.selectLikeByUserId(id);
            ViewData["likeList"] = dic1;
            Dictionary<string, object> dic2 = articleDao.selectCollectByUserId(id);
            ViewData["collectList"] = dic2;
            ViewData["commentList"] = commentDao.selectCommentByUserId(id);
            return View();
        }


    }
}