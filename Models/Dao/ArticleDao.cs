using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySQLDriverCS;
using CodeHub.Models.Entity;
using CodeHub.utils;

namespace CodeHub.Models.Dao
{
    public class ArticleDao
    {
        MySQLConnection con;
        private Encode encode = new Encode();
        public void init()
        {
            con = new MySQLConnection(new MySQLConnectionString("127.0.0.1", "codehub", "root", "123456", 3306).AsString);
        }

        public Dictionary<string,object> getAll()
        {
            init();
            con.Open();
            string sql = "select a.*,b.name from article a LEFT JOIN `user` b on a.user_id = b.id order by a.time desc";
            MySQLCommand cmd = new MySQLCommand(sql, con);
            MySQLDataReader reader = cmd.ExecuteReaderEx();
            List<Article> articles = new List<Article>();
            List<string> names = new List<string>();
            while (reader.Read())
            {
                byte[] buf0 = (byte[])reader[1];
                byte[] buf1 = (byte[])reader[3];
                byte[] buf2 = (byte[])reader[4];
                byte[] buf3 = (byte[])reader[5];
                articles.Add(new Article((int)reader[0],
                                          System.Text.Encoding.UTF8.GetString(buf0),
                                          (int)reader[2],
                                          System.Text.Encoding.UTF8.GetString(buf1),
                                          System.Text.Encoding.UTF8.GetString(buf2),
                                          System.Text.Encoding.UTF8.GetString(buf3),
                                          (string)reader[6],
                                          (string)reader[7],
                                          (string)reader[8],
                                          (int)reader[9],
                                          (int)reader[10],
                                          (int)reader[11],
                                          (int)reader[12],
                                          (int)reader[13],
                                          reader[14].ToString()));
                names.Add((string)reader[15]);
            }
            con.Close();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("articles", articles);
            dic.Add("names", names);
            return dic;
        }
        public int insertNewArticle(Article article)
        {
            init();
            con.Open();
            string sql = "insert into article value(null,"
                       + "\"" + article.title + "\","
                       + article.userId + ","
                       + "\"" + article.abstrac + "\","
                       + "\"" + article.code + "\","
                       + "\"" + article.md + "\","
                       + "\"" + article.language + "\","
                       + "\"" + article.languagemode + "\","
                       + "\"" + article.theme + "\","
                       + article.isPublish + ","
                       + article.isPersonal + ","
                       + article.isHidden + ","
                       + article.like + ","
                       + article.collect + ","
                       + "\"" + article.time + "\")";
            System.Diagnostics.Debug.WriteLine(sql);
            MySQLCommand cmd = new MySQLCommand(sql, con);
            cmd.ExecuteNonQuery();
            sql = "select * from article where "
                + "user_id = " + article.userId + " && "
                + "time = \"" + article.time + "\"";
            System.Diagnostics.Debug.WriteLine(sql);
            cmd = new MySQLCommand(sql, con);
            MySQLDataReader reader = cmd.ExecuteReaderEx();
            int id = 0;
            while(reader.Read())
            {
                id = (int)reader[0];
            }
            con.Close();
            return id;
        }

        public Dictionary<string, object> selectArticleByuserId(int id)
        {
            init();
            con.Open();
            string sql = "select a.*,b.name from article a RIGHT JOIN `user` b on a.user_id = b.id where "
                       + "user_id = " + id
                       + " order by a.time desc";
            System.Diagnostics.Debug.WriteLine(sql);
            MySQLCommand cmd = new MySQLCommand(sql, con);
            MySQLDataReader reader = cmd.ExecuteReaderEx();
            List<Article> articles = new List<Article>();
            List<string> names = new List<string>();
            while(reader.Read())
            {
                byte[] buf0 = (byte[])reader[1];
                byte[] buf1 = (byte[])reader[3];
                byte[] buf2 = (byte[])reader[4];
                byte[] buf3 = (byte[])reader[5];
                articles.Add(new Article((int)reader[0],
                                          System.Text.Encoding.UTF8.GetString(buf0),
                                          (int)reader[2],
                                          System.Text.Encoding.UTF8.GetString(buf1),
                                          System.Text.Encoding.UTF8.GetString(buf2),
                                          System.Text.Encoding.UTF8.GetString(buf3),
                                          (string)reader[6],
                                          (string)reader[7],
                                          (string)reader[8],
                                          (int)reader[9],
                                          (int)reader[10],
                                          (int)reader[11],
                                          (int)reader[12],
                                          (int)reader[13],
                                          reader[14].ToString()));
                names.Add((string)reader[15]);
            }
            con.Close();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("articles", articles);
            dic.Add("names", names);
            return dic;
        }

