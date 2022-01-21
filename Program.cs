using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;
using CoreEscuela.util;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new EscuelaEngine();

            engine.inicializar();
            Printer.WriteTitle("¡B I E N V E N I D O S   A   L A   E S C U E L A !");
            //Printer.Beep();
            ImprimirCursosEscuela(engine.Escuela);

            int dummy = 0;
            var listaObjetos = engine.GetObjetosEscuela(
            out int conteoEvaluaciones,
            out dummy,
            out dummy,
            out dummy
            );

        }



        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            Printer.WriteTitle("Cursos de la Escuela");

            if (escuela?.Cursos != null)
                foreach (var curso in escuela.Cursos)
                {
                    Console.WriteLine($"Nombre: {curso.Nombre}; Id: {curso.UniqueID}");
                }
            

        }

        private static void ImprimirNotas(Escuela escuela)
        {
            
        }

    
        
        

        

        
        
    }
}
