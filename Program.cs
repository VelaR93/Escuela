using System;
using System.Collections.Generic;
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

            // var obj = new ObjetoEscuelaBase();

            Printer.DrawLine(20);
            Printer.DrawLine(20);
            Printer.DrawLine(20);
            Printer.WriteTitle("Pruebas de Polimorfismo");

            var alumnoTest = new Alumno { Nombre = "Julio Varela" };

            Printer.WriteTitle("Alumno");
            Console.WriteLine($"Alumno: {alumnoTest.Nombre}");
            Console.WriteLine($"Alumno.Unique: {alumnoTest.UniqueID}");
            Console.WriteLine($"Alumno.GetType: {alumnoTest.GetType()}");
            
            
            ObjetoEscuelaBase ob = alumnoTest;
            Printer.WriteTitle("ObjetoEscuela");
            Console.WriteLine($"ObjetoEscuelaBase: {ob.Nombre}");
            Console.WriteLine($"ObjetoEscuelaBase.Unique: {ob.UniqueID}");
            Console.WriteLine($"ObjetoEscuelaBase.GetType: {ob.GetType()}");


            var evaluación = new Evaluacion() { Nombre = "Evaluación de math", Nota = 4.5f, };
            Printer.WriteTitle("evaluación");
            Console.WriteLine($"evaluación: {evaluación.Nombre}");
            Console.WriteLine($"evaluación.Unique: {evaluación.UniqueID}");
            Console.WriteLine($"evaluación.Nota: {evaluación.Nota}");
            Console.WriteLine($"evaluación.GetType: {evaluación.GetType()}");

            // ob = evaluación;
            // Printer.WriteTitle("ObjetoEscuela");
            // Console.WriteLine($"ObjetoEscuelaBase: {ob.Nombre}");
            // Console.WriteLine($"ObjetoEscuelaBase.Unique: {ob.UniqueID}");
            // Console.WriteLine($"ObjetoEscuelaBase.GetType: {ob.GetType()}");

            if (ob is Alumno)
            {
                Alumno alumnoRecuperdao = (Alumno) ob;
            }
            //alumnoTest = (Alumno) (ObjetoEscuelaBase) evaluación;


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
