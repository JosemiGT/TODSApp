using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODSLibreria.SimplexEntity
{
    public class RestriccionEstandarizada :EcuacionVectorial
    {
        public string VariableHolgura { get; set; }
        public double ValorVariableHolgura { get; set; }
    }
}
