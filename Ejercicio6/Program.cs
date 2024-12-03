using Ejercicio6;
using System;

class Program
{
    static int counter = 0;

    static void increment()
    {
        counter++;
        Console.WriteLine(counter);
    }

    static void Main(string[] args)
    {
        MyTimer t = new MyTimer(increment); // Pasar la función como delegado
        t.Interval = 1000; // Intervalo de 1 segundo
        string op = "";
        do
        {
            Console.WriteLine("Press any key to start.");
            Console.ReadKey();
            t.run();
            Console.WriteLine("Press any key to pause.");
            Console.ReadKey();
            t.pause();
            Console.WriteLine("Press 1 to continue or Enter to end.");
            op = Console.ReadLine();
        } while (op == "1");
    }
}
