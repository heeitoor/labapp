using System;
using System.Collections.Specialized;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab.App.Helpers
{
    public class SerializationHelper
    {
        public static void Serialize<T>(T obj)
        {
            try
            {
                using (FileStream fileStream = new FileStream(@"E:\teste.dat", FileMode.Create, FileAccess.Write))
                {
                    new BinaryFormatter().Serialize(fileStream, obj);
                    fileStream.Close();
                }
            }
            catch (Exception exception)
            {
                throw new SerializationException("Erro ao serializar objeto.", exception);
            }
        }

        public static T DeSerialize<T>(string path = @"E:\teste.dat") where T : class
        {
            try
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    T result = new BinaryFormatter().Deserialize(fileStream) as T;
                    fileStream.Close();
                    return result;
                }
            }
            catch (Exception exception)
            {
                throw new SerializationException("Erro ao deserializar objeto.", exception);
            }
        }
    }


    [Serializable]
    public class ClassTeste : ISerializable
    {
        public string Name { get; set; }

        public ClassTeste() { }

        public ClassTeste(SerializationInfo info, StreamingContext context) { Name = info.GetString("Name"); }

        public void GetObjectData(SerializationInfo info, StreamingContext context) { info.AddValue("Name", Name); }
    }


    public class SimpleIniFormatter : IFormatter
    {
        SerializationBinder binder;
        StreamingContext context;
        ISurrogateSelector surrogateSelector;

        public SimpleIniFormatter()
        {
            context = new StreamingContext(StreamingContextStates.All);
        }

        public object Deserialize(Stream serializationStream)
        {
            StreamReader sr = new StreamReader(serializationStream);

            string line = sr.ReadLine();
            char[] delim = new char[] { '=' };
            string[] sarr = line.Split(delim);
            string className = sarr[1];
            Type t = Type.GetType(className);

            object obj = FormatterServices.GetUninitializedObject(t);

            MemberInfo[] members = FormatterServices.GetSerializableMembers(obj.GetType(), Context);

            object[] data = new object[members.Length];

            StringDictionary sdict = new StringDictionary();
            while (sr.Peek() >= 0)
            {
                line = sr.ReadLine();
                sarr = line.Split(delim);
                sdict[sarr[0].Trim()] = sarr[1].Trim();
            }

            sr.Close();

            for (int i = 0; i < members.Length; ++i)
            {
                FieldInfo fi = ((FieldInfo)members[i]);
                if (!sdict.ContainsKey(fi.Name))
                    throw new SerializationException("Missing field value : " + fi.Name);
                data[i] = Convert.ChangeType(sdict[fi.Name], fi.FieldType);
            }

            return FormatterServices.PopulateObjectMembers(obj, members, data);
        }

        public void Serialize(Stream serializationStream, object graph)
        {
            MemberInfo[] members = FormatterServices.GetSerializableMembers(graph.GetType(), Context);

            object[] objs = FormatterServices.GetObjectData(graph, members);

            StreamWriter sw = new StreamWriter(serializationStream);
            sw.WriteLine("@ClassName={0}", graph.GetType().FullName);

            for (int i = 0; i < objs.Length; ++i)
            {
                sw.WriteLine("{0}={1}", members[i].Name, objs[i].ToString());
            }

            sw.Close();
        }

        public ISurrogateSelector SurrogateSelector
        {
            get { return surrogateSelector; }
            set { surrogateSelector = value; }
        }
        public SerializationBinder Binder
        {
            get { return binder; }
            set { binder = value; }
        }
        public StreamingContext Context
        {
            get { return context; }
            set { context = value; }
        }
    }
}
