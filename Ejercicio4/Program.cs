using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ejercicio4
{

    internal class Program
    {


        static int contador = 0;
        static bool continuar = true;
        static readonly object l = new object();

        static void Main(string[] args)
        {
            Thread hilo1 = new Thread(() =>
            {
                while (continuar)
                {
                    lock (l)
                    {
                        if (continuar)
                        {
                            contador++;
                            Console.WriteLine("hilo 1 suma 1: " + contador);
                            if (contador == 500)
                            {
                                continuar = false;


                            }
                        }
                    }

                }
            });

            Thread hilo2 = new Thread(() =>
            {
                while (continuar)
                {
                    lock (l)
                    {
                        if (continuar)
                        {
                            contador--;
                            Console.WriteLine("hilo 2 resta 1: " + contador);
                            if (contador == -500)
                            {
                                continuar = false;


                            }
                        }
                    }
                }
            });

            hilo1.Start();
            hilo2.Start();

            hilo1.Join();
            hilo2.Join();

            if (contador==500)
            {
                Console.WriteLine("El ganador es el hilo 1");
                Console.ReadKey();

            } else if (contador==-500){
                Console.WriteLine("El ganador es el hilo 2");
                Console.ReadKey();
            }

            


        }
    }

}

