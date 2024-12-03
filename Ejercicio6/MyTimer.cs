using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ejercicio6
{
    class MyTimer
    {
        public delegate void Delegado();
        public Delegado ejecutar;
        public static readonly object l = new object();
        bool estado = false;

        public int Interval { set; get; }


        public MyTimer(Delegado ejecutar)
        {
            Thread ejecucion = new Thread(funcionamiento);
            this.ejecutar = ejecutar;
            ejecucion.IsBackground = true;
            ejecucion.Start();


        }

        public void funcionamiento()
        {
            while (true)
            {
                lock (l)
                {
                    if (!estado)
                    {
                        Monitor.Wait(l);
                    }
                }

                if (estado && ejecutar != null) // Verificar que el temporizador está activo y la función no es nula
                {
                    ejecutar();
                    Thread.Sleep(Interval); // Respetar el intervalo definido
                }
            }


        }

        public void run()
        {
            if (!estado)
            {
                estado = true;

                lock (l)
                {
                    Monitor.Pulse(l);

                }
            }
        }

        public void pause()
        {
            if (estado)
            {
                estado = false;
            }
        }
    }
}