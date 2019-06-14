using System.Security.Cryptography;
using System.Text;

namespace Lab.Common.Helpers
{
    public static class HashHelper
    {
        public static string ToMD5(string value)
        {
            using (
            MD5 md5Hash = MD5.Create())
            {

                byte[] bytes = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(value));

                StringBuilder stringBuilder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    stringBuilder.Append(bytes[i].ToString("x2"));
                }

                return stringBuilder.ToString();
            }
        }
    }
}
