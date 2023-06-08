using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OutPatientFollowUp.Application
{
    public class Md5Helper
    {
        /// <summary>
        /// MD5加密方法
        /// </summary>
        /// <param name="input">要加密的字符串</param>
        /// <returns>返回加密后的字符串</returns>

        public static string Encryption(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString().ToLowerInvariant();
            }
        }
    }
}
