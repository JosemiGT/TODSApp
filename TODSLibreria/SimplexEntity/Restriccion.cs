using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODSLibreria.SimplexEntity
{
    public class Restriccion : VectorVariable
    {
        public string Operador { get; set; }
        public double TerminoIndependiente { get; set; }
    }
}
