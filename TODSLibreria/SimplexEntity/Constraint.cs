using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODSLibreria.SimplexEntity
{
    public class Constraint : VectorEquation
    {
        public string Operador { get; set; }

        public Constraint (IDictionary<string, double> diccionariVector, string op, double terminoIndepe) : base (diccionariVector, terminoIndepe)
        {
            Operador = op;
        }

        public Constraint(IEnumerable<string>Cabecera, IEnumerable<double> vector, string op, double terminoIndepe) : base (Cabecera, vector, terminoIndepe)
        {
            Operador = op;
        }

        public Constraint(string nombre, IDictionary<string, double> diccionariVector, string op, double terminoIndepe) : base(nombre, diccionariVector, terminoIndepe)
        {
            Operador = op;
        }

        public Constraint(string nombre, IEnumerable<string> Cabecera, IEnumerable<double> vector, string op, double terminoIndepe) : base(nombre, Cabecera, vector, terminoIndepe)
        {
            Operador = op;
        }

    }
}
