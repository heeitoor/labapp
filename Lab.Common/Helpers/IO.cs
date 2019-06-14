using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Lab.Common.Helpers
{
    public static class IOHelper
    {
        public static string Ler(string path)
        {
            //List<int> inteiros = Enumerable.Range(1, 99).ToList();

            //foreach (var inteiro in inteiros)
            //{
            //    if (inteiro == 56)
            //    {
            //        continue;
            //    }

            //    /* LÓGICA GIGANTE */

            //    if (inteiro == 56)
            //    {
            //        break;
            //    }
            //}
            
            if (!File.Exists(path))
            {
                return string.Empty;
            }

            //string r1 = File.ReadAllText(path);
            //IEnumerable<string> r2 = File.ReadLines(path);
            //byte[] bytes = File.ReadAllBytes(path);
            //string r3 = Encoding.UTF8.GetString(bytes);

            using (StreamReader streamReader = new StreamReader(path))
            {
                return streamReader.ReadToEnd();
            }
        }

        public static object LinhaALinha(string path)
        {
            using (StreamReader streamReader = new StreamReader(path))
            {
                string linha;

                while ((linha = streamReader.ReadLine()) != null)
                {

                }

                while (streamReader.EndOfStream)
                {
                    linha = streamReader.ReadLine();
                }
            }

            return null;
        }

        public static void Escrever(string path, string line)
        {
            //File.AppendAllText(path, line);
            //File.WriteAllText(path, line);
            //File.WriteAllLines(path, new[] { line, line });
            //File.WriteAllBytes(path, Encoding.UTF8.GetBytes(line));

            using (StreamWriter streamWriter = new StreamWriter(path, true))
            {
                streamWriter.WriteLine(line);
            }
        }

        public static FileInfo GetFileInfo(string path)
        {
            return new FileInfo(path);
        }

        public static DirectoryInfo GetDirectoryInfo(string path)
        {
            // Environment

            return new DirectoryInfo(path);
        }

        public static FileInfo[] GetFiles(string path)
        {
            DirectoryInfo directoryInfo = GetDirectoryInfo(path);

            return directoryInfo.GetFiles();
        }
    }
}
