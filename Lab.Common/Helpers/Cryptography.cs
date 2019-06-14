using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Lab.Common.Helpers
{
    public static class AsymetricCryptographyHelper
    {
        public static void Encrypt(string value, string publicKey, string fileName = @"K:\crpt.cph")
        {
            UnicodeEncoding byteConverter = new UnicodeEncoding();
            byte[] dataToEncrypt = byteConverter.GetBytes(value);
  
            byte[] encryptedData;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(publicKey);
 
                encryptedData = rsa.Encrypt(dataToEncrypt, false);
            }

            File.WriteAllBytes(fileName, encryptedData);

            Console.WriteLine("Data has been encrypted");
        }

        public static string Decrypt(string privateKey, string fileName = @"K:\crpt.cph")
        {
            byte[] dataToDecrypt = File.ReadAllBytes(fileName);
  
            byte[] decryptedData;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(privateKey);
                decryptedData = rsa.Decrypt(dataToDecrypt, false);
            }
  
            UnicodeEncoding byteConverter = new UnicodeEncoding();

            return byteConverter.GetString(decryptedData);
        }
    }

    public static class SymetricCryptographyHelper
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
}
