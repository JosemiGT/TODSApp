using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODSLibreria
{
    public class OperacionesNumericas
    {
        public double ValorAbsoluto (double num)
        {
            return (num >= 0) ? num : -num;
        }

        public double Media (double num1, double num2)
        {
            return (num1 + num2) / 2;
        }
    }
}
