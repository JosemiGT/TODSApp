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
                List<string> variablesHolgura = ObtenerVariablesDeHolgura(restriccions.Count()).ToList();
               // restriccionEstandarizadas.Add

                List<Restriccion> Rmenor = restriccions.Where(r => r.Operador == "<=").ToList();
                List<Restriccion> Rmayor = restriccions.Where(r => r.Operador == ">=").ToList();
             
            }

            return resultado;
        }

        public bool PivotarTSimplex (ref TablaSimplex tabla)
        {
            bool siCorrecto = false;

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
    }
}
