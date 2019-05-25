using System.IO;
using System.Net;

namespace Lab.App.Helpers
{
    public static class RequestHelper
    {
        public static string Get1(string url)
        {
            WebClient webClient = new WebClient();

            string resposta = webClient.DownloadString(url);

            return resposta;
        }

        public static string Get2(string url)
        {
            HttpWebRequest httpWebRequest = WebRequest.CreateHttp(url);

            WebResponse webResponse = httpWebRequest.GetResponse();

            StreamReader streamReader = new StreamReader(webResponse.GetResponseStream());

            return streamReader.ReadToEnd();
        }
    }
}
