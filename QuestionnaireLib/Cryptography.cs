using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace QuestionnaireLib
{
    public static class Cryptography
    {
        public static string ComputeMD5Hash(string text)
        {
            MD5 crypter = MD5.Create();
            byte[] sBytes = Encoding.UTF8.GetBytes(text);
            byte[] hBytes = crypter.ComputeHash(sBytes);
            return BitConverter.ToString(hBytes).Replace("-", "");
        }
    }
}
