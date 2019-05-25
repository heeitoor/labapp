using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab.Terminal
{
    class Program
    {
        async static void SimpleTask()
        {
            Task t1 = new Task(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("ran t1");
            });

            t1.Start();
            t1.Wait();
        }

        static Task<string> GetSomethingTask()
        {
            return Task.Run<string>(() =>
           {
               return "task";
           });
        }

        static void Token()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token;

            Task a = new Task(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(500);
                    Console.WriteLine("Task A " + i);

                    if (cancellationToken.IsCancellationRequested)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                    }
                }

            }, cancellationToken);

            Task b = new Task(() =>
            {
                Thread.Sleep(2000);
                cancellationTokenSource.Cancel();
            });

            a.Start();
            b.Start();

            Task.WaitAll(a, b);
        }

        static void ParallelForeach()
        {

            Parallel.ForEach(Enumerable.Range(1, 99), (item) =>
            {
                Console.WriteLine(item);
            });
        }

        static void PLinq()
        {

            Enumerable.Range(1, 99).Select(x =>
            {
                Console.WriteLine(x);
                Thread.Sleep(100);
                return 0;
            }).AsParallel().ToList();
        }

        async static void TaskContinue()
        {

            await Task.Run(() =>
            {
                Console.WriteLine("task 1");
            }).ContinueWith((tr) =>
            {
                Console.WriteLine("task 2");
            });
        }

        async static void tc()
        {
            await Task.Run<string>(() =>
            {
                return "result from task 1";
            }).ContinueWith((tr) =>
            {
                Console.WriteLine("recebido de task1: " + tr.Result);
            });
        }

        async static Task Main(string[] args)
        {
            //HttpClient a = new HttpClient();
            
            //HttpWebRequest httpWebRequest = WebRequest.CreateHttp("https://yts.am/api/v2/list_movies.json");
            
            //WebResponse webResponse = q.GetResponse();
            
            //StreamReader sr = new StreamReader(webResponse.GetResponseStream());

            //Console.WriteLine(sr.ReadToEnd());

            //WebClient wc = new WebClient();

            //var k = wc.DownloadString("https://yts.am/api/v2/list_movies.json");

            ////Console.WriteLine(k);

            //Console.WriteLine("end");
        }
    }
}
