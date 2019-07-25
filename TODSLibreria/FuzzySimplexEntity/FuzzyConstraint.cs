using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODSLibreria.FuzzyEntity;

namespace TODSLibreria.FuzzySimplexEntity
{
    public class FuzzyConstraint : FuzzyVectorEquation
    {
        public string Operator { get; set; }

        #region Constructors - Full term fuzzy.
        public FuzzyConstraint(IDictionary<string, TRFN> cuerpoVector, string oper, TRFN termindepe) : base(cuerpoVector, termindepe)
        {
            Operator = oper;
        }

        public FuzzyConstraint(IEnumerable<string> Cabecera, IEnumerable<TRFN> vector, string oper, TRFN terminoIndepe) : base(Cabecera, vector, terminoIndepe)
        {
            Operator = oper;
        }

        public FuzzyConstraint(string nombre, IDictionary<string, TRFN> cuerpoVector, string oper, TRFN termindepe) : base(nombre, cuerpoVector, termindepe)
        {
            Operator = oper;
        }

        public FuzzyConstraint(string nombre, IEnumerable<string> Cabecera, IEnumerable<TRFN> vector, string oper, TRFN terminoIndepe) : base(nombre, Cabecera, vector, terminoIndepe)
        {
            Operator = oper;
        }
        #endregion

        #region Constructors - Only independent term fuzzy.
        public FuzzyConstraint(IDictionary<string, double> cuerpoVector, string oper, TRFN termindepe) : base(cuerpoVector, termindepe)
        {
            Operator = oper;
        }

        public FuzzyConstraint(IEnumerable<string> Cabecera, IEnumerable<double> vector, string oper, TRFN terminoIndepe) : base(Cabecera, vector, terminoIndepe)
        {
            Operator = oper;
        }

        public FuzzyConstraint(string nombre, IDictionary<string, double> cuerpoVector, string oper, TRFN termindepe) : base(nombre, cuerpoVector, termindepe)
        {
            Operator = oper;
        }

        public FuzzyConstraint(string nombre, IEnumerable<string> Cabecera, IEnumerable<double> vector, string oper, TRFN terminoIndepe) : base(nombre, Cabecera, vector, terminoIndepe)
        {
            Operator = oper;
        }
        #endregion
    }
}
