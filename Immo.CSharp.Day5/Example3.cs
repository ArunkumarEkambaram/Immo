using System;
using System.Threading;
using System.Threading.Tasks;

namespace Immo.CSharp.Day5
{
    internal class ThreadExample
    {
        public void GetData1()
        {
            for (int i = 0; i < 50; i++)
            {
                Thread.Sleep(100);
                Console.WriteLine($"Thread 1 :{i}");
            }
        }

        public void GetData2()
        {
            for (int i = 0; i < 50; i++)
            {
                Thread.Sleep(100);
                Console.WriteLine($"Thread 2 :{i}");
            }
        }
    }

    public class AsyncOperation1
    {
        public async Task GetData1()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 50; i++)
                {
                    Task.Delay(100);
                    Console.WriteLine($"Task 1 :{i}");
                }
            });
        }

        public async Task GetData2()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 50; i++)
                {
                    Task.Delay(100);
                    Console.WriteLine($"Task 2 :{i}");
                }
            });
        }
    }
}
