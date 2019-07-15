using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODSLibreria.SimplexEntity
{
    public class TablaSimplex
    {
        public FuncionObjetivo FuncionObjetivo { get; set; }
        public IEnumerable<Restriccion> Restricciones { get; set; }

        public TablaSimplex(FuncionObjetivo fo, IEnumerable<Restriccion> restriccions)
        {
            this.FuncionObjetivo = fo;
            this.Restricciones = restriccions;
        }

    }
}
