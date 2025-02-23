using System;
using System.Collections.Generic;

namespace Torres_De_Hanoi
{
    internal class Program
    {
        static void MostrarEstado(List<int> torre1, List<int> torre2, List<int> torre3)
        {
            Console.WriteLine("Estado actual de las torres:");
            Console.WriteLine("Torre 1: " + string.Join(", ", torre1));
            Console.WriteLine("Torre 2: " + string.Join(", ", torre2));
            Console.WriteLine("Torre 3: " + string.Join(", ", torre3));
            Console.WriteLine();
        }

        static void ResolverTorres(int n, List<int> origen, List<int> destino, List<int> auxiliar)
        {
            if (n == 1)
            {
                destino.Add(origen[origen.Count - 1]);
                origen.RemoveAt(origen.Count - 1);
                MostrarEstado(origen, destino, auxiliar);
                return;
            }

            ResolverTorres(n - 1, origen, auxiliar, destino);

            destino.Add(origen[origen.Count - 1]);
            origen.RemoveAt(origen.Count - 1);
            MostrarEstado(origen, destino, auxiliar);

            ResolverTorres(n - 1, auxiliar, destino, origen);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese el número de discos:");
            int discos = int.Parse(Console.ReadLine());

            List<int> torre1 = new List<int>();
            List<int> torre2 = new List<int>();
            List<int> torre3 = new List<int>();

            for (int i = discos; i > 0; i--)
            {
                torre1.Add(i);
            }

            MostrarEstado(torre1, torre2, torre3);

            ResolverTorres(discos, torre1, torre3, torre2);

            Console.WriteLine("El juego ha terminado.");
        }
    }
}