        public Dictionary<string, object> selectArticleById(int id)
        {
            init();
            con.Open();
            string sql = "select a.*,b.name from article a RIGHT JOIN `user` b on a.user_id = b.id where "
                       + "a.id = " + id;
            System.Diagnostics.Debug.WriteLine(sql);
            MySQLCommand cmd = new MySQLCommand(sql, con);
            MySQLDataReader reader = cmd.ExecuteReaderEx();
            Article article;
            string name;
            while(reader.Read())
            {
                byte[] buf0 = (byte[])reader[1];
                byte[] buf1 = (byte[])reader[3];
                byte[] buf2 = (byte[])reader[4];
                byte[] buf3 = (byte[])reader[5];
                article = new Article((int)reader[0],
                                      System.Text.Encoding.UTF8.GetString(buf0),
                                      (int)reader[2],
                                      System.Text.Encoding.UTF8.GetString(buf1),
                                      System.Text.Encoding.UTF8.GetString(buf2),
                                      System.Text.Encoding.UTF8.GetString(buf3),
                                      (string)reader[6],
                                      (string)reader[7],
                                      (string)reader[8],
                                      (int)reader[9],
                                      (int)reader[10],
                                      (int)reader[11],
                                      (int)reader[12],
                                      (int)reader[13],
                                      reader[14].ToString());
                name = (string)reader[15];
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic.Add("article", article);
                dic.Add("name", name);
                con.Close();
                return dic;
            }
            return null;
        }

        public void setArticleHiddenById(int id)
        {
            init();
            con.Open();
            string sql = "update article set is_hidden = 1 where id = "
                       + id;
            System.Diagnostics.Debug.WriteLine(sql);
            MySQLCommand cmd = new MySQLCommand(sql, con);
            cmd.ExecuteNonQuery();
            return;
        }

        public void updataArticle(Article article)
        {
            init();
            con.Open();
            string sql = "update article set "
                       + "title = \"" + article.title + "\","
                       + "user_id = " + article.userId + ","
                       + "abstract = \"" + article.abstrac + "\","
                       + "code = \"" + article.code + "\","
                       + "md = \"" + article.md + "\","
                       + "language = \"" + article.language + "\","
                       + "languagemode = \"" + article.languagemode + "\","
                       + "theme = \"" + article.theme + "\","
                       + "is_publish = " + article.isPublish + ","
                       + "is_personal = " + article.isPersonal + ","
                       + "is_hidden = " + article.isHidden + " where "
                       + "id = " + article.id;
            System.Diagnostics.Debug.WriteLine(sql);
            MySQLCommand cmd = new MySQLCommand(sql, con);
            cmd.ExecuteNonQuery();
            return;
        }

        public void updateArticle2(Article article)
        {
            init();
            con.Open();
            string sql = "update article set "
                       + "`like` = " + article.like + ","
                       + "collect = " + article.collect + " where "
                       + "id = " + article.id;
            System.Diagnostics.Debug.WriteLine(sql);
            MySQLCommand cmd = new MySQLCommand(sql, con);
            cmd.ExecuteNonQuery();
            return;
        }

        public void insertNewLike(int articleId, int userId, string time)
        {
            init();
            con.Open();
            string sql = "insert into like_list value(null,"
                       + articleId + ","
                       + userId + ","
                       + "\"" + time + "\")";
            System.Diagnostics.Debug.WriteLine(sql);
            MySQLCommand cmd = new MySQLCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
            return;
        }

        public bool selectLike(int articleId, int userId)
        {
            init();
            con.Open();
            string sql = "select * from like_list where "
                       + "article_id = " + articleId + " && "
                       + "user_id = " + userId;
            System.Diagnostics.Debug.WriteLine(sql);
            MySQLCommand cmd = new MySQLCommand(sql, con);
            MySQLDataReader reader = cmd.ExecuteReaderEx();
            con.Close();
            while(reader.Read())
            {
                return true;
            }
            return false;
        }

        public Dictionary<string, object> selectLikeByUserId(int id)
        {
            init();
            con.Open();
            string sql = "select a.id,a.title,b.user_id,b.time from article a RIGHT JOIN like_list b on a.id = b.article_id "
                       + "where a.user_id = " + id + " order by b.time desc";
            System.Diagnostics.Debug.WriteLine(sql);
            MySQLCommand cmd = new MySQLCommand(sql, con);
            MySQLDataReader reader = cmd.ExecuteReaderEx();
            List<int> articleIds = new List<int>();
            List<string> articleTitles = new List<string>();
            List<int> userIds = new List<int>();
            List<string> likeTime = new List<string>();
            while (reader.Read())
            {
                byte[] buf0 = (byte[])reader[1];
                articleIds.Add((int)reader[0]);
                articleTitles.Add(encode.numToString(System.Text.Encoding.UTF8.GetString(buf0)));
                userIds.Add((int)reader[2]);
                likeTime.Add(reader[3].ToString());
            }
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("articleIds", articleIds);
            dic.Add("articleTitles", articleTitles);
            dic.Add("userIds", userIds);
            dic.Add("likeTime", likeTime);
            List<string> usernames = new List<string>();
            foreach(int i in userIds)
            {
                sql = "select name from user where id = " + i;
                cmd = new MySQLCommand(sql, con);
                reader = cmd.ExecuteReaderEx();
                while(reader.Read())
                {
                    usernames.Add((string)reader[0]);
                }
            }
            dic.Add("usernames", usernames);
            con.Close();
            return dic;
        }

