using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODSLibreria.SimplexEntity;
using TODSLibreria.SimplexService;

namespace TODSLibreria.SimplexSpine
{
    public class SimplexSpine
    {
        private string Path { get; set; }

        public SimplexSpine(string path)
        {
            string pathParent = Directory.GetParent(path).ToString();
            ServicioTraza trace = new ServicioTraza(pathParent + Constantes.ResultadoTxt + DateTime.Now.ToString());
            Path = path;
        }

        public bool Ejecutar(string nombreHojaProblema)
        {
            bool siCorrecto = false;
            ConectorDatosApp conector = new ConectorDatosApp();
            SimplexTService service = new SimplexTService();

            if(conector.ExtraerDatosSimplex(Path, nombreHojaProblema, out TablaSimplex tabla))
            {
                service.PivotarTSimplex(ref tabla, out KeyValuePair<string, double> variableMinima, out KeyValuePair<string, double> pivote);
                service.ReducirColumnas(ref tabla, pivote, variableMinima.Key);
            }

            return siCorrecto;
        }
    }
}
