using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab.Common.Helpers
{
    public static class TaskHelper
    {
        public static void SimpleTask()
        {
            Task t1 = new Task(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("ran t1");
            });

            t1.Start();
            t1.Wait();
        }

        public static Task<string> GetSomethingTask()
        {
            return Task.Run<string>(() =>
            {
                Console.WriteLine("Yo");
                return "task";
            });
        }

        public static void Token()
        {
            try
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
            catch (AggregateException x)
            {


            }
        }

        public static void ParallelForeach()
        {
            Parallel.ForEach(Enumerable.Range(1, 99), (item) =>
            {
                Console.WriteLine(item);
            });
        }

        public static void PLinq()
        {
            foreach (var item in Enumerable.Range(1, 999).AsParallel().Select(x => x))
            {
                Console.WriteLine(item);
            }
        }

        public static void ParallelInvoke()
        {
            Parallel.Invoke(() => Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"Task 1: {i}");
                }
            }),
            () => Task.Run(() =>
             {
                 for (int i = 0; i < 10; i++)
                 {
                     Console.WriteLine($"Task 2: {i}");
                 }
             }),
            () => Task.Run(() =>
             {
                 for (int i = 0; i < 10; i++)
                 {
                     Console.WriteLine($"Task 3: {i}");
                 }
             }));
        }

        public async static void TaskContinue()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("task 1");
            }).ContinueWith((tr) =>
            {
                Console.WriteLine("task 2");
            });
        }

        public async static Task TaskContinue(bool param = true)
        {
            await Task.Run(() =>
            {
                return "Dado da task1";
            }).ContinueWith(t =>
            {
                Console.WriteLine(t.Result);
            });
        }

        /// <summary>
        /// Async Programming Model
        /// </summary>
        public async static void APM()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://reqres.in/api/users/2");

            HttpWebResponse response = await Task<WebResponse>.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, request) as HttpWebResponse;
        }

        public static void HandleEx()
        {
            TaskScheduler.UnobservedTaskException += (object sender, UnobservedTaskExceptionEventArgs eventArgs) =>
            {
                eventArgs.SetObserved();
                eventArgs.Exception.Handle(ex =>
                {
                    Console.WriteLine("Exceção: {0}", ex.GetType());
                    return true;
                });
            };

            Task.Factory.StartNew(() =>
            {
                throw new ArgumentNullException();
            });

            Task.Factory.StartNew(() =>
            {
                throw new ArgumentOutOfRangeException();
            });


            Thread.Sleep(100);
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        static object saldo = 1000;

        public static void ThreadLock()
        {
            Thread t1 = new Thread(new ThreadStart(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i == 5)
                    {
                        lock (saldo)
                        {
                            Thread.Sleep(1000);
                        }
                    }
                    saldo = ((int)saldo) + 1;
                    Thread.Sleep(500);
                }
            }));

            Thread t2 = new Thread(new ThreadStart(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    lock (saldo)
                    {
                        Console.WriteLine($"Thread 2: {saldo}");
                    }
                    Thread.Sleep(500);
                }
            }));

            t1.Start();
            t2.Start();
        }
    }
}
