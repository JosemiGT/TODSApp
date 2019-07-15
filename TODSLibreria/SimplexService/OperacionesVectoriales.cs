using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODSLibreria.SimplexEntity;

namespace TODSLibreria.SimplexService
{
    public class OperacionesVectoriales
    {
        public IEnumerable<double> OperacionV1maspivoteV2(IEnumerable<double> r1, string operacion, double valorPivote, IEnumerable<double> r2)
        {
            if (r1.Count() == r2.Count())
                switch (operacion)
                {
                    case "+": return r1.Zip(r2, (x, y) => x + (valorPivote * y));
                    case "-": return r1.Zip(r2, (x, y) => x - (valorPivote * y));
                    case "*": return r1.Zip(r2, (x, y) => x * (valorPivote * y));
                    case "/": return r1.Zip(r2, (x, y) => x / (valorPivote * y));
                    default: return new List<double>();
                }
            else return new List<double>();
        }
            
        
    }
}
