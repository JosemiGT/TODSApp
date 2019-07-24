using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODSLibreria.SimplexEntity
{
    public class ObjectiveFunction : VectorEquation
    {
        public bool SiMaximizar { get; set; }

        public ObjectiveFunction(IDictionary<string, double> vector, bool siMax) : base (vector, 0)
        {
            SiMaximizar = siMax;
        }

        public ObjectiveFunction(IEnumerable<string> Cabecera, IEnumerable<double> vector, bool siMax) : base(Cabecera, vector, 0)
        {
            SiMaximizar = siMax;
        }

        public ObjectiveFunction(IDictionary<string, double> vector, double terminoIndepe, bool siMax) : base(vector, terminoIndepe)
        {
            SiMaximizar = siMax;
        }

        public ObjectiveFunction(IEnumerable<string> Cabecera, IEnumerable<double> vector, double terminoIndepe, bool siMax) : base(Cabecera, vector, terminoIndepe)
        {
            SiMaximizar = siMax;
        }
    }
}
