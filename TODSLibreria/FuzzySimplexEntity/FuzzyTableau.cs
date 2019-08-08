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
        public IDictionary<string, TRFN> RHS { get { return FuzzyStandardConstraint.Select(c => c.Name).Zip(FuzzyStandardConstraint.Select(c => c.IndependentTerm), (n, t) => new { n, t }).ToDictionary(x => x.n, x => x.t); } }
        public VectorEquation RColumn { get { return new VectorEquation("R", RHS.Select(f => f.Key), RHS.Select(f => f.Value.U + f.Value.L), 0); } }
        public bool NotSolution { get { return FuzzyStandardConstraint != null ? FuzzyStandardConstraint.Any(c => (c.FuzzyNums != null ? (c.FuzzyNums.Any(n => n.L < 0 || n.U < 0)):(c.Numbers.Any(n => n < 0)))) : StandardConstraint.Any(c => c.CuerpoNum.Any(n => n < 0)); } }

        public FuzzyTableau(IEnumerable<VectorEquation> standardConstraint, FuzzyObjectiveFunction fo)
        {
            this.StandardConstraint = standardConstraint;
            this.FuzzyZRow = fo;
        }

        public FuzzyTableau(IEnumerable<FuzzyVectorEquation> standardConstraint, FuzzyObjectiveFunction fo)
        {
            this.FuzzyStandardConstraint = standardConstraint;
            this.FuzzyZRow = fo;
        }
    }
}
