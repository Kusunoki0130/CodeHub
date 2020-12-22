using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeHub.Models.Dao;
using CodeHub.Models.Entity;
using CodeHub.utils;

namespace CodeHub.Controllers
{
    public class CommunityController : Controller
    {
        private ArticleDao articleDao = new ArticleDao();
        private Encode encode = new Encode();
        // GET: Community
        public ActionResult articleBoard ()
        {
            Dictionary<string, object> dic = articleDao.getAll();
            List<Article> tmp = (List<Article>)dic["articles"];
            List<string> names = (List<string>)dic["names"];
            List<Article> articles = new List<Article>();
            foreach (Article article in tmp)
            {
                article.title = encode.numToString(article.title);
                article.abstrac = encode.numToString(article.abstrac);
                article.code = encode.numToString(article.code);
                article.md = encode.numToString(article.md);
                articles.Add(article);
            }
            ViewData["articles"] = articles;
            ViewData["names"] = names;
            return View();
        }
    }
}