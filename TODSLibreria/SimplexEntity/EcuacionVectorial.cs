using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODSLibreria.SimplexEntity
{
    public class EcuacionVectorial
    {
        public IDictionary<string, double> CuerpoVector { get; set; }
        public IEnumerable<string> NombresVariables { get { return CuerpoVector.Select(r => r.Key); } }
        public IEnumerable<double> CuerpoNum { get { return CuerpoVector.Select(r => r.Value); } }
        public double TerminoIndependiente { get; set; }
    }
}
