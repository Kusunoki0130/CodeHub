using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeHub.utils
{
    public class Encode
    {
        public string stringToNum(string str)
        {
            string res = "";
            for (int i=0;i<str.Length;++i)
            {
                int num = (int)str[i];
                res += Convert.ToString(num) + " ";
            }
            return res;
        }
        public string numToString(string str)
        {
            string res = "";
            string temp = "";
            for (int i=0;i<str.Length;++i)
            {
                if (str[i]==' ')
                {
                    int num = Convert.ToInt32(temp);
                    res += (char)num;
                    temp = "";
                }
                else
                {
                    temp += str[i];
                }
            }
            return res;
        }

        public Dictionary<string, object> getFollow(string str)
        {
            str += "b";
            bool flag = false;
            int num1 = 0;
            int num2 = 0;
            bool follow = false;
            string temp = "";
            for (int i=0;i<str.Length;++i)
            {
                if (str[i]<'0'||str[i]>'9')
                {
                    if (flag)
                    {
                        num2 = Convert.ToInt32(temp);
                    }
                    else
                    {
                        num1 = Convert.ToInt32(temp);
                        flag = true;
                    }
                    temp = "";
                    if (str[i]=='a')
                    {
                        follow = true;
                    }
                }
                else
                {
                    temp += str[i];
                }
            }
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("fan", num1);
            dic.Add("follower", num2);
            dic.Add("isFollow", follow);
            return dic;
        }

        public Dictionary<string, object> getLC(string str)
        {
            string[] strs = str.Split('a');
            int num1 = Convert.ToInt32(strs[0]);
            int num2 = Convert.ToInt32(strs[1]);
            string temp = strs[2] + " " + strs[3]; 
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("articleId", num1);
            dic.Add("userId", num2);
            dic.Add("time", temp);
            return dic;
        }

        public Dictionary<string, object> getComment(string str)
        {
            string[] strs = str.Split('a');
            int num1 = Convert.ToInt32(strs[0]);
            int num2 = Convert.ToInt32(strs[1]);
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("articleId", num1);
            dic.Add("userId", num2);
            return dic;
        }
    }
}