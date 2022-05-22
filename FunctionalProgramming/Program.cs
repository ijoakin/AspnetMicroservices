// See https://aka.ms/new-console-template for more information
Console.WriteLine("Init ....");


Func<decimal, decimal> iva = (decimal amount) =>
{
    return (amount * 0.21m) + amount;
};

Func<decimal, decimal> discount = (decimal amount) => amount - (amount * 0.1m);
Func<decimal, decimal> surcharge = (decimal amount) => amount + (amount * 0.2m);
Func<decimal, decimal> annualPartialities = (decimal amount) => amount / 12;

Func<string, string> reverse = (string value) =>
{
    var ar = value.ToArray();
    Array.Reverse(ar);
    return new string(ar);
};

Func<string, string> MytoUpper = (string v) => v.ToUpper();

Console.WriteLine($"the iva value for 35usd is {annualPartialities(discount(iva(surcharge(100))))}");

decimal amount = 100;

amount.Pipe<decimal, decimal>(iva);

// chain of methods
decimal total = amount.Pipe(iva)
    .Pipe(discount)
    .Pipe(surcharge)
    .Pipe(annualPartialities);

Console.WriteLine(total);

string value = "IGnacio";

string value2 = value.StringPipe(reverse).StringPipe(MytoUpper);

Console.WriteLine(value2);

var p = new Person("Ignacio");
p.createPointers();

var (value1, age1) = p; //Call deconstructor

public static class Methods
{   
    public static TOut Pipe<TIn, TOut>(this TIn v, Func<TIn, TOut> fnOut) 
        where TIn: struct 
        where TOut: struct
    {
        return fnOut(v);
    }

    public static TOut StringPipe<TIn, TOut>(this TIn v, Func<TIn, TOut> fnOut)
        where TIn : class
        where TOut : class
    {
        if (v == null)
            return null;
        return fnOut(v);
    }

    //extension methods
    public static decimal decimalPipe(this decimal v, int x)
    {
        v = v * x;
        return v;
    }

    
}
//**/////////

public class Person
{

    public string Name { get; set; }
    public int Age { get; set; }
    public Person(string name)
    {
        Name = name;
    }
    public void Deconstruct(out string name, out int age)
    {
        name = "emp";
        age = 10;
    }
    public unsafe void createPointers()
    {
        int* i;
        int x = 100;

        i = &x; //i apunta a la dirección de x 

        Console.WriteLine(x); // valor de x
        Console.WriteLine((int) i); // direccion de x
        Console.WriteLine(*i); //valor apuntado
    }
}