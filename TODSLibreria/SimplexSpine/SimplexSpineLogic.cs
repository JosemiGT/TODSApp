using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODSLibreria.FuzzySimplexEntity;
using TODSLibreria.FuzzySimplexService;
using TODSLibreria.SimplexEntity;
using TODSLibreria.SimplexService;

namespace TODSLibreria.SimplexSpine
{
    public class SimplexSpineLogic
    {
        private string Path { get; set; }
        private ServicioTraza Trace { get; set; }

        public SimplexSpineLogic(string path)
        {
            string pathParent = Directory.GetParent(path).ToString();
            this.Trace = new ServicioTraza(pathParent + Constantes.ResultadoTxt + DateTime.Now.ToShortDateString().Replace("\\", "").Replace("/","") + Constantes.ExtensionTxt, new Config());
            this.Path = path;
        }

        public bool EjecutarBasicSimplex(string nombreHojaProblema)
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
                Trace.TrazaEcuacionVectorialVertical(tabla.FuncionObjetivo);
            }

            return siCorrecto;
        }

        public bool ExecuteFuzzyPrimalSimplex(string sheetName)
        {
            bool isCorrect = false;
            ConectorDatosApp conector = new ConectorDatosApp();
            FuzzyPrimalSimplexService service = new FuzzyPrimalSimplexService();
            InitialFuzzyBasicSolution initial = new InitialFuzzyBasicSolution();
            KeyValuePair<string, double> minVar = new KeyValuePair<string, double>();
            KeyValuePair<string, double> pivot = new KeyValuePair<string, double>();

            if (!string.IsNullOrWhiteSpace(sheetName) && conector.GetFuzzyDataSimplex(Path,sheetName, out FuzzyTableau tableau) && initial.Check(ref tableau))
            {

                while (!service.CheckEnd(tableau)) 
                {
                    service.Pivoting(ref tableau, out minVar, out pivot);
                    service.ReduceColumns(ref tableau, pivot, minVar.Key);
                }

                if(tableau != null && tableau.isSolution)
                {
                    Trace.TrazaTextoConFecha(Constantes.TextoSiSolucion);
                    Trace.TrazaSolution(service.GetSolution(tableau));
                    isCorrect = true;
                }
            }
            else { Trace.TrazaTextoConFecha(Constantes.TextoNoSolucion); }

            return isCorrect;
        }

    }
}
