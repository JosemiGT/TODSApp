using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODSLibreria.FuzzyEntity;

namespace TODSLibreria.FuzzySimplexEntity
{
    public class FuzzySimplexSolution
    {
        public IDictionary<string,TRFN> VarValue { get; set; }
        public TRFN OptimalSolution { get; set; }

        public FuzzySimplexSolution(IDictionary<string,TRFN> varValue, TRFN solution)
        {
            this.VarValue = varValue;
            this.OptimalSolution = solution;
        }
    }
}
