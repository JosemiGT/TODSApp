using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODSLibreria.SimplexEntity
{
    public class Restriccion : EcuacionVectorial
    {
        public string Operador { get; set; }

        public Restriccion (IDictionary<string, double> diccionariVector, string op, double terminoIndepe)
        {
            CuerpoVector = diccionariVector;
            Operador = op;
            TerminoIndependiente = terminoIndepe;
        }

        public Restriccion(IEnumerable<string>Cabecera, IEnumerable<double> vector, string op, double terminoIndepe)
        {
            CuerpoVector = Cabecera.Zip(vector, (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v);
            Operador = op;
            TerminoIndependiente = terminoIndepe;
        }

    }
}
