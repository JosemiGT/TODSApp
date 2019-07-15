using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODSLibreria.SimplexEntity
{
    public class FuncionObjetivo
    {
        public VariableLista NombreVariables { get; set; }
        public IEnumerable<double> ValorVariables { get; set; }
        public bool SiMaximizar { get; set; }
    }
}
