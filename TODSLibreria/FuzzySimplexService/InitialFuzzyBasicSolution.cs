using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODSLibreria.FuzzyEntity;
using TODSLibreria.FuzzySimplexEntity;

namespace TODSLibreria.FuzzySimplexService
{
    public class InitialFuzzyBasicSolution
    {

        public bool Check(ref FuzzyTableau tableau)
        {
            bool isSolution = false;

            FuzzyTableau initialTableau = null;
            FuzzyPrimalSimplexService service = new FuzzyPrimalSimplexService();
            TRFNOperation fuzzyOperator = new TRFNOperation();
            DataManagement dataManagement = new DataManagement();

            if(tableau.FuzzyZRow != null && tableau.FuzzyStandardConstraint.Count() > 0 && tableau.FuzzyZRow.FuzzyVector.Any(v => v.Key.Contains("A")))
            {
                Dictionary<string, TRFN> newFO = new Dictionary<string, TRFN>();
                foreach (KeyValuePair<string, TRFN> varFO in tableau.FuzzyZRow.FuzzyVector)
                {
                    if (varFO.Key.Contains("A")) newFO.Add(varFO.Key, fuzzyOperator.MakeNegative(varFO.Value));
                    else newFO.Add(varFO.Key, new TRFN(0));
                }

                List<FuzzyVectorEquation> newConstraint = new List<FuzzyVectorEquation>();
                foreach (FuzzyVectorEquation eqItem in tableau.FuzzyStandardConstraint)
                {
                    if (eqItem.Name.Contains("e")) newConstraint.Add(new FuzzyVectorEquation(eqItem.Name.Replace("e", "A"), eqItem.Vector, eqItem.IndependentTerm));
                    else newConstraint.Add(eqItem);

                }

                FuzzyObjectiveFunction initialProblemFO = new FuzzyObjectiveFunction(tableau.FuzzyZRow.Name, dataManagement.OrderDictionaryByVariable(newFO), tableau.FuzzyZRow.IndependentTerm, false);
                initialTableau = new FuzzyTableau(newConstraint, ReduceArtificialVar(initialProblemFO, newConstraint));

                //Se reduce las variables artificiales de la función objetivo. --> Falta colocar bien la base para la reducción

                while (!service.CheckEnd(initialTableau))
                {
                    service.Pivoting(ref initialTableau, out KeyValuePair<string, double> minvar, out KeyValuePair<string, double> pivot);
                    service.ReduceColumns(ref initialTableau, pivot, minvar.Key);
                }
            }

            if(initialTableau != null && fuzzyOperator.IsZero(initialTableau.FuzzyZRow.IndependentTerm)) 
            {
                tableau = EliminateArtificialColum(new FuzzyTableau(initialTableau.FuzzyStandardConstraint, tableau.FuzzyZRow));
                isSolution = true;
            }

            return (!tableau.FuzzyZRow.FuzzyVector.Any(v => v.Key.Contains("A")) || isSolution);
        }

        public FuzzyObjectiveFunction ReduceArtificialVar(FuzzyObjectiveFunction foArtificial, IEnumerable<FuzzyVectorEquation> constraints)
        {
            FuzzyObjectiveFunction newFO = foArtificial;
            TRFN pivotefo = new TRFN(Constantes.NDType.AlfaBetaType,1,1,0,0);
            TRFNOperation fop = new TRFNOperation();

            if (foArtificial != null && foArtificial.FuzzyVector.Count() > 0)
            {

                foreach(string varName in foArtificial.Header)
                {
                    FuzzyVectorEquation vectorRef = null;

                    if (varName.Contains("A")) vectorRef = constraints.Where(c => c.Vector.Any(v => v.Key == varName && v.Value == 1)).FirstOrDefault();

                    if(vectorRef != null && vectorRef.Vector.Count() > 0) newFO = new FuzzyObjectiveFunction(foArtificial.Header, fop.AdditionFuzzyRows(newFO.FuzzyNums, fop.OperateFuzzyConstant(vectorRef.Numbers, Constantes.Multiplicacion, pivotefo)), fop.Addition(newFO.IndependentTerm, fop.Multiplication(pivotefo, vectorRef.IndependentTerm)), foArtificial.IsMax);
                }
            }

            return newFO;
        }

        public FuzzyTableau EliminateArtificialColum (FuzzyTableau tableau)
        {
            List<FuzzyVectorEquation> constraint = new List<FuzzyVectorEquation>();
            FuzzyObjectiveFunction fuzzyObjective = new FuzzyObjectiveFunction(tableau.FuzzyZRow.FuzzyVector.Where(v => !v.Key.Contains("A")).ToDictionary(x => x.Key, x => x.Value), tableau.FuzzyZRow.IndependentTerm, tableau.FuzzyZRow.IsMax);
            foreach(FuzzyVectorEquation equation in tableau.FuzzyStandardConstraint)
            {
                constraint.Add(new FuzzyVectorEquation(equation.Name, equation.Vector.Where(v => !v.Key.Contains("A")).ToDictionary(x => x.Key, x => x.Value), equation.IndependentTerm));
            }

            return new FuzzyTableau(constraint, fuzzyObjective);
        }
    }
}
