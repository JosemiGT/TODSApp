using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODSLibreria.FuzzyEntity;
using TODSLibreria.FuzzySimplexEntity;
using TODSLibreria.SimplexEntity;
using TODSLibreria.SimplexService;

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
            minVar = new KeyValuePair<string, double>("", 0);
            pivot = new KeyValuePair<string, double>();

            VectorEquation Zrow = tableau.ZRow;

            if (tableau != null)
            {
                foreach (KeyValuePair<string, double> kv in tableau.ZRow.CuerpoVector)
                {
                    if (tableau.FuzzyZRow.IsMax && kv.Value < minVar.Value) minVar = kv;
                }

                pivot = GetPivot(minVar, ref tableau);
                isCorrect = true;
            }
            return isCorrect;
        }

        private KeyValuePair<string, double> GetPivot(KeyValuePair<string, double> variableMinima, ref FuzzyTableau tabla)
        {

            double valorCompareIteracion = new double();
            string restriccionS = string.Empty;
            double pivoteValor = double.NaN;

            if (tabla.FuzzyZRow.IsMax) valorCompareIteracion = double.MaxValue;
            else if (!tabla.FuzzyZRow.IsMax) valorCompareIteracion = double.MinValue;

            foreach (FuzzyVectorEquation ev in tabla.FuzzyStandardConstraint)
            {
                double iteracionN = ev.Vector.Where(v => v.Key == variableMinima.Key).FirstOrDefault().Value;
                string iteracionS = !string.IsNullOrEmpty(ev.Name) ? ev.Name : string.Empty;
                if (tabla.FuzzyZRow.IsMax && (tabla.RColumn.CuerpoVector.Where(v => v.Key == ev.Name).FirstOrDefault().Value / iteracionN) < valorCompareIteracion) { pivoteValor = iteracionN; restriccionS = iteracionS; valorCompareIteracion = (tabla.RColumn.CuerpoVector.Where(v => v.Key == ev.Name).FirstOrDefault().Value / iteracionN); }
                else if (!tabla.FuzzyZRow.IsMax && (tabla.RColumn.CuerpoVector.Where(v => v.Key == ev.Name).FirstOrDefault().Value / iteracionN) > valorCompareIteracion) { pivoteValor = iteracionN; restriccionS = iteracionS; valorCompareIteracion = (tabla.RColumn.CuerpoVector.Where(v => v.Key == ev.Name).FirstOrDefault().Value / iteracionN); }
            }

            return new KeyValuePair<string, double>(restriccionS, pivoteValor);
        }

        public bool ReduceColumns(ref FuzzyTableau tableau, KeyValuePair<string, double> pivot, string minVar)
        {
            bool siCorrecto = false;

            if (tableau != null && !string.IsNullOrEmpty(pivot.Key) && !string.IsNullOrEmpty(minVar))
            {

                OperacionesVectoriales op = new OperacionesVectoriales();
                TRFNOperation fop = new TRFNOperation();
                List<FuzzyVectorEquation> resultado = new List<FuzzyVectorEquation>();

                FuzzyVectorEquation evreferencia = tableau.FuzzyStandardConstraint.Where(r => r.Name == pivot.Key).FirstOrDefault();
                evreferencia = new FuzzyVectorEquation(evreferencia.Name, evreferencia.Header, op.OperacionV1parametro(evreferencia.Numbers, "/", pivot.Value), fop.OperateConstant(evreferencia.IndependentTerm,Constantes.Division, pivot.Value));

                foreach (FuzzyVectorEquation ev in tableau.FuzzyStandardConstraint)
                {
                    if (ev.Name == pivot.Key)
                    {
                        resultado.Add(evreferencia);
                    }
                    else if (ev.Name != pivot.Key)
                    {
                        double pivoteev = ev.Vector.Where(r => r.Key == minVar).FirstOrDefault().Value;
                        resultado.Add(new FuzzyVectorEquation(ev.Name, ev.Header, op.OperacionV1parametroV2(ev.Numbers, "-", pivoteev, evreferencia.Numbers), fop.Subtraction(ev.IndependentTerm, fop.OperateConstant(evreferencia.IndependentTerm,Constantes.Multiplicacion, pivoteev))));
                    }

                }

                double pivotefo = tableau.ZRow.CuerpoVector.Where(r => r.Key == minVar).FirstOrDefault().Value;
                FuzzyObjectiveFunction fo = new FuzzyObjectiveFunction(tableau.FuzzyZRow.Header, fop.Operate(tableau.FuzzyZRow.FuzzyNums, Constantes.Resta, fop.OperateConstant(evreferencia.Numbers, Constantes.Multiplicacion, pivotefo)), fop.Subtraction(tableau.FuzzyZRow.IndependentTerm, fop.OperateConstant(evreferencia.IndependentTerm, Constantes.Multiplicacion, pivotefo)), tableau.FuzzyZRow.IsMax);

                //tableau.FuncionObjetivo = fo;
                //tableau.Fu = resultado;
                //siCorrecto = ActualizarBaseTabla(ref tableau, evreferencia.Nombre, new KeyValuePair<string, double>(minVar, evreferencia.TerminoIndependiente));

                tableau = new FuzzyTableau(resultado, fo);

            }

            return siCorrecto;
        }

    }
}
