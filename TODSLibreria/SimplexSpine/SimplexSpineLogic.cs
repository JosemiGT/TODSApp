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
            this.Trace = new ServicioTraza(pathParent + Constantes.ResultadoTxt + Constantes.ExtensionTxt);
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
                Trace.TrazaEcuacionVectorial(tabla.FuncionObjetivo);
            }

            return siCorrecto;
        }

        public bool ExecuteFuzzyPrimalSimplex(string sheetName)
        {
            bool isCorrect = false;
            ConectorDatosApp conector = new ConectorDatosApp();
            FuzzyPrimalSimplexService service = new FuzzyPrimalSimplexService();
            KeyValuePair<string, double> minVar = new KeyValuePair<string, double>();
            KeyValuePair<string, double> pivot = new KeyValuePair<string, double>();

            //TODO: Necesario solución inicial con el método de los dos fases para verificar que el problema tiene solución.
            //--> Revisar en artículo de fuzzy la última parte, hacer solución z = 0;

            if (!string.IsNullOrWhiteSpace(sheetName) && conector.GetFuzzyDataSimplex(Path,sheetName, out FuzzyTableau tableau))
            {
                service.Pivoting(ref tableau, out minVar, out pivot);
                service.ReduceColumns(ref tableau, pivot, minVar.Key);

                while (!service.CheckEnd(tableau)) //TODO: Revisar condiciones de parada --> z Positivo (max) o Negativo (min) && es variable no básica --> Se para.
                {
                    service.Pivoting(ref tableau, out minVar, out pivot);
                    service.ReduceColumns(ref tableau, pivot, minVar.Key);
                }

                //TODO: La solución a pintar, no sería el z fuzzy tableau, si no que sería la base que se forme con la columna RFuzzy (terminos independiente), por lo que es necesario cambiar la interpretación de resultado.
                Trace.TrazaTextoConFecha(Constantes.TextoSiSolucion);
                Trace.TrazaTexto(Constantes.TextoValor);
                Trace.TrazaEcuacionVectorial(tableau.ZRow);
                isCorrect = true;

            }

            return isCorrect;
        }

        //TODO: Hacer problema Dual para análisis de sensibilidades. (Execute FuzzyDualSimplex(); --> ¿Método padre para primal y dual y no tener que leer los datos dos veces?
    }
}
