using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODSLibreria.ODatosExcel;
using TODSLibreria.SimplexEntity;
using TODSLibreria.SimplexService;

namespace TODSLibreria.SimplexSpine
{
    public class ConectorDatosApp
    {
        public bool ExtraerDatosSimplex(string path, string NombreHoja, out TablaSimplex tabla)
        {
            bool siCorrecto = false;
            tabla = null;
            List<string> cabeceraFila = new List<string>();
            List<string> cabeceraColumna = new List<string>();

            if (!string.IsNullOrWhiteSpace(path) && !string.IsNullOrWhiteSpace(NombreHoja))
            {
                UsoExcel helperExcel = new UsoExcel(path);
                SimplexTService stService = new SimplexTService();

                if (helperExcel.SiProcesoCorrecto && helperExcel.ComprobarSiExisteHoja(NombreHoja, out int indiceHoja) &&
                    helperExcel.ObtenerDimensionesHoja(indiceHoja, out int countFila, out int countCol))
                {
                    string[,] datosH = helperExcel.ObtenerDatosHoja(NombreHoja);
                    List<Restriccion> restricciones = ObtenerEcuaciones(datosH, countFila, countCol, out List<string> cabecera, out FuncionObjetivo funcionObjetivo);
                    List<RestriccionEstandarizada> restriccionesEstand = stService.EstandarizarRestricciones(restricciones).ToList();
                    restriccionesEstand = stService.EstandarizarVector(restriccionesEstand).ToList();
                    if(stService.EstandarizarFuncionObjetivo(restriccionesEstand, ref funcionObjetivo)) { tabla = new TablaSimplex(funcionObjetivo, restriccionesEstand); siCorrecto = true; }
                }
            }

            return siCorrecto;
        }

        public string[,] SepararCabecera(string[,] datos, int numFila, int numCol, out List<string> cabeceraFilas, out List<string> cabeceraColumnas)
        {

            string[,] resultado = new string[numFila - 1, numCol - 1];
            cabeceraFilas = new List<string>();
            cabeceraColumnas = new List<string>();

            if (datos != null)
            {
                if (!Decimal.TryParse(datos[0, 0], out decimal num))
                {
                    for (int i = 1; i < numFila; i++)
                    {
                        cabeceraFilas.Add(datos[i, 0]);
                    }

                    for (int i = 1; i < numCol; i++)
                    {
                        cabeceraColumnas.Add(datos[0, i]);
                    }

                    for (int i = 0; i < numFila - 1; i++)
                    {
                        for (int j = 0; j < numCol - 1; j++)
                        {
                            resultado[i, j] = datos[i + 1, j + 1];
                        }
                    }

                }
            }

            return resultado;
        }

        public List<Restriccion> ObtenerEcuaciones(string[,] datos, int numFila, int numCol, out List<string> cabeceraFilas, out FuncionObjetivo funcionObjetivo)
        {
            List<Restriccion> ecuaciones = new List<Restriccion>();
            cabeceraFilas = new List<string>();
            funcionObjetivo = null;

            if (datos != null && !Decimal.TryParse(datos[0, 0], out decimal num))
            {
                for(int j = 0; j < numCol; j++)
                {
                    bool siPasaOperador = false;
                    bool siMax = false;
                    string nombreEV = string.Empty;
                    string operador = string.Empty;
                    List<double> valoresEV = new List<double>();
                    double terminoIndepe = Double.NaN;

                    if(j == 0)
                    {
                        for (int i = 1; i < numFila; i++)
                        {
                            cabeceraFilas.Add(datos[i, 0]);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < numFila; i++)
                        {
                            double numA = Double.NaN;
                            if (i == 0) { nombreEV = datos[i, j]; }
                            else if (Double.TryParse(datos[i, j], out numA) && !siPasaOperador) { valoresEV.Add(numA); }
                            else if (!Double.TryParse(datos[i, j], out numA) && !siPasaOperador) { operador = datos[i, j]; siPasaOperador = true; }
                            else if (Double.TryParse(datos[i, j], out numA) && siPasaOperador) { terminoIndepe = numA; }
                            else if (!Double.TryParse(datos[i, j], out numA) && siPasaOperador) { if (datos[i, j] == Constantes.Maximizar) siMax = true; }
                        }

                        if (operador != Constantes.IgualQue) { ecuaciones.Add(new Restriccion(nombreEV, cabeceraFilas, valoresEV, operador, terminoIndepe)); }
                        else if (operador == Constantes.IgualQue) { funcionObjetivo = new FuncionObjetivo(cabeceraFilas, valoresEV, siMax); }
                    }
                }
            }

            return ecuaciones;
        }
    }
}
