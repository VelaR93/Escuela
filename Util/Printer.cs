using System;
using CoreEscuela.Entidades;

namespace CoreEscuela.util

{
    public static class Printer
    {
        public static void DibujarLinea(int tam = 10)
        {
        Console.WriteLine("".PadLeft(tam, '='));
        }

        public static void WriteTitle(string titulo)
        {
            var tamano = titulo.Length + 4;
            DibujarLinea(tamano);
            Console.WriteLine($"| {titulo} |");
            DibujarLinea(tamano);
        }

        public static void Beep(int hz = 2000, int tiempo = 500, int cantidad = 1)
        {
            while (cantidad-- > 0)
            {
                Console.Beep(hz, tiempo);
            }
        }

        
    }
}
