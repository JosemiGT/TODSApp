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
    }
}
