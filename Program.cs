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
            AppDomain.CurrentDomain.ProcessExit += AccionDelEvento;
            AppDomain.CurrentDomain.ProcessExit += (o, s) => Printer.Beep(700, 1000, 1);
            var engine = new EscuelaEngine();

            engine.inicializar();
            Printer.WriteTitle("¡B I E N V E N I D O S   A   L A   E S C U E L A !");
            //Printer.Beep();
            //ImprimirCursosEscuela(engine.Escuela);
            Dictionary<int, string> diccionario = new Dictionary<int, string>();

            //diccionario.Add(10, "JuanK");
            //diccionario.Add(23, "Lorem Ipsum");

            foreach (var keyValPair in diccionario)
            {
                Console.WriteLine($"key: {keyValPair.Key} Valor: {keyValPair.Value}");
            }

            var dictmp = engine.GetDiccionarioObjetos();
            System.Console.WriteLine("Inicia la impresión del dicc");
            engine.ImprimirDiccionario(dictmp,true);

        }

        private static void AccionDelEvento(object sender, EventArgs e)
        {
            Printer.WriteTitle("Saliendo");
            Printer.Beep(3000, 1000, 3);
            Printer.WriteTitle("Salió");
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
