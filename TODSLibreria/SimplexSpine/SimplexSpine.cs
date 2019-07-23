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
        private ServicioTraza Trace { get; set; }

        public SimplexSpine(string path)
        {
            string pathParent = Directory.GetParent(path).ToString();
            this.Trace = new ServicioTraza(pathParent + Constantes.ResultadoTxt + Constantes.ExtensionTxt);
            this.Path = path;
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
                Trace.TrazaEcuacionVectorial(tabla.FuncionObjetivo);
            }

            return siCorrecto;
        }
    }
}
