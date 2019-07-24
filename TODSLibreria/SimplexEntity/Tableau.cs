using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODSLibreria.SimplexEntity
{
    public class Tableau
    {
        public ObjectiveFunction FuncionObjetivo { get; set; }
        public IEnumerable<VectorEquation> Restricciones { get; set; }
        public IDictionary<string, KeyValuePair<string,double>> Base { get; set; }

        public Tableau(ObjectiveFunction fo, IEnumerable<StandardConstraint> restriccions)
        {
            this.FuncionObjetivo = fo;
            this.Restricciones = ObtenerEcuaciones(restriccions);
            this.Base = ObtenerBase(restriccions);          
        }

        private IEnumerable<VectorEquation> ObtenerEcuaciones(IEnumerable<StandardConstraint> restricciones)
        {
            List<VectorEquation> ecuaciones = new List<VectorEquation>();

            foreach(StandardConstraint re in restricciones)
            {
                ecuaciones.Add(new VectorEquation(re.VariableHolgura, re.CuerpoVector, re.TerminoIndependiente));
            }

            return ecuaciones;
        }

        private IDictionary<string, KeyValuePair<string, double>> ObtenerBase(IEnumerable<StandardConstraint> restricciones)
        {
            Dictionary<string, KeyValuePair<string,double>> _base = new Dictionary<string, KeyValuePair<string, double>>();

            foreach (StandardConstraint re in restricciones)
            {
                _base.Add(re.VariableHolgura, new KeyValuePair<string, double>(re.VariableHolgura, re.TerminoIndependiente));
            }

            return _base;
        }

    }
}
