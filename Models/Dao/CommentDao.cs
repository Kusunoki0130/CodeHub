using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySQLDriverCS;
using CodeHub.Models.Entity;
using CodeHub.utils;

namespace CodeHub.Models.Dao
{
    public class CommentDao
    {
        MySQLConnection con;
        private Encode encode = new Encode();
        public void init()
        {
            con = new MySQLConnection(new MySQLConnectionString("127.0.0.1", "codehub", "root", "123456", 3306).AsString);
        }

        public void insertNewComment(Comment com)
        {
            com.comment = encode.stringToNum(com.comment);
            init();
            con.Open();
            string sql = "insert into comment_list value(null,"
                       + com.articleId + ","
                       + com.userId + ","
                       + "\"" + com.comment + "\","
                       + "\"" + com.time + "\")";
            System.Diagnostics.Debug.WriteLine(sql);
            MySQLCommand cmd = new MySQLCommand(sql, con);
            cmd.ExecuteNonQuery();
            return;
        }

        public Dictionary<string, object> selectCommentByArticleId(int id)
        {
            init();
            con.Open();
            string sql = "select a.*,b.name from comment_list a right join user b on a.user_id = b.id "
                       + "where a.article_id = " + id;
            System.Diagnostics.Debug.WriteLine(sql);
            MySQLCommand cmd = new MySQLCommand(sql, con);
            MySQLDataReader reader = cmd.ExecuteReaderEx();
            List<Comment> comments = new List<Comment>();
            List<string> usernames = new List<string>();
            while(reader.Read())
            {
                comments.Add(new Comment((int)reader[0],
                                         (int)reader[1],
                                         (int)reader[2],
                                         encode.numToString(System.Text.Encoding.UTF8.GetString((byte[])reader[3])),
                                         reader[4].ToString()));
                usernames.Add((string)reader[5]);
            }
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("comments",comments);
            dic.Add("usernames",usernames);
            con.Close();
            return dic;
        }

        public Comment selectCommentById(int id)
        {
            init();
            con.Open();
            string sql = "select * from comment_list where id = " + id;
            MySQLCommand cmd = new MySQLCommand(sql, con);
            MySQLDataReader reader = cmd.ExecuteReaderEx();
            Comment com = null;
            while(reader.Read())
            {
                com = new Comment((int)reader[0],
                                  (int)reader[1],
                                  (int)reader[2],
                                  encode.numToString(System.Text.Encoding.UTF8.GetString((byte[])reader[3])),
                                  reader[4].ToString());
            }
            con.Close();
            return com;
        }

        public void deleteComment(int id)
        {
            init();
            con.Open();
            string sql = "delete from comment_list where id = " + id;
            System.Diagnostics.Debug.WriteLine(sql);
            MySQLCommand cmd = new MySQLCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
            return;
        }

        public Dictionary<string, object> selectCommentByUserId(int id)
        {
            init();
            con.Open();
            string sql = "select a.*,b.title from comment_list a LEFT JOIN article b on a.article_id = b.id "
                       + "where b.user_id = " + id + " "
                       + "order by a.time desc";
            System.Diagnostics.Debug.WriteLine(sql);
            MySQLCommand cmd = new MySQLCommand(sql, con);
            MySQLDataReader reader = cmd.ExecuteReaderEx();
            List<Comment> comments = new List<Comment>();
            List<string> titles = new List<string>();
            List<string> names = new List<string>();
            while (reader.Read())
            {
                comments.Add(new Comment((int)reader[0],
                                         (int)reader[1],
                                         (int)reader[2],
                                         encode.numToString(System.Text.Encoding.UTF8.GetString((byte[])reader[3])),
                                         reader[4].ToString()));
                titles.Add(encode.numToString(System.Text.Encoding.UTF8.GetString((byte[])reader[5])));
            }
            foreach (Comment com in comments)
            {
                sql = "select name from user where id = " + com.userId;
                cmd = new MySQLCommand(sql, con);
                reader = cmd.ExecuteReaderEx();
                while (reader.Read())
                {
                    names.Add((string)reader[0]);
                }
            }
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("comments", comments);
            dic.Add("commentNames", names);
            dic.Add("commentTitles", titles);
            con.Close();
            return dic;
        }
    }
}