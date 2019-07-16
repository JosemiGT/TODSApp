using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODSLibreria.SimplexEntity
{
    public class FuncionObjetivo : EcuacionVectorial
    {
        public bool SiMaximizar { get; set; }

        public FuncionObjetivo(IDictionary<string, double> vector, bool siMax) : base (vector, 0)
        {
            SiMaximizar = siMax;
        }

        public FuncionObjetivo(IEnumerable<string> Cabecera, IEnumerable<double> vector, bool siMax) : base(Cabecera, vector, 0)
        {
            SiMaximizar = siMax;
        }

    }
}
