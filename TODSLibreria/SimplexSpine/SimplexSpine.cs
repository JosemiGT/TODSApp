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
            KeyValuePair<string, double> variableMinima = new KeyValuePair<string, double>();
            KeyValuePair<string, double> pivote = new KeyValuePair<string, double>();

            if (conector.ExtraerDatosSimplex(Path, nombreHojaProblema, out Tableau tabla))
            {
                service.PivotarTSimplex(ref tabla, out variableMinima, out pivote);
                service.ReducirColumnas(ref tabla, pivote, variableMinima.Key);

                while (!service.ComprobarSiFinalizaSimplex(tabla.FuncionObjetivo))
                {
                    service.PivotarTSimplex(ref tabla, out variableMinima, out pivote);
                    service.ReducirColumnas(ref tabla, pivote, variableMinima.Key);
                }

                Trace.TrazaTextoConFecha(Constantes.TextoSiSolucion);
                Trace.TrazaTexto(Constantes.TextoValor);
                Trace.TrazaEcuacionVectorial(tabla.FuncionObjetivo);
            }

            return siCorrecto;
        }
    }
}
