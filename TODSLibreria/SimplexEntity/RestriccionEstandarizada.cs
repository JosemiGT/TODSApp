using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODSLibreria.SimplexEntity
{
    public class RestriccionEstandarizada
    {
        public VariableLista ListaNombre { get; set; }
        public double TerminoIndependinte { get; set; }
        public string VariableHolgura { get; set; }
        public double ValorVariableHolgura { get; set; }
    }
}
