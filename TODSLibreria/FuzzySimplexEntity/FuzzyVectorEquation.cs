using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODSLibreria.FuzzyEntity;
using TODSLibreria.FuzzySimplexService;

namespace TODSLibreria.FuzzySimplexEntity
{
    public class FuzzyVectorEquation
    {
        public string Name { get; set; }
        public IDictionary<string, double> Vector { get; set; }
        public IDictionary<string, TRFN> FuzzyVector { get; set; }
        public IEnumerable<string> Header { get { return  (Vector != null) ? Vector.Select(r => r.Key) : FuzzyVector.Select(r => r.Key); } }
        public IEnumerable<TRFN> FuzzyNums { get { return FuzzyVector?.Select(r => r.Value); } }
        public IEnumerable<double> Numbers { get { return Vector?.Select(r => r.Value); } }
        public TRFN IndependentTerm { get; set; }
        private DataManagement dataManagement { get { return new DataManagement(); } }

        #region Constructors - Full fuzzy vector equations.
        public FuzzyVectorEquation(IDictionary<string, TRFN> cuerpoVector, TRFN termindepe)
        {
            FuzzyVector = dataManagement.OrderDictionaryByVariable(cuerpoVector);
            IndependentTerm = termindepe;
        }

        public FuzzyVectorEquation(IEnumerable<string> header, IEnumerable<TRFN> vector, TRFN terminoIndepe)
        {
            FuzzyVector = dataManagement.OrderDictionaryByVariable(header.Zip(vector, (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v));
            IndependentTerm = terminoIndepe;
        }

        public FuzzyVectorEquation(string name, IDictionary<string, TRFN> vector, TRFN termindepe)
        {
            Name = name;
            FuzzyVector = dataManagement.OrderDictionaryByVariable(vector);
            IndependentTerm = termindepe;
        }

        public FuzzyVectorEquation(string name, IEnumerable<string> header, IEnumerable<TRFN> vector, TRFN terminoIndepe)
        {
            Name = name;
            FuzzyVector = dataManagement.OrderDictionaryByVariable(header.Zip(vector, (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v));
            IndependentTerm = terminoIndepe;
        }
        #endregion

        #region Constructors - Only independent term fuzzy.
        public FuzzyVectorEquation(IDictionary<string, double> cuerpoVector, TRFN termindepe)
        {
            Vector = dataManagement.OrderDictionaryByVariable(cuerpoVector);
            IndependentTerm = termindepe;
        }

        public FuzzyVectorEquation(IEnumerable<string> header, IEnumerable<double> vector, TRFN terminoIndepe)
        {
            Vector = dataManagement.OrderDictionaryByVariable(header.Zip(vector, (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v));
            IndependentTerm = terminoIndepe;
        }

        public FuzzyVectorEquation(string name, IDictionary<string, double> vector, TRFN termindepe)
        {
            Name = name;
            Vector = vector;
            IndependentTerm = termindepe;
        }

        public FuzzyVectorEquation(string name, IEnumerable<string> header, IEnumerable<double> vector, TRFN terminoIndepe)
        {
            Name = name;
            Vector = header.Zip(vector, (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v);
            Vector = dataManagement.OrderDictionaryByVariable(Vector);
            IndependentTerm = terminoIndepe;
        }
        #endregion
    }
}
