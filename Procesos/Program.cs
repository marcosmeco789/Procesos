using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Procesos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] v = { 2, 2, 6, 7, 1, 10, 3 };
            Array.ForEach(v, (grade) =>
            {
                Console.ForegroundColor = grade >= 5 ? ConsoleColor.Green : ConsoleColor.Red;
                Console.WriteLine($"Student grade: {grade,3}.");
                Console.ResetColor();
            });
            int res = Array.FindIndex(v, (num) => num >= 5);
            Console.WriteLine($"The first passing student is number {res + 1} in the list.");
            bool flag=Array.Exists(v, (num) => num>=5);
            Console.WriteLine(flag ? "Hay aprobados" : "No hay aprobados");

            int ultimo=Array.FindLastIndex(v, num => num>=5);
            Console.WriteLine("El ultimo indice es {0}\n", ultimo);

          
            Array.ForEach(v, (num) =>
            {
                double inverso = 1.0/num;
                Console.WriteLine("El inverso de {0} es {1}", num, inverso);
       
            });
      
            Console.ReadKey();
        }
    }
}
