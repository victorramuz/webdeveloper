using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Presentation
{
    public class MD5Configuration
    {
        public static string Encrypt(string value)
        {
            //criptografando..
            var md5 = new MD5CryptoServiceProvider();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(value));

            //retornando o HASH em padrão HEXADECIMAL
            string hex = string.Empty;
            foreach(var h in hash)
            {
                hex = h.ToString("X2"); //HEXADECIMAL
            }

            return hex;
        }
    }
}
