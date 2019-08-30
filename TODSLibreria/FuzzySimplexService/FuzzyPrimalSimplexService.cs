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
                    if (c.Operator == Constantes.MenorIgual) standardHeader.Add(string.Format("S{0}", indice.ToString()));
                    else if (c.Operator == Constantes.MayorIgual) standardHeader.Add(string.Format("e{0}", indice.ToString()));
                    indice++;
                }

                foreach(FuzzyConstraint c in constraintList)
                {
                    Dictionary<string, double> values = new Dictionary<string, double>();
                    int indexA = 1;
                    foreach(string header in standardHeader)
                    {

                        if(c.Vector.Any(cv => cv.Key == header)) { values.Add(header, c.Vector.Where(cv => cv.Key == header).FirstOrDefault().Value); }
                        else if(c.Name.Contains("S") && header == c.Name) { values.Add(header, 1); }
                        else if (c.Name.Contains("e") && header == c.Name) { values.Add(header, -1); values.Add(string.Format("A{0}", indexA.ToString()), 1); indexA++; }
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
                    if (!r.Name.Contains("e")) fo.FuzzyVector.Add(r.Name, new TRFN(0));
                    else if (r.Name.Contains("e") && r.Vector != null) fo.FuzzyVector.Add(r.Vector.Where(v => v.Key.Contains("A") && v.Value > 0).FirstOrDefault().Key, new TRFN(Constantes.NDType.AlfaBetaType, 1,1,0,0));
                }

                isCorrect = true;
            }

            return isCorrect;
        }

        public bool Pivoting(ref FuzzyTableau tableau, out KeyValuePair<string, double> refVar, out KeyValuePair<string, double> pivot)
        {
            bool isCorrect = false;
            refVar = new KeyValuePair<string, double>("", 0);
            pivot = new KeyValuePair<string, double>();

            VectorEquation Zrow = tableau.ZRow;

            if (tableau != null)
            {
                foreach (KeyValuePair<string, double> kv in tableau.ZRow.CuerpoVector)
                {
                    if (tableau.FuzzyZRow.IsMax && kv.Value < refVar.Value) refVar = kv;
                    else if (!tableau.FuzzyZRow.IsMax && kv.Value > refVar.Value) refVar = kv;
                }

                pivot = GetPivot(refVar, ref tableau);
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

                TRFN pivotefo = tableau.FuzzyZRow.FuzzyVector.Where(r => r.Key == minVar).FirstOrDefault().Value;
                FuzzyObjectiveFunction fo = new FuzzyObjectiveFunction(tableau.FuzzyZRow.Header,fop.ReduceFuzzyColumns(tableau.FuzzyZRow.FuzzyNums, fop.OperateFuzzyConstant(evreferencia.Numbers, Constantes.Multiplicacion, pivotefo)), fop.Addition(tableau.FuzzyZRow.IndependentTerm, fop.Multiplication(fop.MakeNegative(pivotefo),evreferencia.IndependentTerm )), tableau.FuzzyZRow.IsMax);

                tableau = new FuzzyTableau(resultado, fo, RefreshBase(tableau.Base, minVar, pivot.Key));

            }

            return siCorrecto;
        }

        private IEnumerable<string> RefreshBase(IEnumerable<string> oldBase, string inVar, string outVar)
        {
            List<string> newBase = oldBase.ToList();
            newBase.Add(inVar);
            return newBase.Where(b => !string.Equals(b, outVar));
        }

        public bool CheckEnd(FuzzyTableau tableau)
        {
            bool isEnd = false;

            if (tableau != null && tableau.FuzzyZRow != null)
            {
                foreach (string item in tableau.Base)
                {
                    if (tableau.FuzzyZRow.IsMax && tableau.ZRow.CuerpoVector.Where(v => v.Key == item).Select(v => v.Value).Min() > 0) isEnd = true;
                    else if (!tableau.FuzzyZRow.IsMax && tableau.ZRow.CuerpoVector.Where(v => v.Key == item).Select(v => v.Value).Max() < 0) isEnd = true;
                    else if (GetColum(item, tableau).Max() < 0) isEnd = true;
                }
            }
            return isEnd;
        }

        public List<double> GetColum(string var, FuzzyTableau tableau)
        {
            List<double> colum = new List<double>();

            if(tableau.StandardConstraint.Count() > 0)
            {
                foreach(VectorEquation constraint in tableau.StandardConstraint)
                {
                    colum.Add(constraint.CuerpoVector.Where(v => v.Key == var).FirstOrDefault().Value);
                }
            }

            return colum;
        }
    }
}
