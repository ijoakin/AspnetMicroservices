using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MultiProcessCore
{
    class Program
    {
        public static int ThreadNew()
        {
            int i = 100000;
            int total = 0;

            for (int j=0; j<i; j++)
            {
                for (int h = 0; h < i; h++)
                {
                    for (int k = 0; k < i; k++)
                    {
                        total = i + k + j;
                    }
                }
            }
            return total;
        }
        static void Main(string[] args)
        {
            var tasks = new List<Task>();
            for (int i = 0; i<27; i++)
            {
                var t = new Task(() => Console.WriteLine(ThreadNew()));
                t.Start();
                tasks.Add(t);
            }

            Task.WaitAll(tasks.ToArray());


            Console.WriteLine("Hello World!");
        }
    }
}
