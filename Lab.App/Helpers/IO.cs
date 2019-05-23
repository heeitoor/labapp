using System.IO;

namespace Lab.App.Helpers
{
    public static class IOHelper
    {
        public static string Ler(string path)
        {
            using (StreamReader streamReader = new StreamReader(path))
            {
                return streamReader.ReadToEnd();
            }
        }

        public static void Escrever(string path, string line)
        {
            using (StreamWriter streamWriter = new StreamWriter(path, true))
            {
                streamWriter.WriteLine(line);
                streamWriter.Flush();
            }
        }

        public static FileInfo GetFileInfo(string path)
        {
            return new FileInfo(path);
        }

        public static DirectoryInfo GetDirectoryInfo(string path)
        {
            return new DirectoryInfo(path);
        }

        public static FileInfo[] GetFiles(string path)
        {
            DirectoryInfo directoryInfo = GetDirectoryInfo(path);

            return directoryInfo.GetFiles();
        }
    }
}
