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
        public IEnumerable<double> OperacionV1parametroV2(IEnumerable<double> r1, string operacion, double valorPivote, IEnumerable<double> r2)
        {

            List<double> pr2 = new List<double>(r2.Select(r => r * valorPivote).ToList());
            
            if (r1.Count() == r2.Count())
                switch (operacion)
                {
                    case Constantes.Suma: return r1.Zip(pr2, (x, y) => x + y).ToList();
                    case Constantes.Resta: return r1.Zip(pr2, (x, y) => x - y).ToList();
                    case Constantes.Multiplicacion: return r1.Zip(pr2, (x, y) => x * y).ToList();
                    case Constantes.Division: return r1.Zip(pr2, (x, y) => x / y).ToList();
                    default: return new List<double>();
                }
            else return new List<double>();
        }

        public double OperacionV1parametroV2(double r1, string operacion, double valorPivote, double r2)
        {
                switch (operacion)
                {
                    case Constantes.Suma: return r1 + (valorPivote * r2);
                    case Constantes.Resta: return r1 - (valorPivote * r2);
                    case Constantes.Multiplicacion: return r1 * (valorPivote * r2);
                    case Constantes.Division: return r1 / (valorPivote * r2);
                    default: return new double();
                }

        }

        public IEnumerable<double> OperacionV1parametro(IEnumerable<double> r1, string operacion, double valorPivote)
        {
            if (r1.Count() > 0 && !string.IsNullOrEmpty(operacion))
                switch (operacion)
                {
                    case Constantes.Suma: return r1.Select(r => r + valorPivote).ToList();
                    case Constantes.Resta: return r1.Select(r => r - valorPivote).ToList();
                    case Constantes.Multiplicacion: return r1.Select(r => r * valorPivote).ToList();
                    case Constantes.Division: return r1.Select(r => r / valorPivote).ToList();
                    default: return new List<double>();
                }
            else return new List<double>();
        }
    }
}
