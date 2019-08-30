using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODSLibreria.FuzzyEntity
{
    public class FuzzyParameter
    {
        public string Name { get; set; }
        public TRFN Value { get; set; }

        public FuzzyParameter(string name, TRFN value)
        {
            this.Name = name;
            this.Value = value;
        }

        public FuzzyParameter(string name, double n1, double n2, double n3, double n4)
        {
            this.Name = name;

            if( n1 < n2 && n2 < n3 && n3 < n4) { this.Value = new TRFN(Constantes.NDType.NumType, n1, n2, n3, n4); }
            else { this.Value = new TRFN(Constantes.NDType.AlfaBetaType, n1, n2, n3, n4); }
        }
    }
}
