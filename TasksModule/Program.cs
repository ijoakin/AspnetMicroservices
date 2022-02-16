using System;
using System.Threading;
using System.Threading.Tasks;

namespace TasksModule
{
    class Program
    {
        public static void WriteCars(Char c)
        {
            int i = 100;
            while (i-- > 0)
            {
                Console.Write(c);
            }
        }

        public static void WriteObject(Object o)
        {
            Console.Write(o);
        }
        public static void InifiniteTask()
        {
            int i = 0;
            while (true)
            {

                Console.Write(i++);
            }
        }

        static void Main(string[] args)
        {
            Task.Factory.StartNew(() => WriteCars('?'));

            var t = new Task(() => WriteCars('-'));
            t.Start();

            Task t1 = new Task(WriteObject, "Ignacio");
            t1.Start();

            WriteCars('!');

            //-------------------- Cancelling Tasks -------------------//

            var ct = new CancellationTokenSource();
            var token = ct.Token;

            Task ti = new Task(() =>
            {
                int i = 0;
                while (true)
                {
                    //if (token.IsCancellationRequested)
                    //{
                    //    throw new OperationCanceledException();
                    //}
                    token.ThrowIfCancellationRequested(); // this is the same to use the if and throw ->
                    Console.Write(i++);
                }
            }, token);

            ti.Start();
            Console.ReadKey();
            ct.Cancel();

            Console.WriteLine("Finished");
        }
    }
}
