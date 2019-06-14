using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Lab.Common.Helpers
{
    public static class JsonHelper
    {
        public static string ToJson(object o)
        {
            return JsonConvert.SerializeObject(o);
        }

        public static T FromJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static void Serialize(object o)
        {
            using (FileStream buffer = File.Create(@"d:\config.txt"))
            {
                DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(o.GetType());

                dataContractJsonSerializer.WriteObject(buffer, o);

                buffer.Close();
            }
        }

        public static object Deserialize()
        {
            using (FileStream buffer = File.OpenRead(@"d:\config.txt"))
            {
                DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(object));

                object o = dataContractJsonSerializer.ReadObject(buffer);

                buffer.Close();

                return o;
            }
        }
    }
}
