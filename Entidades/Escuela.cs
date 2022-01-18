using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Escuela:ObjetoEscuelaBase
    {
        public int AnoDeCreacion { get; set; }

        public string Pais { get; set; }

        public string Ciudad { get; set; }

        private TiposEscuela TipoEscuela { get; set; }


        public List<Curso> Cursos { get; set; }

    #region Biulders
        public Escuela(string nombre, int ano) => (Nombre, AnoDeCreacion) = (nombre, ano);

        public Escuela(string nombre, int ano, TiposEscuela tipo, string pais="", string ciudad=""){

            (Nombre, AnoDeCreacion) = (nombre, ano);
            Pais = pais;
            Ciudad = ciudad;
        }
    #endregion

        public override string ToString()
        {
            return $"Nombre: \"{Nombre}\", Tipo: {TipoEscuela} {System.Environment.NewLine} Pais: {Pais}, Ciudad:{Ciudad}";
        }

    }

}