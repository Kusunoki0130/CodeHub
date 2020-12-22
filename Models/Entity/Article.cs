using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeHub.Models.Entity
{
    public class Article
    {
        public int id { get; set; }
        public string title { get; set; }
        public int userId { get; set; }
        public string abstrac { get; set; }
        public string code { get; set; }
        public string md { get; set; }
        public string language { get; set; }
        public string languagemode { get; set; }
        public string theme { get; set; }
        public int isPublish { get; set; }//0:草稿 1:发布
        public int isPersonal { get; set; }//0:公开 2:私人

        public int isHidden { get; set; }
        public int like { get; set; }
        public int collect { get; set; }
        public string time { get; set; }

        public Article() { }
        public Article(int id, string title, int userId, 
                       string abstrac, string code, string md, 
                       string language, string languagemode, string theme,
                       int isPublish, int isPersonal, int isHidden,
                       int like, int collect, string time)
        {
            this.id = id;
            this.title = title;
            this.userId = userId;
            this.abstrac = abstrac;
            this.code = code;
            this.md = md;
            this.language = language;
            this.languagemode = languagemode;
            this.theme = theme;
            this.isPersonal = isPersonal;
            this.isPublish = isPublish;
            this.isHidden = isHidden;
            this.like = like;
            this.collect = collect;
            this.time = time;
        }

        public void addlike()
        {
            ++this.like;
        }

        public void addcollect()
        {
            ++this.collect;
        }
        public void subcollect()
        {
            --this.collect;
        }
    }
}