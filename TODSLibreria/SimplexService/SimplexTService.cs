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

        public bool PivotarTSimplex (ref TablaSimplex tabla, out KeyValuePair<string, double> variableMinima, out KeyValuePair<string, double> pivote)
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

        public bool ReducirColumnas(ref TablaSimplex tabla, KeyValuePair<string, double> pivote, string variableMinima)
        {
            bool siCorrecto = false;

            if(tabla != null && !string.IsNullOrEmpty(pivote.Key) && !string.IsNullOrEmpty(variableMinima))
            {

                OperacionesVectoriales op = new OperacionesVectoriales();
                List<EcuacionVectorial> resultado = new List<EcuacionVectorial>();

                EcuacionVectorial evreferencia = tabla.Restricciones.Where(r => r.Nombre == pivote.Key).FirstOrDefault();
                evreferencia = new EcuacionVectorial(evreferencia.Nombre, evreferencia.NombresVariables, op.OperacionV1parametroV2(evreferencia.CuerpoNum, "/", pivote.Value, evreferencia.CuerpoNum), op.OperacionV1parametroV2(evreferencia.TerminoIndependiente, "/", pivote.Value, evreferencia.TerminoIndependiente));

                foreach (EcuacionVectorial ev in tabla.Restricciones)
               {
                    if(ev.Nombre == pivote.Key)
                    {
                        resultado.Add(evreferencia);                      
                    }
                    else if(ev.Nombre != pivote.Key)
                    {
                        resultado.Add(new EcuacionVectorial(ev.Nombre, ev.NombresVariables, op.OperacionV1parametroV2(ev.CuerpoNum, "-", pivote.Value, evreferencia.CuerpoNum), op.OperacionV1parametroV2(ev.TerminoIndependiente, "-", pivote.Value, evreferencia.TerminoIndependiente)));
                    }

                }

                FuncionObjetivo fo = new FuncionObjetivo(tabla.FuncionObjetivo.NombresVariables, op.OperacionV1parametroV2(tabla.FuncionObjetivo.CuerpoNum, "-", pivote.Value, evreferencia.CuerpoNum), tabla.FuncionObjetivo.SiMaximizar);

                tabla.FuncionObjetivo = fo;
                tabla.Restricciones = resultado;
                siCorrecto = true;

            }

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
