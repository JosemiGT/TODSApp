using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODSLibreria.SimplexEntity;

namespace TODSLibreria.SimplexService
{
    public class SimplexTService
    {
        public IEnumerable<StandardConstraint> EstandarizarRestricciones (IEnumerable<Constraint> restriccions)
        {
            List <StandardConstraint> resultado = new List<StandardConstraint>();

            if(restriccions != null && restriccions.Count() > 0)
            {
                List <StandardConstraint> restriccionEstandarizadas = new List<StandardConstraint>();
                int iteracion = 0;

                foreach(Constraint r in restriccions)
                {
                    StandardConstraint re = new StandardConstraint
                    {
                        CuerpoVector = r.CuerpoVector,
                        VariableHolgura = string.Format("S{0}", iteracion + 1),   
                        TerminoIndependiente = r.TerminoIndependiente
                    };

                    if (r.Operador == "<=") re.ValorVariableHolgura = 1;
                    else if (r.Operador == ">=") re.ValorVariableHolgura = -1;

                    iteracion++;
                    resultado.Add(re);
                }            
            }
            return resultado;
        }

        public IEnumerable<StandardConstraint> EstandarizarVector (IEnumerable<StandardConstraint> restriccions)
        {
            List<StandardConstraint> resultado = restriccions.ToList();

            if(restriccions != null && restriccions.Count() > 0)
            {
                foreach(StandardConstraint re in restriccions)
                {
                    foreach(StandardConstraint result in resultado)
                    {
                        if (re.VariableHolgura == result.VariableHolgura) result.CuerpoVector.Add(re.VariableHolgura, re.ValorVariableHolgura);
                        else result.CuerpoVector.Add(re.VariableHolgura, 0);
                    }
                }
            }

            return resultado;
        }

        public IEnumerable<VectorEquation> StandardizeConstraints(IEnumerable<Constraint> constraintList)
        {
            List<VectorEquation> standardConstraints = new List<VectorEquation>();

            if (constraintList != null && constraintList.Count() > 0)
            {
                int indice = 1;
                List<string> standardHeader = new List<string>();

                standardHeader = constraintList.Select(x => x.NombresVariables).FirstOrDefault().ToList();

                foreach (Constraint c in constraintList)
                {
                    standardHeader.Add(string.Format("S{0}", indice.ToString()));
                    indice++;
                }

                foreach (Constraint c in constraintList)
                {
                    Dictionary<string, double> values = new Dictionary<string, double>();

                    foreach (string header in standardHeader)
                    {
                        if (c.CuerpoVector.Any(cv => cv.Key == header)) { values.Add(header, c.CuerpoVector.Where(cv => cv.Key == header).FirstOrDefault().Value); }
                        else if (c.Nombre == header) { values.Add(header, (c.Operador == Constantes.MenorIgual) ? 1 : (c.Operador == Constantes.MayorIgual) ? -1 : 0); }
                        else { values.Add(header, 0); }
                    }

                    standardConstraints.Add(new VectorEquation(c.Nombre, values, c.TerminoIndependiente));
                }

            }

            return standardConstraints;
        }

        public bool EstandarizarFuncionObjetivo(IEnumerable<StandardConstraint> restricciones, ref ObjectiveFunction fo)
        {
            bool siCorrecto = false;

            if(restricciones != null && restricciones.Count() > 0 && fo != null && fo.CuerpoVector != null)
            {
                Dictionary<string, double> valoresFO = new Dictionary<string, double>(fo.CuerpoVector);

                foreach (KeyValuePair<string,double> cv in valoresFO)
                {
                    fo.CuerpoVector[cv.Key] = -cv.Value;
                }

                foreach(StandardConstraint r in restricciones)
                {
                    fo.CuerpoVector.Add(r.VariableHolgura, 0);
                }

                siCorrecto = true;
            }

            return siCorrecto;
        }

        public bool PivotarTSimplex (ref Tableau tabla, out KeyValuePair<string, double> variableMinima, out KeyValuePair<string, double> pivote)
        {
            bool siCorrecto = false;
            variableMinima = new KeyValuePair<string, double>();
            pivote = new KeyValuePair<string, double>();

            if (tabla != null)
            {
                foreach (KeyValuePair<string,double> kv in tabla.FuncionObjetivo.CuerpoVector)
                {
                    if (tabla.FuncionObjetivo.SiMaximizar && kv.Value < variableMinima.Value) variableMinima = kv;
                }

                pivote = ObtenerPivote(variableMinima, ref tabla);
                siCorrecto = true;
            }
            return siCorrecto;
        }

