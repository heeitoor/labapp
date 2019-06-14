using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace Lab.Common.Helpers
{
    public class InfoAttribute : Attribute
    {
        public string Descricao { get; set; }
    }

    [Info(Descricao = "Classe de infos vindas do Reflection.")]
    public class LabReflectionInfo
    {
        public int ClassCount { get; set; }

        public List<LabReflectionClassInfo> ClassesInfo { get; set; }

        public class LabReflectionClassInfo
        {
            public string ClassName { get; set; }

            public int ConstructorCount { get; set; }

            public int MethodCount { get; set; }

            public int PropertyCount { get; set; }
        }
    }

    public static class ReflectionHelper
    {
        public static Assembly LoadAssembly(string path = @"C:\Users\heito\Desktop\stuff\labapp\Lab.RFLCTN\bin\Debug\Lab.RFLCTN.dll")
        {
            return Assembly.LoadFrom(path);
        }

        public static Type GetClass(Assembly assembly, string typeName = "Lab.RFLCTN.Pessoa")
        {
            return assembly.GetType(typeName);
        }

        public static ConstructorInfo GetConstructor(Type type)
        {
            return type.GetConstructor(new Type[0]);
        }

        public static object GetInstance(ConstructorInfo constructor)
        {
            return constructor.Invoke(new object[0]);
        }

        public static object CallMethod(Type type, object instance, string methodName = "ToString")
        {
            return type.GetMethod(methodName).Invoke(instance, new object[0]);
        }

        public static object GetPropertyValue(Type type, object instance, string propertyName = "Nome")
        {
            PropertyInfo property = type.GetProperty(propertyName);

            return property.GetValue(instance);
        }

        public static void SetPropertyValue(Type type, object instance, string propertyName = "Nome", string value = "Heitor")
        {
            PropertyInfo property = type.GetProperty(propertyName);

            property.SetValue(instance, value);
        }

        public static object GetInstance(string path = @"C:\Users\heito\Desktop\stuff\labapp\Lab.RFLCTN\bin\Debug\Lab.RFLCTN.dll", string typeName = "Lab.RFLCTN.Pessoa")
        {
            return Activator.CreateInstanceFrom(path, typeName).Unwrap();
        }

        public static LabReflectionInfo GetInfo(this Assembly assembly)
        {
            return new LabReflectionInfo
            {
                ClassCount = assembly.ExportedTypes.Count(),
                ClassesInfo = assembly.ExportedTypes.Select(x => new LabReflectionInfo.LabReflectionClassInfo
                {
                    ClassName = x.Name,
                    MethodCount = x.GetMethods().Count(),
                    PropertyCount = x.GetProperties().Count(),
                    ConstructorCount = x.GetConstructors().Count()
                }).ToList()
            };
        }
    }
}
