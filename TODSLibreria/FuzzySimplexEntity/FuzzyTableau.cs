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
        public IEnumerable<string> Base { get; set; }
        public IDictionary<string, TRFN> RHS { get { return FuzzyStandardConstraint.Select(c => c.Name).Zip(FuzzyStandardConstraint.Select(c => c.IndependentTerm), (n, t) => new { n, t }).ToDictionary(x => x.n, x => x.t); } }
        public VectorEquation RColumn { get { return new VectorEquation("R", RHS.Select(f => f.Key), RHS.Select(f => f.Value.U + f.Value.L), 0); } }
        public bool NotSolution { get { return FuzzyStandardConstraint != null ? FuzzyStandardConstraint.Any(c => (c.FuzzyNums != null ? (c.FuzzyNums.Any(n => n.L < 0 || n.U < 0)):(c.Numbers.Any(n => n < 0)))) : StandardConstraint.Any(c => c.CuerpoNum.Any(n => n < 0)); } }

        public FuzzyTableau(IEnumerable<VectorEquation> standardConstraint, FuzzyObjectiveFunction fo)
        {
            this.StandardConstraint = standardConstraint;
            this.FuzzyZRow = fo;
            this.Base = GetInitialBase(this);
        }

        public FuzzyTableau(IEnumerable<FuzzyVectorEquation> standardConstraint, FuzzyObjectiveFunction fo)
        {
            this.FuzzyStandardConstraint = standardConstraint;
            this.FuzzyZRow = fo;
            this.Base = GetInitialBase(this);
        }

        public FuzzyTableau(IEnumerable<VectorEquation> standardConstraint, FuzzyObjectiveFunction fo, IEnumerable<string> _base)
        {
            this.StandardConstraint = standardConstraint;
            this.FuzzyZRow = fo;
            this.Base = _base;
        }

        public FuzzyTableau(IEnumerable<FuzzyVectorEquation> standardConstraint, FuzzyObjectiveFunction fo, IEnumerable<string> _base)
        {
            this.FuzzyStandardConstraint = standardConstraint;
            this.FuzzyZRow = fo;
            this.Base = _base;
        }

        private IEnumerable<string> GetInitialBase(FuzzyTableau tableau)
        {
            List<string> _base = new List<string>();
            if (tableau.FuzzyStandardConstraint != null && tableau.FuzzyStandardConstraint.Count() > 0) _base = tableau.FuzzyStandardConstraint.Select(x => x.Name).ToList();
            else if (tableau.StandardConstraint != null && tableau.StandardConstraint.Count() > 0) _base = tableau.StandardConstraint.Select(x => x.Nombre).ToList();
            return _base;
        }
    }
}
