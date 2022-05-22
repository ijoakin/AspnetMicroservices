//anonymous functions
//Collatz conjecture

Console.WriteLine("Starting Collatz conjecture----");

Func<long, bool> isEven = (long n) => n % 2 == 0;
Action<long> collatz = null; //trick to use recursive line 23

collatz = (long n) =>
{
    long result = 0;
    //Console.WriteLine(n);

    Console.Write('.');
    if (isEven(n))
        result = n / 2;
    else
        result = (n * 3) + 1;
    
    if (result != 1)
    {
        collatz(result);
    }
    else
    {
        //Console.WriteLine(result);
        return;
    }
};


Parallel.For(1, 4568535, (item) =>
{
    collatz(item);
});
