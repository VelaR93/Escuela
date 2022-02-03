
using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;
using CoreEscuela.util;

namespace CoreEscuela
{
    public sealed class EscuelaEngine
    {
        //Random rnd = new Random();

        public Escuela Escuela { get; set; }
        public Alumno Alumnos = new Alumno();



        public EscuelaEngine()
        {

        }

        public void inicializar()
        {
            Escuela = new Escuela("Platzi Academy", 2012, TiposEscuela.Preescolar, pais: "Colombia", ciudad: "Bogotá");

            CargarCursos();
            CargarAsignaturas();
            //CargarNota();
            CargarEvaluaciones();

        }

        public void ImprimirDiccionario(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dic,
                    bool imprimirEval = false)
        {
            foreach (var objdic in dic)
            {
                Printer.WriteTitle(objdic.Key.ToString());
                Console.WriteLine(objdic);
                
                foreach (var val in objdic.Value)
                {
                    switch (objdic.Key)
                    {
                        case LlaveDiccionario.Evaluación:
                            if (imprimirEval) Console.WriteLine($"{objdic.Key.ToString()}: {val}");
                            break;
                        case LlaveDiccionario.Escuela:
                            Console.WriteLine($"{objdic.Key.ToString()}: {val}");;
                            break;
                        case LlaveDiccionario.Curso:
                            Console.WriteLine($"{objdic.Key.ToString()}: {val.Nombre}, Cantidad de alumnos: {((Curso)val).Alumnos.Count}");
                            break;
                        case LlaveDiccionario.Alumno:
                            Console.WriteLine($"{objdic.Key.ToString()}: {val.Nombre}");
                            break;
                        default:
                            Console.WriteLine($"{objdic.Key.ToString()}: {val.Nombre}");
                            break;
                    }
                  
                }
            }
        }

        public Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> GetDiccionarioObjetos()
        {
            var diccionario = new Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>>();

            diccionario.Add(LlaveDiccionario.Escuela, new[] {Escuela});
            diccionario.Add(LlaveDiccionario.Curso, Escuela.Cursos.Cast<ObjetoEscuelaBase>());
            //diccionario[LlaveDiccionario.Alumno] = Escuela.Cursos.Cast<ObjetoEscuelaBase>();

            var listtmpAsignatura = new List<Asignatura>();
            var listtmpAlumno = new List<Alumno>();
            var listtmpEvaluacion = new List<Evaluacion>();

            foreach (var cur in Escuela.Cursos){
                listtmpAsignatura.AddRange(cur.Asignaturas);
                listtmpAlumno.AddRange(cur.Alumnos);
                foreach (var alum in cur.Alumnos)
                {
                    listtmpEvaluacion.AddRange(alum.Evaluaciones);
                }

            }
                diccionario.Add(LlaveDiccionario.Asignatura, listtmpAsignatura.Cast<ObjetoEscuelaBase>());
                diccionario.Add(LlaveDiccionario.Evaluación, listtmpEvaluacion.Cast<ObjetoEscuelaBase>());
                diccionario.Add(LlaveDiccionario.Alumno, listtmpAlumno.Cast<ObjetoEscuelaBase>());
            
            //diccionario.Add("Asignaturas", );
            //diccionario.Add("Cursos", Escuela.Cursos[0]); 

            return diccionario;
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true)
            {
            return GetObjetosEscuela(out int dummy, out dummy, out dummy, out dummy);
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
            out int conteoEvaluaciones,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true)
            {
            return GetObjetosEscuela(out conteoEvaluaciones, out int dummy, out dummy, out dummy);
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
            out int conteoEvaluaciones,
            out int conteoAlumnos,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true)
            {
            return GetObjetosEscuela(out conteoEvaluaciones, out conteoAlumnos, out int dummy, out dummy);
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
            out int conteoEvaluaciones,
            out int conteoAlumnos,
            out int conteoAsignaturas,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true)
            {
            return GetObjetosEscuela(out conteoEvaluaciones, out conteoAlumnos, out conteoAsignaturas, out int dummy);
        }


        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
            out int conteoEvaluaciones,
            out int conteoAlumnos,
            out int conteoAsignaturas,
            out int conteoCursos,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true)
        {
            conteoEvaluaciones = conteoAlumnos = conteoAsignaturas = 0;

            var listaobj = new List<ObjetoEscuelaBase>();
            listaobj.Add(Escuela);
            if (traeCursos) listaobj.AddRange(Escuela.Cursos);
            conteoCursos = Escuela.Cursos.Count;
            foreach (var curso in Escuela.Cursos)
            {
                conteoAsignaturas += curso.Asignaturas.Count;
                conteoAlumnos += curso.Alumnos.Count;

                if (traeAsignaturas) listaobj.AddRange(curso.Asignaturas);
                if (traeAlumnos) listaobj.AddRange(curso.Alumnos);
                if (traeEvaluaciones)
                    foreach (var alum in curso.Alumnos)
                    {
                        //El contador de evaluaciones va aquí porque las evaluaciones le pertenecen a alumno, y el foreach vigente es el que recorre la colección de alumnos.
                        listaobj.AddRange(alum.Evaluaciones);
                        conteoEvaluaciones += alum.Evaluaciones.Count;
                    }
            
            }


            return (listaobj.AsReadOnly());
        }
    

