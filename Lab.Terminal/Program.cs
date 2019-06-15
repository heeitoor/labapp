using Lab.Common.Helpers;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Lab.Terminal
{
    class Program
    {
        static void Main(string[] args)
        {
            Task main = Task.Run(async () =>
            {
                TaskHelper.ThreadLock();
            });

            main.Wait();

            Console.WriteLine("fim");

            //task2.Wait();

            //Action action = new Action(() =>
            //{
            //    Thread.Sleep(2000);
            //    Console.WriteLine("Oi da action");
            //});

            //Task task1 = new Task(action);

            //task1.Start();
            //task1.Wait();
        }
    }
}

#region Coisas

//RSACryptoServiceProvider provider = new RSACryptoServiceProvider();

//string chavePublica = provider.ToXmlString(false);
//string chavePrivada = provider.ToXmlString(true);

//string texto = "Lorem ipsum dolor sit amet.";

//AsymetricCryptographyHelper.Encrypt(texto, chavePublica, @"C:\lorem.cipher");
//string textoPlano = AsymetricCryptographyHelper.Decrypt(chavePrivada, @"C:\lorem.cipher");


//static T GetAttribute<T>(Type type)
//    where T : Attribute
//{
//    return type
//        .GetCustomAttributes(false)
//        .FirstOrDefault(x => (x as T) != null) as T;
//}

//[AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class)]
//public class NomeAmigavelAttribute : Attribute
//{
//    public string Nome { get; set; }

//    public NomeAmigavelAttribute(string nome = null)
//    {
//        Nome = nome;
//    }
//}

//Assembly assembly = ReflectionHelper
//    .LoadAssembly(@"C:\Users\Administrator\Desktop\labapp\Lab.RFLCTN\bin\Debug\Lab.RFLCTN.dll");

//Type pessoaType = ReflectionHelper.GetClass(assembly);

//ConstructorInfo construtor = ReflectionHelper.GetConstructor(pessoaType);

//object instancia = ReflectionHelper.GetInstance(construtor);

//object toStringResultado = ReflectionHelper.CallMethod(pessoaType, instancia);

//object nomeValor = ReflectionHelper.GetPropertyValue(pessoaType, instancia);

//ReflectionHelper.SetPropertyValue(pessoaType, instancia);

#endregion