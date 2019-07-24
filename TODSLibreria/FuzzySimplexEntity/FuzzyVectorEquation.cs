using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODSLibreria.FuzzyEntity;

namespace TODSLibreria.FuzzySimplexEntity
{
    public class FuzzyVectorEquation
    {
        public string Name { get; set; }
        public IDictionary<string, TRFN> Vector { get; set; }
        public IEnumerable<string> Header { get { return Vector.Select(r => r.Key); } }
        public IEnumerable<TRFN> FuzzyNums { get { return Vector.Select(r => r.Value); } }
        public TRFN IndependentTerm { get; set; }

        public FuzzyVectorEquation(IDictionary<string, TRFN> cuerpoVector, TRFN termindepe)
        {
            Vector = cuerpoVector;
            IndependentTerm = termindepe;
        }

        public FuzzyVectorEquation(IEnumerable<string> header, IEnumerable<TRFN> vector, TRFN terminoIndepe)
        {
            Vector = header.Zip(vector, (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v);
            IndependentTerm = terminoIndepe;
        }

        public FuzzyVectorEquation(string name, IDictionary<string, TRFN> vector, TRFN termindepe)
        {
            Name = name;
            Vector = vector;
            IndependentTerm = termindepe;
        }

        public FuzzyVectorEquation(string name, IEnumerable<string> header, IEnumerable<TRFN> vector, TRFN terminoIndepe)
        {
            Name = name;
            Vector = header.Zip(vector, (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v);
            IndependentTerm = terminoIndepe;
        }
    }
}
