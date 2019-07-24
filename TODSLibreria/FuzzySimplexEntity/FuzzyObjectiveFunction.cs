using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODSLibreria.FuzzyEntity;

namespace TODSLibreria.FuzzySimplexEntity
{
    public class FuzzyObjectiveFunction : FuzzyVectorEquation
    {
        public bool IsMax { get; set; }

        public FuzzyObjectiveFunction(IDictionary<string, TRFN> cuerpoVector, TRFN termindepe, bool ismax) : base(cuerpoVector, termindepe)
        {
            IsMax = ismax;
        }

        public FuzzyObjectiveFunction(IEnumerable<string> Cabecera, IEnumerable<TRFN> vector, TRFN terminoIndepe, bool ismax) : base(Cabecera, vector, terminoIndepe)
        {
            IsMax = ismax;
        }

        public FuzzyObjectiveFunction(string nombre, IDictionary<string, TRFN> cuerpoVector, TRFN termindepe, bool ismax) : base(nombre, cuerpoVector, termindepe)
        {
            IsMax = ismax;
        }

        public FuzzyObjectiveFunction(string nombre, IEnumerable<string> Cabecera, IEnumerable<TRFN> vector, TRFN terminoIndepe, bool ismax) : base(nombre, Cabecera, vector, terminoIndepe)
        {
            IsMax = ismax;
        }
    }
}
