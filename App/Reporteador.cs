using System.Linq;
using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;

namespace CoreEscuela.App
{
    public class Reporteador
    {
        Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> _diccionario;
        public Reporteador(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dicObjEsc)
        {
            if (dicObjEsc == null)
                throw new ArgumentException(nameof(dicObjEsc));

            _diccionario = dicObjEsc;

        }

        public IEnumerable<Evaluacion> GetListaEvaluaciones()
        {
            if (_diccionario.TryGetValue(LlaveDiccionario.Evaluación,
                                            out IEnumerable<ObjetoEscuelaBase> lista))
            {
                return lista.Cast<Evaluacion>();
            }
            {
                return new List<Evaluacion>();
            }
        }

        public IEnumerable<string> GetListaAsignaturas()
        {
            var ListaEvaluaciones = GetListaEvaluaciones();

            return (from ev in ListaEvaluaciones
                   select ev.Asignatura.Nombre).Distinct();
        }
        public Dictionary<string,IEnumerable<Evaluacion>> GetDicEvalXAsig()
        {
            var dictaRta = new Dictionary<string, IEnumerable<Evaluacion>>();
            
            return dictaRta;
        }
    }
}