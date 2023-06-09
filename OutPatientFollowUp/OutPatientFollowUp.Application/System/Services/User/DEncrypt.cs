using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace OutPatientFollowUp.Application
{
    public class DEncrypt
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public DEncrypt()
        {
        }
        /// <summary>
        /// MD5多重加密
        /// </summary>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static string Md5(string pwd)
        {
            //pwd=Md5(pwd, 0);
            return Md5(GetMd5(pwd), 0).Substring(6, 20);
        }
        /// <summary>
        /// MD5多重加密
        /// </summary>
        public static string Md5(string pwd, bool full)
        {
            //pwd=Md5(pwd, 0);
            return Md5(GetMd5(pwd), 0);
        }
        private static string Md5(string pwd, int num)
        {
            string[] str = { "TJ", "JL", "LM" };
            int rnum = pwd.Length > 9 ? pwd.Length : 10;
            int rnum1 = Convert.ToInt32(rnum.ToString().Substring(0, 1));
            int rnum2 = Convert.ToInt32(rnum.ToString().Substring(1));
            rnum = rnum1 + rnum2;
            pwd = string.Format(pwd.Substring(0, rnum1) + "{0}" + pwd.Substring(rnum1, rnum2) + "{1}" + pwd.Substring(rnum2 + rnum1, rnum) + "{2}" + pwd.Substring(rnum + rnum1 + rnum2), str[0], str[1], str[2]);
            if (num < 3)
            {
                return Md5(GetMd5(pwd), ++num);
            }
            else
            {
                return pwd;
            }
        }
        private static string GetMd5(string pwd)
        {
            using (var md5 = MD5.Create())
            {
                var inputBytes = Encoding.UTF8.GetBytes(pwd);
                var hashBytes = md5.ComputeHash(inputBytes);
                var sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString().Substring(6, 20);
            }
        }

        public static string SetMD5(string str)
        {
            using (var md5 = MD5.Create())
            {
                var inputBytes = Encoding.UTF8.GetBytes(str);
                var hashBytes = md5.ComputeHash(inputBytes);
                var sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

    }
}