        public void insertNewCollect(int articleId, int userId, string time)
        {
            init();
            con.Open();
            string sql = "insert into collect_list value(null,"
                       + articleId + ","
                       + userId + ","
                       + "\"" + time + "\")";
            System.Diagnostics.Debug.WriteLine(sql);
            MySQLCommand cmd = new MySQLCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
            return;
        }

        public void deleteCollect(int articleId, int userId, string time)
        {
            init();
            con.Open();
            string sql = "delete from collect_list where "
                       + "article_id = " + articleId + " && "
                       + "user_id = " + userId;
            System.Diagnostics.Debug.WriteLine(sql);
            MySQLCommand cmd = new MySQLCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
            return;
        }

        public bool selectCollect(int articleId, int userId)
        {
            init();
            con.Open();
            string sql = "select * from collect_list where "
                       + "article_id = " + articleId + " && "
                       + "user_id = " + userId;
            System.Diagnostics.Debug.WriteLine(sql);
            MySQLCommand cmd = new MySQLCommand(sql, con);
            MySQLDataReader reader = cmd.ExecuteReaderEx();
            con.Close();
            while (reader.Read())
            {
                return true;
            }
            return false;
        }

        public Dictionary<string, object> selectCollectByUserId(int id)
        {
            init();
            con.Open();
            string sql = "select a.id,a.title,b.user_id,b.time from article a RIGHT JOIN collect_list b on a.id = b.article_id "
                       + "where a.user_id = " + id + " order by b.time desc";
            System.Diagnostics.Debug.WriteLine(sql);
            MySQLCommand cmd = new MySQLCommand(sql, con);
            MySQLDataReader reader = cmd.ExecuteReaderEx();
            List<int> articleIds = new List<int>();
            List<string> articleTitles = new List<string>();
            List<int> userIds = new List<int>();
            List<string> collectTime = new List<string>();
            while (reader.Read())
            {
                byte[] buf0 = (byte[])reader[1];
                articleIds.Add((int)reader[0]);
                articleTitles.Add(encode.numToString(System.Text.Encoding.UTF8.GetString(buf0)));
                userIds.Add((int)reader[2]);
                collectTime.Add(reader[3].ToString());
            }
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("articleIds", articleIds);
            dic.Add("articleTitles", articleTitles);
            dic.Add("userIds", userIds);
            dic.Add("collectTime", collectTime);
            List<string> usernames = new List<string>();
            foreach (int i in userIds)
            {
                sql = "select name from user where id = " + i;
                cmd = new MySQLCommand(sql, con);
                reader = cmd.ExecuteReaderEx();
                while (reader.Read())
                {
                    usernames.Add((string)reader[0]);
                }
            }
            dic.Add("usernames", usernames);
            con.Close();
            return dic;
        }

        public Dictionary<string, object> selectArticleByCollect(int id)
        {
            init();
            con.Open();
            string sql = "select b.* from collect_list a RIGHT JOIN article b on b.id = a.article_id "
                       + "where a.user_id = " + id;
            System.Diagnostics.Debug.WriteLine(sql);
            MySQLCommand cmd = new MySQLCommand(sql, con);
            MySQLDataReader reader = cmd.ExecuteReaderEx();
            List<Article> articles = new List<Article>();
            while(reader.Read())
            {
                byte[] buf0 = (byte[])reader[1];
                byte[] buf1 = (byte[])reader[3];
                byte[] buf2 = (byte[])reader[4];
                byte[] buf3 = (byte[])reader[5];
                articles.Add(new Article((int)reader[0],
                                          encode.numToString(System.Text.Encoding.UTF8.GetString(buf0)),
                                          (int)reader[2],
                                          encode.numToString(System.Text.Encoding.UTF8.GetString(buf1)),
                                          encode.numToString(System.Text.Encoding.UTF8.GetString(buf2)),
                                          encode.numToString(System.Text.Encoding.UTF8.GetString(buf3)),
                                          (string)reader[6],
                                          (string)reader[7],
                                          (string)reader[8],
                                          (int)reader[9],
                                          (int)reader[10],
                                          (int)reader[11],
                                          (int)reader[12],
                                          (int)reader[13],
                                          reader[14].ToString()));
            }
            List<string> usernames = new List<string>();
            foreach(Article article in articles)
            {
                sql = "select name from user where id = " + article.userId;
                cmd = new MySQLCommand(sql, con);
                reader = cmd.ExecuteReaderEx();
                while (reader.Read())
                {
                    usernames.Add((string)reader[0]);
                }
            }
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("articles", articles);
            dic.Add("usernames", usernames);
            return dic;
        }
    }
}