    #region Métodos de carga
    private void CargarEvaluaciones()
        {
        var rnd = new Random();
            foreach (var curso in Escuela.Cursos)
            {
                foreach (var asignatura in curso.Asignaturas)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        for (int i = 0; i < 5;i++)
                        {
                            var ev = new Evaluacion
                            {
                                Nombre = $"{asignatura.Nombre} Eva#{i + 1}",
                                Alumno = alumno,
                                Asignatura = asignatura,
                                Nota = MathF.Round((float)rnd.NextDouble() * 10, 2),
                            };
                            alumno.Evaluaciones.Add(ev);
                        }
                    }
                }
            }
            
        }

     
      
        private void CargarAsignaturas()
        {
            foreach (var curso in Escuela.Cursos)
            {
                var listaAsignaturas = new List<Asignatura>()
                {
                    new Asignatura{Nombre = "Matemáticas"},
                    new Asignatura{Nombre = "Educación Física"},
                    new Asignatura{Nombre = "Castellano"},
                    new Asignatura{Nombre = "Ciencias Naturales"}
                };
                curso.Asignaturas = listaAsignaturas;
            }
        }

        private List<Alumno> GenerarAlumnosAlAzar(int cantidad)
        {
            string[] nombre1 = { "Juan", "Diana", "Marco", "Antonio", "Emilio", "Belén", "Marlene" };
            string[] apellido1 = { "Silva", "Muro", "Acevedo", "Orozco", "Ribes", "Uribe", "Camacho" };
            string[] nombre2 = { "Leticia", "María", "Esteban", "Miguel", "Fernanda", "Alberto", "Jo", "Esthela" };
            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno
                               {
                                   Nombre = $"{n1} {n2} {a1}",
                                   //Nota = (this.rnd.NextDouble()) * 5
                               };
           
            //alum.Nota = 0.0;
            // foreach(var Alu in listaAlumnos)
            // {
            //     Alu.Nota = (rnd.NextDouble()) * 5;
            // }
            return listaAlumnos.OrderBy((al)=> al.UniqueID).Take(cantidad).ToList();


        }
        private void CargarCursos()
            {
                Escuela.Cursos = new List<Curso>()
                {
                new Curso() {Nombre = "101", Jornada= TiposJornada.Mañana},
                new Curso() {Nombre = "201", Jornada = TiposJornada.Mañana},
                new Curso() {Nombre = "301", Jornada = TiposJornada.Mañana},
                new Curso() {Nombre = "401", Jornada = TiposJornada.Tarde},
                new Curso() {Nombre = "501", Jornada = TiposJornada.Tarde}
                };

            Random rnd = new Random();
            

            foreach (var c in Escuela.Cursos)
                {
                    int cantRandom = rnd.Next(5,20);
                    c.Alumnos = GenerarAlumnosAlAzar(cantRandom);
                    
                }


            }

        #endregion
    }

}