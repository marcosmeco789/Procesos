using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    internal class Program

    {
        public delegate void MyDelegate();
        public static bool MenuGenerator(string[] namesOptions, MyDelegate[] delegates)
        {

            if (namesOptions == null || delegates == null || namesOptions.Length != delegates.Length
                || namesOptions.Contains(null) || delegates.Contains(null))//Elementos de los parametros !=null. Revisar opcion 4 y siguientes.
            {
                return false;
            }

            bool valid = false;
            int option = 0;
            bool close = false;
            int exit = 1;

            do
            {
                exit = 1;
                Console.WriteLine("\n[+] Welcome!\n");
                for (int i = 0; i < namesOptions.Length; i++)
                {
                    Console.WriteLine("Option " + $"{i + 1}{": " + namesOptions[i]}");
                    exit++;
                }

                Console.WriteLine("Option " + exit + ": Exit");
                do
                {
                    Console.WriteLine("\nPlease select an option!");
                    bool flag = int.TryParse(Console.ReadLine(), out option);

                    if (option >= 1 && option <= delegates.Length)
                    {
                        delegates[option - 1]();
                        valid = true;
                    }
                    else if (option == exit)
                    {
                        Console.WriteLine("\n[!] Closing...");
                        valid = true;
                        close = true;
                    }
                    else
                    {
                        Console.WriteLine("\nIncorrect number! Try again");
                        valid = false;
                        break;
                    }


                }
                while (valid == false);
            }
            while (close == false);
            return true;

        }


        static void Main(string[] args)
        {
            MenuGenerator(new string[] { "Op1", "Op2", "Op3", "Op4" },
            new MyDelegate[] {() => Console.WriteLine("A"),
                              () => Console.WriteLine("B"),
                              () => Console.WriteLine("C"),
                              () => Console.WriteLine("D")});
            Console.ReadKey();
        }
    }
}
