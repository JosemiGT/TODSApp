using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODSLibreria.FuzzyEntity;
using TODSLibreria.SimplexEntity;

namespace TODSLibreria.FuzzySimplexEntity
{
    public class FuzzyTableau
    {
        public VectorEquation ZRow { get { return new VectorEquation("Z", FuzzyZRow.Header, FuzzyZRow.FuzzyNums.Select(f => f.U + f.L), 0); } }
        public FuzzyObjectiveFunction FuzzyZRow { get; set; }
        public IEnumerable<VectorEquation> StandardConstraint { get; set; }
        public IEnumerable<FuzzyVectorEquation> FuzzyStandardConstraint { get; set; }
        public IDictionary<string, KeyValuePair<string, TRFN>> RHS { get; set; }
        public VectorEquation RColumn { get { return new VectorEquation("Z", FuzzyZRow.Header, RHS.Select(f => f.Value).Select(f => f.Value.U + f.Value.L), 0); } }

        public FuzzyTableau(IEnumerable<VectorEquation> standardConstraint, FuzzyObjectiveFunction fo)
        {
            this.StandardConstraint = standardConstraint;
            this.FuzzyZRow = fo;
        }

    }
}
