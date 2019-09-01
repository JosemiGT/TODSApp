using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODSLibreria.FuzzySimplexService;

namespace TODSLibreria.SimplexEntity
{
    public class VectorEquation
    {
        public string Nombre { get; set; }
        public IDictionary<string, double> CuerpoVector { get; set; }
        public IEnumerable<string> NombresVariables { get { return CuerpoVector.Select(r => r.Key); } }
        public IEnumerable<double> CuerpoNum { get { return CuerpoVector.Select(r => r.Value); } }
        public double TerminoIndependiente { get; set; }
        private DataManagement dataManagement { get { return new DataManagement(); } }

        public VectorEquation()
        {

        }

        public VectorEquation(IDictionary<string, double> cuerpoVector, double termindepe)
        {
            CuerpoVector = dataManagement.OrderDictionaryByVariable(cuerpoVector);
            TerminoIndependiente = termindepe;
        }

        public VectorEquation(IEnumerable<string> Cabecera, IEnumerable<double> vector, double terminoIndepe)
        {
            CuerpoVector = dataManagement.OrderDictionaryByVariable(Cabecera.Zip(vector, (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v));
            TerminoIndependiente = terminoIndepe;
        }

        public VectorEquation(string nombre, IDictionary<string, double> cuerpoVector, double termindepe)
        {
            Nombre = nombre;
            CuerpoVector = dataManagement.OrderDictionaryByVariable(cuerpoVector);
            TerminoIndependiente = termindepe;
        }

        public VectorEquation(string nombre, IEnumerable<string> Cabecera, IEnumerable<double> vector, double terminoIndepe)
        {
            Nombre = nombre;
            CuerpoVector = dataManagement.OrderDictionaryByVariable(Cabecera.Zip(vector, (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v));
            TerminoIndependiente = terminoIndepe;
        }
    }
}
