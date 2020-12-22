using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeHub.Models.Entity
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string registerTime { get; set; }
        public int isAdmin { get; set; }
        public int follow { get; set; }
        public int fans { get; set; }
        public int like { get; set; }
        public int collect { get; set; }
        public int comment { get; set; }

        public User() { }
        public User(int id, string name, string password,
                    string phone, string email, string registerTime,
                    int isAdmin, int follow, int fans,
                    int like, int collect, int comment)
        {
            this.id = id;
            this.name = name;
            this.password = password;
            this.phone = phone;
            this.email = email;
            this.registerTime = registerTime;
            this.isAdmin = isAdmin;
            this.follow = follow;
            this.fans = fans;
            this.like = like;
            this.collect = collect;
            this.comment = comment;
        }

        public void addFan()
        {
            ++this.fans;
        }
        public void subFan()
        {
            --this.fans;
        }

        public void addFollow()
        {
            ++this.follow;
        }
        public void subFollow()
        {
            --this.follow;
        }

        public void addLike()
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
        
        public void addComment()
        {
            ++this.comment;
        }
        public void subComment()
        {
            --this.comment;
        }
    }
}