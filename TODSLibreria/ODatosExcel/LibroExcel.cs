using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace TODSLibreria.ODatosExcel
{
    public class LibroExcel
    {
        #region Propiedades

        private Excel.Application ExcelApp { get { return new Excel.Application(); } }
        public Excel.Workbook Libro { get; set; }
        public string Ruta { get; set; }
        public Dictionary<int, String> IndiceHojas { get; }
        public Excel.Worksheets Hojas { get; set; }
        public bool SiCorrecto { get; set; }
        public string TextoError { get; set; }

        #endregion

        #region Constructores.

        public LibroExcel(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                try
                {
                    Libro = ExcelApp.Workbooks.Open(path);
                }
                catch (Exception e)
                {
                    SiCorrecto = false;
                    TextoError = e.Message;
                }

                if (Libro != null)
                {
                    IndiceHojas = ObtenerHojas();
                }

                SiCorrecto = true;
            }
        }

        #endregion

        #region Métodos Públicos.

        public string[,] ObtenerDatosHojaPorNombre(string nombreHoja)
        {
            string[,] resultado = null;

            if (!string.IsNullOrEmpty(nombreHoja) && SiCorrecto)
            {

                int contador = 1;
                bool siEncontrado = false;

                while (contador < Libro.Worksheets.Count + 1 && !siEncontrado)
                {
                    if (IndiceHojas[contador] == nombreHoja) { siEncontrado = true; }

                    if (!siEncontrado) { contador++; }

                }

                if (siEncontrado)
                {
                    Excel.Worksheet hojaActual = Libro.Worksheets[contador];

                    Excel.Range RangoDatos = hojaActual.Cells;

                    resultado = RangoDatos.Value2;

                }
            }

            return resultado;
        }

        #endregion

        #region Métodos Privados.

        private Dictionary<int, string> ObtenerHojas()
        {
            Dictionary<int, string> indiceNombre = new Dictionary<int, string>();

            if (Libro != null)
            {
                int contador = 1;

                while (contador < Libro.Worksheets.Count + 1)
                {
                    Excel.Worksheet hojaActual = Libro.Worksheets[contador];

                    indiceNombre.Add(hojaActual.Index, hojaActual.Name);
                    contador++;
                }

            }

            return indiceNombre;
        }

        #endregion
    }
}