        public bool ReducirColumnas(ref Tableau tabla, KeyValuePair<string, double> pivote, string variableMinima)
        {
            bool siCorrecto = false;

            if(tabla != null && !string.IsNullOrEmpty(pivote.Key) && !string.IsNullOrEmpty(variableMinima))
            {

                OperacionesVectoriales op = new OperacionesVectoriales();
                List<VectorEquation> resultado = new List<VectorEquation>();

                VectorEquation evreferencia = tabla.StandardConstraint.Where(r => r.Nombre == pivote.Key).FirstOrDefault();
                evreferencia = new VectorEquation(evreferencia.Nombre, evreferencia.NombresVariables, op.OperacionV1parametro(evreferencia.CuerpoNum, "/", pivote.Value), evreferencia.TerminoIndependiente / pivote.Value);

                foreach (VectorEquation ev in tabla.StandardConstraint)
               {
                    if(ev.Nombre == pivote.Key)
                    {
                        resultado.Add(evreferencia);                      
                    }
                    else if(ev.Nombre != pivote.Key)
                    {
                        double pivoteev = ev.CuerpoVector.Where(r => r.Key == variableMinima).FirstOrDefault().Value;
                        resultado.Add(new VectorEquation(ev.Nombre, ev.NombresVariables, op.OperacionV1parametroV2(ev.CuerpoNum, "-", pivoteev, evreferencia.CuerpoNum), op.OperacionV1parametroV2(ev.TerminoIndependiente, Constantes.Resta, pivoteev, evreferencia.TerminoIndependiente)));
                    }

                }

                double pivotefo = tabla.FuncionObjetivo.CuerpoVector.Where(r => r.Key == variableMinima).FirstOrDefault().Value;
                ObjectiveFunction fo = new ObjectiveFunction(tabla.FuncionObjetivo.NombresVariables, op.OperacionV1parametroV2(tabla.FuncionObjetivo.CuerpoNum, "-", pivotefo, evreferencia.CuerpoNum), op.OperacionV1parametroV2(tabla.FuncionObjetivo.TerminoIndependiente, Constantes.Resta, pivotefo, evreferencia.TerminoIndependiente), tabla.FuncionObjetivo.SiMaximizar);

                tabla.FuncionObjetivo = fo;
                tabla.StandardConstraint = resultado;
                siCorrecto = ActualizarBaseTabla(ref tabla, evreferencia.Nombre, new KeyValuePair<string, double>(variableMinima,evreferencia.TerminoIndependiente));

            }

            return siCorrecto;
        }
        
        public bool ComprobarSiFinalizaSimplex(ObjectiveFunction fo)
        {
            bool siFinaliza = false;

            if(fo != null)
            {
                siFinaliza = !fo.CuerpoNum.Any(n => n < 0) && fo.TerminoIndependiente > 0;
            }

            return siFinaliza;

        }

        private IEnumerable<string> ObtenerVariablesDeHolgura(int numRestricciones)
        {
            List<string> variablesHolgura = new List<string>();

            if(numRestricciones > 0)
            {

                for(int i = 0; i < numRestricciones; i++)
                {
                    variablesHolgura.Add(string.Format("S{0}", i + 1));
                }

            }

            return variablesHolgura;
        }

        private KeyValuePair<string, double> ObtenerPivote(KeyValuePair<string,double> variableMinima, ref Tableau tabla)
        {

            double valorCompareIteracion = new double();
            string restriccionS = string.Empty;

            if (tabla.FuncionObjetivo.SiMaximizar) valorCompareIteracion = double.MaxValue;
            else if (!tabla.FuncionObjetivo.SiMaximizar) valorCompareIteracion = double.MinValue;

            foreach (VectorEquation ev in tabla.StandardConstraint)
            {
                double iteracionN = ev.CuerpoVector.Where(v => v.Key == variableMinima.Key).FirstOrDefault().Value;
                string iteracionS = !string.IsNullOrEmpty(ev.Nombre) ? ev.Nombre : string.Empty;
                if (tabla.FuncionObjetivo.SiMaximizar && (ev.TerminoIndependiente / iteracionN) < valorCompareIteracion) { valorCompareIteracion = iteracionN; restriccionS = iteracionS; }
                else if (!tabla.FuncionObjetivo.SiMaximizar && (ev.TerminoIndependiente / iteracionN) > valorCompareIteracion) { valorCompareIteracion = iteracionN; restriccionS = iteracionS; }
            }

            return new KeyValuePair<string, double>(restriccionS,valorCompareIteracion);
        }

        private bool ActualizarBaseTabla (ref Tableau tabla, string nombreEcuacion, KeyValuePair<string,double> nuevoElementoBase)
        {
            bool siCorrecto = false;

            if(tabla != null && !string.IsNullOrEmpty(nuevoElementoBase.Key))
            {
                tabla.Base[nombreEcuacion] = nuevoElementoBase;
                siCorrecto = true;
            }

            return siCorrecto;
        }
    }
}
