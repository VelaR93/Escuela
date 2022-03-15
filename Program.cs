using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;
using CoreEscuela.util;
using CoreEscuela.App;

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

            Printer.DrawLine();

            var reporteador = new Reporteador(engine.GetDiccionarioObjetos());
            var evalList = reporteador.GetListaEvaluaciones();
            var evalAsg = reporteador.GetListaAsignaturas();
            Printer.DrawLine();
            var evalXAsig = reporteador.GetDicEvalXAsig();
            var listaPromXAsignatura = reporteador.GetPromedioAlumXAsig(5);

            Printer.WriteTitle("Captura de una Evaluación por consola");
            var newEval = new Evaluacion();
            string nombre;
            float nota;
            string notaString;

            Console.WriteLine("Ingrese el nombre de la evaluación.");
            Printer.PresioneENTER();
            nombre = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El valor introducido debe ser distinto a vacío");
            }
            else
            {
                newEval.Nombre = nombre.ToLower();
                Console.WriteLine("El nombre de la evaluación ha sido correcto");
            }

            Console.WriteLine("Ingrese la nota de la evaluación.");
            Printer.PresioneENTER();
            notaString = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(notaString))
            {
                throw new ArgumentException("El valor introducido debe ser distinto a vacío");
            }
            else
            {
                newEval.Nota = float.Parse(notaString);
                Console.WriteLine("El valor de la evaluación ha sido correcto");
            }

        }

        
        private static void AccionDelEvento(object sender, EventArgs e)
        {
            Printer.WriteTitle("Saliendo");
            Printer.Beep(700, 1000, 3);
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
