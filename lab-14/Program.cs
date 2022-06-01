using System;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.IO;

namespace lab_14
{
    class Program
    {
        static void Main(string[] args)
        {
            //Thread thread = new Thread(work);
            //thread.Start();
            ////thread.IsBackground = true;
            //thread.Join();
            
            Task task = Task.Run(work);
            TaskAwaiter taskAwaiter = task.GetAwaiter();
            taskAwaiter.OnCompleted(() => Console.WriteLine("koniec")) ;
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100);
                Console.WriteLine("Main: ");
            }
            Task.Run(() =>
            {
                int result = CalcAsync().Result;
                Console.WriteLine(result);
            });
        }
        
        static void work()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100);
                Console.Write("Wątek:" + i);
            }
        }
        static async Task<int> CalcAsync()
        {
            string[] lines= await File.ReadAllLinesAsync("d:\\rates.txt");
            return 10;
        }
    }
}
