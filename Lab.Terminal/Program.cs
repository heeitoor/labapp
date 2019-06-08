using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Lab.Terminal
{
    public class Datum
    {
        public int id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string avatar { get; set; }
    }

    // http://json2csharp.com/#
    // https://reqres.in/
    public class RootObject
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<Datum> data { get; set; }
    }

    class Teste : IDisposable
    {
        public Teste()
        {

        }

        ~Teste()
        {

        }

        public void Dispose()
        {

        }
    }

    public class SymetricCryptographyHelper
    {
        public static string Encrypt<T>(string value, string password, string salt)
           where T : SymmetricAlgorithm, new()
        {
            DeriveBytes rgb = new Rfc2898DeriveBytes(password, Encoding.Unicode.GetBytes(salt));

            SymmetricAlgorithm algorithm = new AesManaged();

            byte[] rgbKey = rgb.GetBytes(algorithm.KeySize >> 3);
            byte[] rgbIV = rgb.GetBytes(algorithm.BlockSize >> 3);

            ICryptoTransform transform = algorithm.CreateEncryptor(rgbKey, rgbIV);

            using (MemoryStream buffer = new MemoryStream())
            {
                using (CryptoStream stream = new CryptoStream(buffer, transform, CryptoStreamMode.Write))
                {
                    using (StreamWriter writer = new StreamWriter(stream, Encoding.Unicode))
                    {
                        writer.Write(value);
                    }
                }

                return Convert.ToBase64String(buffer.ToArray());
            }
        }

        public static string Decrypt<T>(string text, string password, string salt)
           where T : SymmetricAlgorithm, new()
        {
            DeriveBytes rgb = new Rfc2898DeriveBytes(password, Encoding.Unicode.GetBytes(salt));

            SymmetricAlgorithm algorithm = new AesManaged();

            byte[] rgbKey = rgb.GetBytes(algorithm.KeySize >> 3);
            byte[] rgbIV = rgb.GetBytes(algorithm.BlockSize >> 3);

            ICryptoTransform transform = algorithm.CreateDecryptor(rgbKey, rgbIV);

            using (MemoryStream buffer = new MemoryStream(Convert.FromBase64String(text)))
            {
                using (CryptoStream stream = new CryptoStream(buffer, transform, CryptoStreamMode.Read))
                {
                    using (StreamReader reader = new StreamReader(stream, Encoding.Unicode))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }
    }

    class Program
    {
        static void MD5a(out string salt)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] bytes = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString()));

                StringBuilder stringBuilder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    stringBuilder.Append(bytes[i].ToString("x2"));
                }

                salt = stringBuilder.ToString();
            }
        }

        static void Main(string[] args)
        {
            string salt = null;

            MD5a(out salt);

            string chave = "caesar";

            string criptografado = SymetricCryptographyHelper
                .Encrypt<AesManaged>("o rato roeu a roupa do rei de roma.", chave, "");

            //MD5a(out salt);

            string decriptografado = SymetricCryptographyHelper
                .Decrypt<AesManaged>(criptografado, chave, "");

            return;

            using (Teste t = new Teste())
            {

            }

            //System.Diagnostics.Process.Start("notepad");

            //WebClient webClient = new WebClient();

            //string json = webClient.DownloadString("https://reqres.in/api/users?page=2");

            //RootObject obj = JsonConvert.DeserializeObject<RootObject>(json);
        }
    }
}
