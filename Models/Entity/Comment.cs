using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeHub.Models.Entity
{
    public class Comment
    {
        public int id { set; get; }
        public int articleId { set; get; }
        public int userId { set; get; }
        public string comment { set; get; }
        public string time { set; get; }

        public Comment() { }
        public Comment(int id, int articleId, int userId, string comment, string time)
        {
            this.id = id;
            this.articleId = articleId;
            this.userId = userId;
            this.comment = comment;
            this.time = time;
        }
    }
}