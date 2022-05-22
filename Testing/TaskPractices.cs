using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public static class TaskPractices
    {


        public static void Write(char c)
        {
            int i = 1000;

            while (i-- > 0)
            {
                Console.Write(c);
            }
        }
        public static void Write(object o)
        {
            int i = 1000;

            while (i-- > 0)
            {
                Console.Write(o);
            }
        }
        public static void Concurrent()
        {
            var myTask = new Task<int>(() =>
            {
                Console.Write("values");
                return 1;
            });

            myTask.Start();
        }
        public static int TextLenght(object o)
        {
            Console.WriteLine($"\nTask with id {Task.CurrentId} processing Object {o}...");

            return o.ToString().Length;
        }

        static Tuple<int, string> getValue()
        {
            return new Tuple<int, string>(new Random().Next(), "value");
        }

        public static void WorkingWithTuples()
        {
            var dic = new Dictionary<int, Tuple<int, string>>();

            for (int i=0;i<100; i++)
            {
                string value = "";
                (_, value)= getValue();

                dic.Add(i, new Tuple<int, string>(i, value));
            }
        }
        public static void UnitOfWorkForever(char c, CancellationToken token)
        {
            while (true)
            {

                //token.ThrowIfCancellationRequested();
                Console.WriteLine(c);
                if (token.IsCancellationRequested)
                {
                    break;
                    throw new OperationCanceledException();

                }
                else
                {
                    Console.WriteLine(c);
                }
            }
        }

        public static unsafe void workingWithPointer()
        {
            int x = 10;
            int y = 201;

            int* px = &x;
            int* py = &y;
            Console.WriteLine("");
            Console.WriteLine(x);
            Console.WriteLine(*px);
            Console.WriteLine(*py);

        }

        public static void testingPractices()
        {
            List<Task> listOfTask = new List<Task>();

            listOfTask.Add(Task.Factory.StartNew(() =>
            {
                Write('.');
            }));

            var t = new Task(() =>
            {
                Write('?');
            });

            listOfTask.Add(t);

            t.Start();

            Write('-');

            var t1 = new Task(Write, "hello");
            t1.Start();

            listOfTask.Add(t1);

            listOfTask.Add(Task.Factory.StartNew(Write, 123));



            string text1 = "testing";
            string text2 = "this";

            Task.WaitAll(listOfTask.ToArray());

            var task1 = new Task<int>(TextLenght, text1);
            task1.Start();

            Task<int> task2 = Task.Factory.StartNew(TextLenght, text2);

            Console.WriteLine($"the text length {task1.Result}");
            Console.WriteLine($"the text length {task2.Result}");


            //Cancel tasks.
            var cts = new CancellationTokenSource();

            var token = cts.Token;

            var task = new Task(() =>
            {
                UnitOfWorkForever('c', token);
            });

            task.Start();

            Console.ReadKey();
            cts.Cancel();



            workingWithPointer();

            Console.WriteLine("Hello, World!");
            Console.ReadKey();
        }
    }
}
