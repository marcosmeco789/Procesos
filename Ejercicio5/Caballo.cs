using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ejercicio
{

    internal class Caballo
    {

    static readonly object l = new object();
    static bool final = false;
        public int Posicion;
        Random rand = new Random();

        public Caballo()
        {
            Posicion = 0;
        }

        public void Correr(int n)
        {
           

            for (int i = 0; i < n; i++)
            {
                Console.Write("*");
            }
        }
    }
}
