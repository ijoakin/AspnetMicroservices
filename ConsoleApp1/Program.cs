global using System.Threading;

public class Program {

    public readonly record struct Point(int x, int y, int z);
    
    public static int testingNumber()
    {
        return 32;
    }

    public static void Main(string[] args)
    {
        // See https://aka.ms/new-console-template for more information
        Console.WriteLine("Hello, World!");

        Thread.Sleep(1000);
        Console.WriteLine($"bye{testingNumber()}");

    }

    


}


