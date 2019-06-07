using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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

        public async static Task<string> Post(string url = "https://reqres.in/api/users", string value = "{\"name\":\"morpheus\",\"job\":\"leader\"}")
        {
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(url, new StringContent(value, Encoding.UTF8, "application/json"));

            string result = await httpResponseMessage.Content.ReadAsStringAsync();

            return result;
        }
    }
}
