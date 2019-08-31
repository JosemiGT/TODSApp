using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODSLibreria.FuzzySimplexEntity;

namespace TODSLibreria.FuzzySimplexService
{
    public class InitialFuzzyBasicSolution
    {

        public bool Check(ref FuzzyTableau tableau)
        {
            FuzzyTableau initialTableau = null;
            FuzzyPrimalSimplexService service = new FuzzyPrimalSimplexService();

            if(tableau.FuzzyZRow != null && tableau.FuzzyStandardConstraint.Count() > 0 && tableau.FuzzyZRow.FuzzyVector.Any(v => v.Key.Contains("A")))
            {
                FuzzyObjectiveFunction initialProblemFO = new FuzzyObjectiveFunction(tableau.FuzzyZRow.FuzzyVector.Where(v => v.Key.Contains("A")).ToDictionary(x => x.Key, x => x.Value), new FuzzyEntity.TRFN(0), false);
                initialTableau = new FuzzyTableau(tableau.FuzzyStandardConstraint, initialProblemFO);

                while (!service.CheckEnd(initialTableau))
                {
                    service.Pivoting(ref initialTableau, out KeyValuePair<string, double> minvar, out KeyValuePair<string, double> pivot);
                    service.ReduceColumns(ref initialTableau, pivot, minvar.Key);
                }
            }

            if(initialTableau.FuzzyZRow.IndependentTerm == Constantes.fuzzyZero)
            {
                initialTableau = new FuzzyTableau(initialTableau.StandardConstraint, tableau.FuzzyZRow);

                //TODO: Falta reducir columnas para pruebas.
            }

            return (!tableau.FuzzyZRow.FuzzyVector.Any(v => v.Key.Contains("A")) || (initialTableau != null && initialTableau.isSolution && initialTableau.FuzzyZRow.IndependentTerm == Constantes.fuzzyZero));
        }
    }
}
