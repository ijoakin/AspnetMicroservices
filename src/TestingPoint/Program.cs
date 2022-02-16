using GraphicsLibrary;
using System;

namespace TestingPoint
{
    public class Program
    {
        public static void CreatePoints()
        {
            for (int i = 0; i < 100; i++)
            {
                var p1 = new Point(2, 3);
                var p2 = new Point(7, 5);

                var p3 = p1 + p2;
                Console.WriteLine(p3);
            }

        }

        static void Main(string[] args)
        {
            CreatePoints();
            Console.WriteLine("Hello World!");
        }
    }
}
