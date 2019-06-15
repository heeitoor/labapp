using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        async static Task Main(string[] args)
        {
            await Task.Run(() => { });
            Console.WriteLine("Hello World!");
        }
    }
}
