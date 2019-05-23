﻿using Lab.App.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab.App.Helpers
{
    public static class XmlHelper
    {
        public static string ToXml<T>(T obj)
        {
            try
            {
                using (StringWriter stringWriter = new StringWriter())
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    xmlSerializer.Serialize(stringWriter, obj);
                    return stringWriter.ToString();
                }
            }
            catch (Exception exception)
            {
                throw new XmlConvertException(exception);
            }
        }

        public static T FromXml<T>(string xml)
        {
            try
            {
                StringReader stringReader = new StringReader(xml);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                return (T)xmlSerializer.Deserialize(stringReader);
            }
            catch (Exception exception)
            {
                throw new XmlConvertException(exception, "Erro convertendo xml para objeto.");
            }
        }
    }
}
