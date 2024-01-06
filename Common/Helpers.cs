using System;
using System.Text;
using System.Security.Cryptography;
using System.Linq;

namespace Common
{
    public class Helpers
    {
        public static string[] arrHexa = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };
        public static string HasPassword(string password)
        {
            //chuyển mật khẩu sang mảng byte
            var sha1 = new SHA1CryptoServiceProvider();
            var bytesPw = Encoding.ASCII.GetBytes(password);

            //salt và chuyển salt sang byte
            var salt = DateTime.Now.Millisecond.ToString();
            var bytesSalt = Encoding.ASCII.GetBytes(salt);

            //hash
            var bytesPwhashed = sha1.ComputeHash(bytesPw);

            //gắn salt lưu xuống database
            var bytesResult = new byte[bytesPwhashed.Length + bytesSalt.Length];
            Array.Copy(bytesPwhashed, bytesResult, bytesPwhashed.Length);
            Array.Copy(bytesSalt, 0, bytesResult, bytesPwhashed.Length, bytesSalt.Length);


            // chuyển array byte sang string
            var strPwHash = ArrByteToString(bytesResult);
            return strPwHash;
        }

        public static string ArrByteToString(Byte[] arrByte)
        {
            StringBuilder sb = new StringBuilder();

            foreach (byte b in arrByte)
            {
                //get 4 bit first
                sb.Append(Helpers.arrHexa[(b >> 4)]);
                //get 4 bit second
                sb.Append(Helpers.arrHexa[(b & 15)]);
            }

            return sb.ToString();
        }

        public static byte[] StringToByteArray(string str)
        {
            return Enumerable.Range(0, str.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(str.Substring(x, 2), 16))
                             .ToArray();
        }
    }
}
