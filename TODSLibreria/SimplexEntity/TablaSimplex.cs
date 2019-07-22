using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODSLibreria.SimplexEntity
{
    public class TablaSimplex
    {
        public FuncionObjetivo FuncionObjetivo { get; set; }
        public IEnumerable<EcuacionVectorial> Restricciones { get; set; }
        public IDictionary<string, KeyValuePair<string,double>> Base { get; set; }

        public TablaSimplex(FuncionObjetivo fo, IEnumerable<RestriccionEstandarizada> restriccions)
        {
            this.FuncionObjetivo = fo;
            this.Restricciones = ObtenerEcuaciones(restriccions);
            this.Base = ObtenerBase(restriccions);          
        }

        private IEnumerable<EcuacionVectorial> ObtenerEcuaciones(IEnumerable<RestriccionEstandarizada> restricciones)
        {
            List<EcuacionVectorial> ecuaciones = new List<EcuacionVectorial>();

            foreach(RestriccionEstandarizada re in restricciones)
            {
                ecuaciones.Add(new EcuacionVectorial(re.VariableHolgura, re.CuerpoVector, re.TerminoIndependiente));
            }

            return ecuaciones;
        }

        private IDictionary<string, KeyValuePair<string, double>> ObtenerBase(IEnumerable<RestriccionEstandarizada> restricciones)
        {
            Dictionary<string, KeyValuePair<string,double>> _base = new Dictionary<string, KeyValuePair<string, double>>();

            foreach (RestriccionEstandarizada re in restricciones)
            {
                _base.Add(re.VariableHolgura, new KeyValuePair<string, double>(re.VariableHolgura, re.TerminoIndependiente));
            }

            return _base;
        }

    }
}
