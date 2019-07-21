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
        public IEnumerable<RestriccionEstandarizada> EstandarizarRestricciones (IEnumerable<Restriccion> restriccions)
        {
            List <RestriccionEstandarizada> resultado = new List<RestriccionEstandarizada>();

            if(restriccions != null && restriccions.Count() > 0)
            {
                List <RestriccionEstandarizada> restriccionEstandarizadas = new List<RestriccionEstandarizada>();
                int iteracion = 0;

                foreach(Restriccion r in restriccions)
                {
                    RestriccionEstandarizada re = new RestriccionEstandarizada
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

        public IEnumerable<RestriccionEstandarizada> EstandarizarVector (IEnumerable<RestriccionEstandarizada> restriccions)
        {
            List<RestriccionEstandarizada> resultado = restriccions.ToList();

            if(restriccions != null && restriccions.Count() > 0)
            {
                foreach(RestriccionEstandarizada re in restriccions)
                {
                    foreach(RestriccionEstandarizada result in resultado)
                    {
                        if (re.VariableHolgura == result.VariableHolgura) result.CuerpoVector.Add(re.VariableHolgura, re.ValorVariableHolgura);
                        else result.CuerpoVector.Add(re.VariableHolgura, 0);
                    }
                }
            }

            return resultado;
        }

        public bool EstandarizarFuncionObjetivo(IEnumerable<RestriccionEstandarizada> restricciones, ref FuncionObjetivo fo)
        {
            bool siCorrecto = false;

            if(restricciones != null && restricciones.Count() > 0 && fo != null && fo.CuerpoVector != null)
            {
                Dictionary<string, double> valoresFO = new Dictionary<string, double>(fo.CuerpoVector);

                foreach (KeyValuePair<string,double> cv in valoresFO)
                {
                    fo.CuerpoVector[cv.Key] = -cv.Value;
                }

                foreach(RestriccionEstandarizada r in restricciones)
                {
                    fo.CuerpoVector.Add(r.VariableHolgura, 0);
                }

                siCorrecto = true;
            }

            return siCorrecto;
        }

        public bool PivotarTSimplex (ref TablaSimplex tabla)
        {
            bool siCorrecto = false;

            if(tabla != null)
            {
                KeyValuePair<string, double> variableMinima = new KeyValuePair<string, double>();

                foreach (KeyValuePair<string,double> kv in tabla.FuncionObjetivo.CuerpoVector)
                {
                    if (tabla.FuncionObjetivo.SiMaximizar && kv.Value < variableMinima.Value) variableMinima = kv;
                }

                KeyValuePair<string, double> pivote = ObtenerPivote(variableMinima, ref tabla);
                
            }
            return siCorrecto;
        }

        public bool ReducirColumnas(ref TablaSimplex tabla, string pivote)
        {
            bool siCorrecto = false;

            return siCorrecto;
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

        private KeyValuePair<string, double> ObtenerPivote(KeyValuePair<string,double> variableMinima, ref TablaSimplex tabla)
        {

            double valorCompareIteracion = new double();
            string restriccionS = string.Empty;

            if (tabla.FuncionObjetivo.SiMaximizar) valorCompareIteracion = double.MaxValue;
            else if (!tabla.FuncionObjetivo.SiMaximizar) valorCompareIteracion = double.MinValue;

            foreach (EcuacionVectorial ev in tabla.Restricciones)
            {
                double iteracionN = ev.CuerpoVector.Where(v => v.Key == variableMinima.Key).FirstOrDefault().Value;
                string iteracionS = !string.IsNullOrEmpty(ev.Nombre) ? ev.Nombre : string.Empty;
                if (tabla.FuncionObjetivo.SiMaximizar && (ev.TerminoIndependiente / iteracionN) < valorCompareIteracion) { valorCompareIteracion = iteracionN; restriccionS = iteracionS; }
                else if (!tabla.FuncionObjetivo.SiMaximizar && (ev.TerminoIndependiente / iteracionN) > valorCompareIteracion) { valorCompareIteracion = iteracionN; restriccionS = iteracionS; }
            }

            return new KeyValuePair<string, double>(restriccionS,valorCompareIteracion);
        }
    }
}
