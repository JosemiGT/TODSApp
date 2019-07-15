using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODSLibreria.SimplexEntity
{
    public class VariableLista
    {
        public IEnumerable<string> Cabecera { get; set; }
        public IEnumerable<int> Indice { get; set; }


        private IEnumerable<int> ObtenerIndice(IEnumerable<string> cabecera)
        {
            List<int> resultado = new List<int>();

            if(cabecera != null && cabecera.Count() > 0)
            {
                int indice = 0;
                foreach(string variable in cabecera)
                {
                    resultado.Add(indice);
                    indice++;
                }
            }

            return resultado;
        }
    }
}
