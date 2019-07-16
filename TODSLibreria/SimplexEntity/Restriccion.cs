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

        public Restriccion (IDictionary<string, double> diccionariVector, string op, double terminoIndepe) : base (diccionariVector, terminoIndepe)
        {
            Operador = op;
        }

        public Restriccion(IEnumerable<string>Cabecera, IEnumerable<double> vector, string op, double terminoIndepe) : base (Cabecera, vector, terminoIndepe)
        {
            Operador = op;
        }

    }
}
