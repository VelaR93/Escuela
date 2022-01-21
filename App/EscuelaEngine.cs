
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

        public List<ObjetoEscuelaBase> GetObjetosEscuela(
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true)
            {
            return GetObjetosEscuela(out int dummy, out dummy, out dummy, out dummy);
        }

        public List<ObjetoEscuelaBase> GetObjetosEscuela(
            out int conteoEvaluaciones,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true)
            {
            return GetObjetosEscuela(out conteoEvaluaciones, out int dummy, out dummy, out dummy);
        }

        public List<ObjetoEscuelaBase> GetObjetosEscuela(
            out int conteoEvaluaciones,
            out int conteoAlumnos,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignaturas = true,
            bool traeCursos = true)
            {
            return GetObjetosEscuela(out conteoEvaluaciones, out conteoAlumnos, out int dummy, out dummy);
        }

        public List<ObjetoEscuelaBase> GetObjetosEscuela(
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


        public List<ObjetoEscuelaBase> GetObjetosEscuela(
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


            return (listaobj);
        }
    

    #region Métodos de carga
    private void CargarEvaluaciones()
        {
            foreach (var curso in Escuela.Cursos)
            {
                foreach (var asignatura in curso.Asignaturas)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        var rnd = new Random();
                        for (int i = 0; i < 5;i++)
                        {
                            var ev = new Evaluacion
                            {
                                Nombre = $"{asignatura.Nombre} Eva#{i + 1}",
                                Alumno = alumno,
                                Asignatura = asignatura,
                                Nota = (float)((rnd.NextDouble()) * 5),
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