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

            //Revisar la variable nota y por qué no se usa; se supone que debe asignársele la nota para llevar notaString a nota.

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
                Printer.WriteTitle("El valor introducido debe ser distinto a vacío");
                Console.WriteLine("Saliendo del programa");
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
                Printer.WriteTitle("El valor introducido debe ser distinto a vacío");
                Console.WriteLine("Saliendo del programa");
            }
            else
            {
                try
                {
                    newEval.Nota = float.Parse(notaString);
                    if (newEval.Nota<0 || newEval.Nota>10)
                    {
                        throw new ArgumentOutOfRangeException("La nota debe estar entre 0 y 10");
                    }
                    Console.WriteLine("La nota fue capturada correctamente");
                }
                catch(ArgumentOutOfRangeException arge)
                {
                    Console.WriteLine(arge.Message);
                }
                catch (Exception)
                {
                    Printer.WriteTitle("El valor de la nota no parece ser un número válido");
                    Console.WriteLine("Saliendo del programa");
                }
                finally
                {
                    Printer.WriteTitle("FINALMENTE");
                    Printer.Beep(2500, 500, 3);
                }


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
