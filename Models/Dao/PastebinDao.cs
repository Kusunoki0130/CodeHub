using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySQLDriverCS;
using CodeHub.Models.Entity;

namespace CodeHub.Models.Dao
{
    public class PastebinDao
    {
        MySQLConnection con;
        public void init()
        {
            con = new MySQLConnection(new MySQLConnectionString("127.0.0.1", "codehub", "root", "123456", 3306).AsString);
        }
        public int insertNewPasteCode(PasteCode pasteCode)
        {
            init();
            con.Open();
            string sql = "insert into paste_code value(null,"
                       + "\"" + pasteCode.poster + "\","
                       + "\"" + pasteCode.language + "\","
                       + "\"" + pasteCode.languagemode + "\","
                       + "\"" + pasteCode.theme + "\","
                       + "\"" + pasteCode.code + "\","
                       + "\"" + pasteCode.time + "\")";
            System.Diagnostics.Debug.WriteLine(sql);
            MySQLCommand cmd = new MySQLCommand(sql, con);
            cmd.ExecuteNonQuery();
            sql = "select id from paste_code where "
                + "poster = " + "\"" + pasteCode.poster + "\" && "
                + "time = " + "\"" + pasteCode.time + "\"";
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

        public PasteCode selectPasteCodeById(int id)
        {
            init();
            con.Open();
            string sql = "select * from paste_code where "
                       + "id = " + id;
            System.Diagnostics.Debug.WriteLine(sql);
            MySQLCommand cmd = new MySQLCommand(sql, con);
            MySQLDataReader reader = cmd.ExecuteReaderEx();
            PasteCode pasteCode = new PasteCode();
            while(reader.Read())
            {
                pasteCode.id = (int)reader[0];
                pasteCode.poster = reader[1].ToString();
                System.Diagnostics.Debug.WriteLine(pasteCode.poster);
                pasteCode.language = reader[2].ToString();
                System.Diagnostics.Debug.WriteLine(pasteCode.language);
                pasteCode.languagemode = reader[3].ToString();
                System.Diagnostics.Debug.WriteLine(pasteCode.languagemode);
                pasteCode.theme = reader[4].ToString();
                System.Diagnostics.Debug.WriteLine(pasteCode.theme);
                byte[] buf = (byte[])reader[5];
                pasteCode.code = System.Text.Encoding.UTF8.GetString(buf);
                System.Diagnostics.Debug.WriteLine(pasteCode.code);
                pasteCode.time = reader[6].ToString();
                System.Diagnostics.Debug.WriteLine(pasteCode.time);
            }
            con.Close();
            return pasteCode;
        }
    }
}