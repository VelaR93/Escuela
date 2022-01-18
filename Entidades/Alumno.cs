using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Alumno:ObjetoEscuelaBase
    {

        public Alumno()
        {
            Evaluaciones = new List<Evaluacion>();
        }

        public List<Evaluacion> Evaluaciones { get; set; } = new List<Evaluacion>();



    }
}