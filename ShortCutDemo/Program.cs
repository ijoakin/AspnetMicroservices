using System;

namespace ShortCutDemo
{
    class Program
    {
        static Action Execute(int n)
        {
            int i = 0;

            Console.WriteLine("Init Action");

            return () =>
            {
                if(i < n)
                    Console.WriteLine("I'm a function");
                else
                    Console.WriteLine("i value is too big");
                i++;
            };
        }

        public static unsafe void testing()
        {
            int a = 10;
            int b = 15;
            int* ptr1 = &a;
            int* ptr2 = &b;

            Console.WriteLine((int) ptr1);
            Console.WriteLine((int) ptr2);

        }

        static void Main(string[] args)
        {
            testing();
            //Console.WriteLine("Hello World!");
            Action fn = Execute(2);
            fn();
            fn();
            fn();
            fn();
            fn();
        }
    }
    public class DemoClass { 
    
        public void test()
        {

        }



    }

}
