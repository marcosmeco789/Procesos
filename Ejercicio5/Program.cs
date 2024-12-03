using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Ejercicio
{
    internal class Program
    {
        static readonly object l = new object();
        static bool final = false;
        static Random rand = new Random();
        static Caballo[] caballos = new Caballo[5];
        static int ganador = 0;

        static void Main(string[] args)
        {

            bool repetir = false;
            string siNo = "";
            int numCaballo = 0;
            do
            {
                bool flag1 = false;
                do
                {

                    Console.WriteLine("Apuesta por un caballo! (1-5)");
                    flag1 = int.TryParse(Console.ReadLine(), out numCaballo);

                    if (numCaballo < 1 || numCaballo>5 || !flag1)
                    {
                        Console.WriteLine("Solo numeros del 1 al 5!");
                        flag1 = false;
                    }

                }
                while (!flag1);

                Console.Clear();

                Thread[] hilos = new Thread[5];

                final = false;
                ganador = 0;

                for (int i = 0; i < caballos.Length; i++)
                {
                    caballos[i] = new Caballo();
                    hilos[i] = new Thread(CorrerCaballo);
                    hilos[i].Start(i);
                }


                foreach (Thread hilo in hilos)
                {
                    hilo.Join();
                }

                bool flag2 = false;
            
                    Console.SetCursorPosition(0, 6);
                    if (ganador == numCaballo)
                    {
                        Console.WriteLine("Acertaste! Has ganado la apuesta \n");
                    } else
                    {
                        Console.WriteLine("Fallaste!\n");
                    }

                    Console.WriteLine("Caballo ganador: " + ganador);

                    do
                    {
                    Console.WriteLine("Quieres repetir? (s/n)");
                    siNo = Console.ReadLine();

                    if (siNo == "s")
                    {
                        Console.Clear();
                        repetir = true;
                        flag2 = false;
                    }
                    else if (siNo == "n")
                    {
                        repetir = false;
                        flag2 = false;
                    }
                    else
                    {
                        Console.WriteLine("Letra incorrecta");
                        flag2 = true;
                    }
                }
                while (flag2);



            }
            while (repetir);

        }

        static void CorrerCaballo(object indexObjeto)
        {
            int index = (int)indexObjeto;

            while (!final)
            {
                lock (l)
                {
                    if (!final)
                    {
                        int numeroAleatorio = rand.Next(1, 4);
                        Console.SetCursorPosition(caballos[index].Posicion, index);
                        caballos[index].Correr(numeroAleatorio);
                        caballos[index].Posicion += numeroAleatorio;
                    }
                    if (caballos[index].Posicion >= 50)
                    {
                        final = true;
                        ganador = index + 1;

                    }
                }
                Thread.Sleep(rand.Next(90, 200));
                
                
            }
        }
    }
}
