using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace TODSLibreria.ODatosExcel
{
    public class UsoExcel
    {
        #region Propiedades
        //Excel.Application ExcelApp = new Excel.Application();
        private Excel.Application ExcelApp { get { return new Excel.Application(); } }
        private Excel.Workbook LibroExcel { get; set; }
        //private Excel.Worksheet HojaExcel { get; set; }

        public bool SiProcesoCorrecto { get; set; }
        public string TextoError { get; set; }

        public string RutaArchivo { get; set; }
        public string NombreHoja { get; set; }
        public int IndiceHoja { get; set; }

        public Dictionary<int, string> Hojas { get; set; }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="path">Path</param>
        /// <param name="nameSheet">Nombre de hoja.</param>
        public UsoExcel(string path)
        {

            if (ExcelApp == null)
            {
                SiProcesoCorrecto = false;
                TextoError = "No está instalado excel en el sistema";
            }
            else
            {
                SiProcesoCorrecto = true;
                TextoError = string.Empty;
            }

            if (!string.IsNullOrEmpty(path))
            {
                try
                {
                    RutaArchivo = path;

                    LibroExcel = ExcelApp.Workbooks.Open(RutaArchivo);
                    Hojas = ObtenerLibroYHojasDelLibro(LibroExcel);

                }
                catch (Exception e)
                {
                    CerrarLibroExcel();
                    SiProcesoCorrecto = false;
                    TextoError = e.Message;
                }

            }
            else
            {
                SiProcesoCorrecto = false;
                TextoError = "Archivo o hoja seleccionada no existe.";
            }



        }

        #endregion

        #region Métodos

        public void CerrarLibroExcel()
        {
            LibroExcel.Save();
            LibroExcel.Close();
        }

        public bool ObtenerDimensionesHoja(string nombreHoja, out int numFila, out int numColum)
        {
            bool siCorrecto = false;
            numFila = 0;
            numColum = 0;

            if (!string.IsNullOrEmpty(nombreHoja) && ComprobarSiExisteHoja(nombreHoja, out int indice))
            {
                siCorrecto = ObtenerDimensionesHoja(indice, out numFila, out numColum);
            }

            return siCorrecto;
        }

        public bool ObtenerDimensionesHoja(int indiceHoja, out int contadorFila, out int contadorColum)
        {
            bool siTerminaColum = false;
            bool siTerminaFila = false;

            contadorFila = -1;
            contadorColum = -1;

            if (indiceHoja > 0)
            {
                Excel.Worksheet hojaActual = LibroExcel.Worksheets[indiceHoja];

                contadorFila = 1;
                contadorColum = 1;

                while (!siTerminaColum)
                {
                    if (hojaActual.Cells[1, contadorColum].Value2 != null)
                    {
                        contadorColum++;
                    }
                    else
                    {
                        siTerminaColum = true;
                    }
                }

                while (!siTerminaFila)
                {
                    if (hojaActual.Cells[contadorFila, 1].Value2 != null)
                    {
                        contadorFila++;
                    }
                    else
                    {
                        siTerminaFila = true;
                    }
                }

            }

            return siTerminaColum && siTerminaFila;
        }

        public string[,] ObtenerDatosHoja(string nombreHoja)
        {

            bool hojaEncontrada = ComprobarSiExisteHoja(nombreHoja, out int indice);

            return ObtenerDatosHoja(indice);
        }

        public string[,] ObtenerDatosHoja(int indiceHoja)
        {
            string[,] datosHoja = null;

            if (indiceHoja > 0)
            {
                Excel.Worksheet hojaActual = LibroExcel.Worksheets[indiceHoja];

                bool siDimensiones = ObtenerDimensionesHoja(indiceHoja, out int filaNumero, out int columnaNumero);

                if (siDimensiones && columnaNumero > 0 && filaNumero > 0)
                {

                    Excel.Range rango = (Excel.Range)hojaActual.Cells.Range[hojaActual.Cells[1, 1], hojaActual.Cells[filaNumero, columnaNumero]];
                    object[,] resultado = rango.Value2;
                    datosHoja = new string[filaNumero - 1, columnaNumero - 1];

                    int contadorFila = 1;

                    while (contadorFila < filaNumero)
                    {
                        int contadorColum = 1;

                        while (contadorColum < columnaNumero)
                        {
                            if (resultado[contadorFila, contadorColum] != null)
                            {
                                datosHoja[contadorFila - 1, contadorColum - 1] = resultado[contadorFila, contadorColum].ToString();
                            }

                            contadorColum++;
                        }

                        contadorFila++;
                    }


                }

            }


            return datosHoja;
        }

        public bool ComprobarSiExisteHoja(string nombreHoja, out int indiceHoja)
        {
            bool siExiste = false;
            indiceHoja = 0;

            if (!string.IsNullOrEmpty(nombreHoja))
            {
                indiceHoja = 1;

                while (!siExiste && indiceHoja < Hojas.Count + 1)
                {

                    if (Hojas[indiceHoja] != null && Hojas[indiceHoja] == nombreHoja) { siExiste = true; }
                    else { indiceHoja++; }
                }

                if (!siExiste) { indiceHoja = 0; }

            }


            return siExiste;
        }

        public void EscribirDatosHoja(string[,] datos, string nombreHoja)
        {
            if (datos != null && datos.Length > 0 && !string.IsNullOrEmpty(nombreHoja))
            {
                bool siExisteHoja = ComprobarSiExisteHoja(nombreHoja, out int indiceHoja);
                Excel.Worksheet hojaActual = null;

                if (!siExisteHoja)
                {
                    hojaActual = LibroExcel.Worksheets.Add();
                    hojaActual.Name = nombreHoja;
                    Hojas = ObtenerLibroYHojasDelLibro(LibroExcel);
                }
                else
                {
                    hojaActual = LibroExcel.Worksheets[indiceHoja];
                }

                int numeroFilas = datos.GetLength(0);
                int numeroColumnas = datos.GetLength(1);

                Excel.Range rango = (Excel.Range)hojaActual.Range[hojaActual.Cells[1, 1], hojaActual.Cells[numeroFilas, numeroColumnas]];

                rango.Value2 = datos;

                //for(int i = 0; i < numeroFilas; i++)
                //{
                //    for(int j = 0; j < numeroColumnas; j++)
                //    {
                //        hojaActual.Cells[i + 1, j + 1] = datos[i, j];
                //    }
                //}

                LibroExcel.Save();
            }
        }

        public Dictionary<int, string> ObtenerLibroYHojasDelLibro(Excel.Workbook _libroExcel)
        {
            Dictionary<int, string> hojas = new Dictionary<int, string>();

            int contador = 1;

            if (_libroExcel.Worksheets.Count > 0)
            {

                while (contador < _libroExcel.Worksheets.Count + 1)
                {
                    Excel.Worksheet hojaActual = _libroExcel.Worksheets[contador];

                    int indice = hojaActual.Index;
                    string nombre = hojaActual.Name;

                    if (!string.IsNullOrEmpty(nombre))
                    {
                        hojas.Add(indice, nombre);
                    }

                    contador++;
                }

            }

            return hojas;
        }

        #endregion

    }
}
