using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using CodeHub.Models.Entity;
using CodeHub.Models.Dao;
using CodeHub.utils;

namespace CodeHub.Controllers
{
    public class ArticleController : Controller
    {
        private ArticleDao articleDao = new ArticleDao();
        private UserDao userDao = new UserDao();
        private CommentDao commentDao = new CommentDao();        
        private Encode encode = new Encode();

        [HttpGet]
        public ActionResult editor(int id)
        {
            if (Session["user"]==null)
            {
                return Redirect("~/Index/login");
            }
            if (id!=0)
            {
                Dictionary<string, object> dic = articleDao.selectArticleById(id);
                Article article = (Article)dic["article"];
                if (article.userId != ((User)Session["user"]).id)
                {
                    return Redirect("~/Article/editor/0");
                }
                article.title = encode.numToString(article.title);
                article.abstrac = encode.numToString(article.abstrac);
                article.code = encode.numToString(article.code);
                article.md = encode.numToString(article.md);
                string name = (string)dic["name"];
                ViewData["article"] = article;
                ViewData["name"] = name;
            }
            return View();
        }

        [HttpPost]
        public ActionResult saveArticle(Article article)
        { 
            article.title = encode.stringToNum(article.title);
            if (article.abstrac==null)
            {
                article.abstrac = "0";
            }
            else
            {
                article.abstrac = encode.stringToNum(article.abstrac);
            }
            if (article.code == null)
            {
                article.code = "0";
            }
            else
            {
                article.code = encode.stringToNum(article.code);
            }
            if (article.md == null)
            {
                article.md = "0";
            }
            else
            {
                article.md = encode.stringToNum(article.md);
            }
            int retid = 0;
            if (article.id==0)
            {
                retid = articleDao.insertNewArticle(article);
            }
            else
            {
                articleDao.updataArticle(article);
                retid = article.id;
            }
            if (article.isPublish==0)
            {
                return Content(JsonConvert.SerializeObject(new { result="草稿已保存", id = retid}));
            }
            return Content(JsonConvert.SerializeObject(new { result = "草稿已发布", id = retid})); 
        }

        [HttpGet]
        public ActionResult show(int id)
        {
            Dictionary<string, object> dic = articleDao.selectArticleById(id);
            Article article = (Article)dic["article"];
            article.title = encode.numToString(article.title);
            article.abstrac = encode.numToString(article.abstrac);
            article.code = encode.numToString(article.code);
            article.md = encode.numToString(article.md);
            string name = (string)dic["name"];
            ViewData["article"] = article;
            ViewData["name"] = name;
            if (Session["user"]!=null)
            {
                Dictionary<string, object> dic2 = articleDao.selectArticleByCollect(((User)Session["user"]).id);
                ViewData["collect_articles"] = (List<Article>)dic2["articles"];
            }
            else
            {
                ViewData["collect_articles"] = null;
            }
            Dictionary<string, object> dic3 = commentDao.selectCommentByArticleId(id);
            ViewData["comments"] = (List<Comment>)dic3["comments"];
            ViewData["usernames"] = (List<string>)dic3["usernames"];
            return View();
        }

        [HttpGet]
        public ActionResult delete(int id)
        {
            articleDao.setArticleHiddenById(id);
            return Content(JsonConvert.SerializeObject(new { result = "文章已删除" }));
        }

        [HttpGet]
        public ActionResult like()
        {
            string str = Request.QueryString["str"];
            System.Diagnostics.Debug.WriteLine(str);
            Dictionary<string, object> dic = encode.getLC(str);
            int articleId = (int)dic["articleId"];
            int userId = (int)dic["userId"];
            string time = (string)dic["time"];
            if (articleDao.selectLike(articleId, userId))
            {
                return Content(JsonConvert.SerializeObject(new { result = "操作成功" }));
            }
            articleDao.insertNewLike(articleId, userId, time);
            Article article = (Article)((articleDao.selectArticleById(articleId))["article"]);
            User user = userDao.selectUserById(article.userId);
            user.addLike();
            article.addlike();
            userDao.updateUser(user);
            articleDao.updateArticle2(article);
            return Content(JsonConvert.SerializeObject(new { result = "操作成功" }));
        }

        [HttpGet]
        public ActionResult collect()
        {
            string str = Request.QueryString["str"];
            System.Diagnostics.Debug.WriteLine(str);
            Dictionary<string, object> dic = encode.getLC(str);
            int articleId = (int)dic["articleId"];
            int userId = (int)dic["userId"];
            string time = (string)dic["time"];
            Article article = (Article)((articleDao.selectArticleById(articleId))["article"]);
            User user = userDao.selectUserById(article.userId);
            if (articleDao.selectCollect(articleId, userId))
            {
                articleDao.deleteCollect(articleId, userId, time);
                user.subcollect();
                article.subcollect();
                userDao.updateUser(user);
                articleDao.updateArticle2(article);
                return Content(JsonConvert.SerializeObject(new { result = "操作成功" }));
            }
            articleDao.insertNewCollect(articleId, userId, time);
            user.addcollect();
            article.addcollect();
            userDao.updateUser(user);
            articleDao.updateArticle2(article);
            return Content(JsonConvert.SerializeObject(new { result = "操作成功" }));
        }

        [HttpPost]
        public ActionResult commentPost(Comment com)
        {
            commentDao.insertNewComment(com);
            User user = userDao.selectUserById(com.userId);
            Article article = (Article)(articleDao.selectArticleById(com.articleId))["article"];
            if (user.id != article.userId)
            {
                User user2 = userDao.selectUserById(article.userId);
                user2.addComment();
                userDao.updateUser(user2);
            }
            return Content(JsonConvert.SerializeObject(new { result = "评论成功" }));
        }

        [HttpGet]
        public ActionResult commentDelete(int id)
        {
            commentDao.deleteComment(id);
            Comment com = commentDao.selectCommentById(id);
            User user = userDao.selectUserById(com.userId);
            Article article = (Article)(articleDao.selectArticleById(com.articleId))["article"];
            if (user.id != article.userId)
            {
                User user2 = userDao.selectUserById(article.userId);
                user2.subComment();
                userDao.updateUser(user2);
            }
            return Content(JsonConvert.SerializeObject(new { result = "删除成功" }));
        }
    }
}