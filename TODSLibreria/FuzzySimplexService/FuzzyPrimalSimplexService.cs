using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODSLibreria.FuzzyEntity;
using TODSLibreria.FuzzySimplexEntity;
using TODSLibreria.SimplexEntity;

namespace TODSLibreria.FuzzySimplexService
{
    public class FuzzyPrimalSimplexService
    {
        public IEnumerable<FuzzyVectorEquation> StandardizeConstraints(IEnumerable<FuzzyConstraint> constraintList)
        {
            List<FuzzyVectorEquation> standardConstraints = new List<FuzzyVectorEquation>();

            if(constraintList != null && constraintList.Count() > 0)
            {
                int indice = 1;
                List<string> standardHeader = new List<string>();

                standardHeader = constraintList.Select(x => x.Header).FirstOrDefault().ToList();

                foreach(FuzzyConstraint c in constraintList)
                {
                    standardHeader.Add(string.Format("S{0}", indice.ToString()));
                    indice++;
                }

                foreach(FuzzyConstraint c in constraintList)
                {
                    Dictionary<string, double> values = new Dictionary<string, double>();

                    foreach(string header in standardHeader)
                    {
                        if(c.Vector.Any(cv => cv.Key == header)) { values.Add(header, c.Vector.Where(cv => cv.Key == header).FirstOrDefault().Value); }
                        else if(c.Name == header) { values.Add(header, (c.Operator == Constantes.MenorIgual) ? 1 : (c.Operator == Constantes.MayorIgual) ? - 1 : 0); }
                        else { values.Add(header, 0); }
                    }

                    standardConstraints.Add(new FuzzyVectorEquation(c.Name, values, c.IndependentTerm));
                }

            }

            return standardConstraints;
        }

        public bool StandardizeObjectiveFunction(IEnumerable<FuzzyVectorEquation> constraint, ref FuzzyObjectiveFunction fo)
        {
            TRFNOperation op = new TRFNOperation();
            bool isCorrect = false;

            if (constraint != null && constraint.Count() > 0 && fo != null && fo.FuzzyVector != null)
            {
                Dictionary<string, TRFN> valoresFO = new Dictionary<string, TRFN>(fo.FuzzyVector);

                foreach (KeyValuePair<string, TRFN> cv in valoresFO)
                {
                    fo.FuzzyVector[cv.Key] = op.MakeNegative(cv.Value);
                }

                foreach (FuzzyVectorEquation r in constraint)
                {
                    fo.FuzzyVector.Add(r.Name, new TRFN(0));
                }

                isCorrect = true;
            }

            return isCorrect;
        }

        public bool Pivoting(ref FuzzyTableau tableau, out KeyValuePair<string, double> minVar, out KeyValuePair<string, double> pivot)
        {
            bool isCorrect = false;
            minVar = new KeyValuePair<string, double>();
            pivot = new KeyValuePair<string, double>();

            VectorEquation Zrow = tableau.ZRow;

            if (tableau != null)
            {
                foreach (KeyValuePair<string, double> kv in tableau.ZRow.CuerpoVector)
                {
                    //if (tableau.Ob.SiMaximizar && kv.Value < variableMinima.Value) variableMinima = kv;
                }

                //pivot = ObtenerPivote(variableMinima, ref tableau);
                isCorrect = true;
            }
            return isCorrect;
        }
    }
}
