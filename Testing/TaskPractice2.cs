namespace Testing
{
    internal class TaskPractice2
    {

        public static void exampleUsingLinkedTokens()
        {
            var cts1 = new CancellationTokenSource();

            
        }

        public static void HandlingExceptions()
        {
            var t1 = new Task(() =>
            {
                throw new InvalidOperationException("Can't do this") { Source = "t1" };
            });

            var t2 = new Task(() =>
            {
                throw new AccessViolationException() { Source = "t1" };
            });

            Task.WaitAll(t1, t2);

            Console.WriteLine("");
        }

        public static void WorkingwithCTS()
        {
            
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            var t = new Task(() =>
            {
                //waiting using Thread
                //Thread.Sleep(1000);

                //waiting using SpinWait
                //SpinWait.SpinUntil(() =>
                //{
                //    return true;
                //});

                //waiting using tokens

                Console.WriteLine("Press any key to disarm: you have 5 minutes");
                var cancelled = token.WaitHandle.WaitOne(5000);
                Console.WriteLine(cancelled ? "The bomb was disarm": "Boom!");
            }, token);


            Console.ReadKey();
            cts.Cancel();

            Console.ReadKey();
            Console.WriteLine("finished");
        }

    }
}
