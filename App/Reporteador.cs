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
            return GetListaAsignaturas(out var dummy);
        }

        public IEnumerable<string> GetListaAsignaturas(out IEnumerable<Evaluacion>listaEvaluaciones)
        {
            listaEvaluaciones = GetListaEvaluaciones();

            return (from ev in listaEvaluaciones
                   select ev.Asignatura.Nombre).Distinct();
        }
        public Dictionary<string,IEnumerable<Evaluacion>> GetDicEvalXAsig()
        {
            var dictaRta = new Dictionary<string, IEnumerable<Evaluacion>>();
            var listaAsig = GetListaAsignaturas(out var listaEval);

            foreach (var asig in listaAsig)
            {
                var evalsAsig = 
                    from eval in listaEval
                    where eval.Asignatura.Nombre == asig
                    select eval;
                dictaRta.Add(asig, evalsAsig);
            }
             
            return dictaRta;
        }
           
        
    }
}