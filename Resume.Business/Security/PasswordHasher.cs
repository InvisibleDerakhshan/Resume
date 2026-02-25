using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Business.Security
{
    public static class PasswordHasher
    {

        public static string EncodePasswordMd5(this string pass)
        {
            Byte[] originalbytes;
            Byte[] encodedbytes;
            
            MD5 md5;
            md5 =new MD5CryptoServiceProvider();
            originalbytes =ASCIIEncoding.Default.GetBytes(pass);
            encodedbytes= md5.ComputeHash(originalbytes);

            return BitConverter.ToString(encodedbytes);
        }
    }
}
