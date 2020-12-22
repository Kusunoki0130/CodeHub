using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySQLDriverCS;
using CodeHub.Models.Entity;

namespace CodeHub.Models.Dao
{
    public class UserDao
    {
        MySQLConnection con;

        public void init()
        {
            con = new MySQLConnection(new MySQLConnectionString("127.0.0.1", "codehub", "root", "123456", 3306).AsString);
        }

        public void instertNewUser(User user)
        {
            init();
            con.Open();
            string sql = "insert into user values(null,"
                       + "\"" + user.name + "\","
                       + "\"" + user.password + "\","
                       + "\"" + user.phone + "\","
                       + "\"" + user.email + "\","
                       + "\"" + user.registerTime + "\","
                       + user.isAdmin + ","
                       + user.follow + ","
                       + user.fans + ","
                       + user.like + ","
                       + user.collect + ","
                       + user.comment + ")";
            System.Diagnostics.Debug.WriteLine(sql);
            MySQLCommand cmd = new MySQLCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
            return;
        }

        public User selectUserByName(string username)
        {
            init();
            con.Open();
            string sql = "select * from user where "
                       + "name = \"" + username + "\"";
            System.Diagnostics.Debug.WriteLine(sql);
            MySQLCommand cmd = new MySQLCommand(sql, con);
            MySQLDataReader reader = cmd.ExecuteReaderEx();
            User user = new User();
            if (!reader.Read())
            {
                return null;
            }
            else
            {
                user.id = (int)reader[0];
                user.name = (string)reader[1];
                user.password = (string)reader[2];
                user.phone = (string)reader[3];
                user.email = (string)reader[4];
                user.registerTime = reader[5].ToString();
                user.isAdmin = (int)reader[6];
                user.follow = (int)reader[7];
                user.fans = (int)reader[8];
                user.like = (int)reader[9];
                user.collect = (int)reader[10];
                user.comment = (int)reader[11];
            }
            return user;
        }
        public User selectUserById(int id)
        {
            init();
            con.Open();
            string sql = "select * from user where "
                       + "id = " + id ;
            System.Diagnostics.Debug.WriteLine(sql);
            MySQLCommand cmd = new MySQLCommand(sql, con);
            MySQLDataReader reader = cmd.ExecuteReaderEx();
            User user = new User();
            if (!reader.Read())
            {
                return null;
            }
            else
            {
                user.id = (int)reader[0];
                user.name = (string)reader[1];
                user.password = (string)reader[2];
                user.phone = (string)reader[3];
                user.email = (string)reader[4];
                user.registerTime = reader[5].ToString();
                user.isAdmin = (int)reader[6];
                user.follow = (int)reader[7];
                user.fans = (int)reader[8];
                user.like = (int)reader[9];
                user.collect = (int)reader[10];
                user.comment = (int)reader[11];
            }
            con.Close();
            return user;
        }

        public void updateUser(User user)
        {
            init();
            con.Open();
            string sql = "update user set "
                       + "follow = " + user.follow + ","
                       + "fans = " + user.fans + ","
                       + "`like` = " + user.like + ","
                       + "collect = " + user.collect + ","
                       + "`comment` = " + user.comment + " "
                       + "where id = " + user.id;
            System.Diagnostics.Debug.WriteLine(sql);
            MySQLCommand cmd = new MySQLCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
            return;
        }

        public void insertFollow(int fanId, int followerId)
        {
            init();
            con.Open();
            string sql = "insert into follow_list value(null,"
                       + fanId + ","
                       + followerId + ")";
            System.Diagnostics.Debug.WriteLine(sql);
            MySQLCommand cmd = new MySQLCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        
        public void deleteFollow(int fanId, int followerId)
        {
            init();
            con.Open();
            string sql = "delete from follow_list where fan_id = " + fanId + " && follow_id = " + followerId;
            System.Diagnostics.Debug.WriteLine(sql);
            MySQLCommand cmd = new MySQLCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<int> selectFollowByFanId(int fanId)
        {
            init();
            con.Open();
            string sql = "select * from follow_list where fan_id = " + fanId;
            System.Diagnostics.Debug.WriteLine(sql);
            MySQLCommand cmd = new MySQLCommand(sql, con);
            MySQLDataReader reader = cmd.ExecuteReaderEx();
            List<int> ids = new List<int>();
            while(reader.Read())
            {
                ids.Add((int)reader[2]);
            }
            return ids;
        }

        public List<int> selectFollowByFollowerId(int followerId)
        {
            init();
            con.Open();
            string sql = "select * from follow_list where follow_id = " + followerId;
            System.Diagnostics.Debug.WriteLine(sql);
            MySQLCommand cmd = new MySQLCommand(sql, con);
            MySQLDataReader reader = cmd.ExecuteReaderEx();
            List<int> ids = new List<int>();
            while (reader.Read())
            {
                ids.Add((int)reader[1]);
            }
            return ids;
        }
    }
}