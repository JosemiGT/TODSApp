using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODSLibreria.SimplexEntity
{
    public class Restriccion
    {
        public VariableLista NombresVariables { get; set; }
        public IEnumerable<double> CuerpoRestriccion { get; set; }
        public string Operador { get; set; }
        public double TerminoIndependiente { get; set; }
    }
}
