using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODSLibreria.SimplexEntity;

namespace TODSLibreria.FuzzySimplexService
{
    public class FuzzyPrimalSimplexService
    {
        public IEnumerable<VectorEquation> StandardizeConstraints(IEnumerable<Constraint> constraintList)
        {
            List<VectorEquation> standardConstraints = new List<VectorEquation>();

            if(constraintList != null && constraintList.Count() > 0)
            {
                int indice = 1;
                List<string> standardHeader = new List<string>();

                standardHeader = constraintList.Select(x => x.NombresVariables).FirstOrDefault().ToList();

                foreach(Constraint c in constraintList)
                {
                    standardConstraints.Add(new VectorEquation(string.Format("S{0}", indice.ToString()), standardHeader, c.CuerpoNum, c.TerminoIndependiente));
                }

            }

            return standardConstraints;
        }
    }
}
