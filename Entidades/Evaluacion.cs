using System;

namespace CoreEscuela.Entidades
{
    public class Evaluaciones
    {
        public string UniqueID { get; private set; }
        public string Nombre { get; set; }

        public Alumno Alumno { get; set; }
        public Asignatura Asignatura { get; set; }

        public double Nota { get; set; }

        public Evaluaciones() => UniqueID = Guid.NewGuid().ToString();
    }
}