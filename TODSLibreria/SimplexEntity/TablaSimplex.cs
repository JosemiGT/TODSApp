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
        public IDictionary<string, double> Base { get; set; }

        public TablaSimplex(FuncionObjetivo fo, IEnumerable<RestriccionEstandarizada> restriccions)
        {
            this.FuncionObjetivo = fo;
            this.Restricciones = restriccions.ToList();
            this.Base = new Dictionary<string, double>();
            foreach(RestriccionEstandarizada re in restriccions) { Base.Add(re.VariableHolgura, re.TerminoIndependiente); }
        }

    }
}
