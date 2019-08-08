using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODSLibreria.FuzzyEntity;
using TODSLibreria.FuzzySimplexEntity;
using TODSLibreria.FuzzySimplexService;
using TODSLibreria.ODatosExcel;
using TODSLibreria.SimplexEntity;
using TODSLibreria.SimplexService;

namespace TODSLibreria.SimplexSpine
{
    public class ConectorDatosApp
    {
        public bool ExtraerDatosSimplex(string path, string NombreHoja, out Tableau tabla)
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
                    List<Constraint> restricciones = ObtenerEcuaciones(datosH, countFila - 1, countCol - 1, out List<string> cabecera, out ObjectiveFunction funcionObjetivo);
                    List<StandardConstraint> restriccionesEstand = stService.EstandarizarRestricciones(restricciones).ToList();
                    restriccionesEstand = stService.EstandarizarVector(restriccionesEstand).ToList();
                    if(stService.EstandarizarFuncionObjetivo(restriccionesEstand, ref funcionObjetivo)) { tabla = new Tableau(funcionObjetivo, restriccionesEstand); siCorrecto = true; }
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

        public List<Constraint> ObtenerEcuaciones(string[,] datos, int numFila, int numCol, out List<string> cabeceraFilas, out ObjectiveFunction funcionObjetivo)
        {
            List<Constraint> ecuaciones = new List<Constraint>();
            cabeceraFilas = new List<string>();
            funcionObjetivo = null;

            if (datos != null && !Decimal.TryParse(datos[0, 0], out decimal num))
            {
                for(int i = 0; i < numFila; i++)
                {
                    bool siPasaOperador = false;
                    bool siMax = false;
                    string nombreEV = string.Empty;
                    string operador = string.Empty;
                    List<double> valoresEV = new List<double>();
                    double terminoIndepe = Double.NaN;

                    if(i == 0)
                    {
                        for (int j = 1; j < numCol; j++)
                        {
                            cabeceraFilas.Add(datos[i, j]);
                        }
                    }
                    else
                    {
                        for (int j = 0; j < numCol; j++)
                        {
                            double numA = Double.NaN;
                            if (j == 0) { nombreEV = datos[i, j]; }
                            else if (Double.TryParse(datos[i, j], out numA) && !siPasaOperador) { valoresEV.Add(numA); }
                            else if (!Double.TryParse(datos[i, j], out numA) && !siPasaOperador) { operador = datos[i, j]; siPasaOperador = true; }
                            else if (Double.TryParse(datos[i, j], out numA) && siPasaOperador) { terminoIndepe = numA; }
                            else if (!Double.TryParse(datos[i, j], out numA) && siPasaOperador) { if (datos[i, j] == Constantes.Maximizar) siMax = true; }
                        }

                        if (operador != Constantes.IgualQue) { ecuaciones.Add(new Constraint(nombreEV, cabeceraFilas, valoresEV, operador, terminoIndepe)); }
                        else if (operador == Constantes.IgualQue) { funcionObjetivo = new ObjectiveFunction(cabeceraFilas, valoresEV, siMax); }
                    }
                }
            }

            return ecuaciones;
        }

        public bool GetFuzzyDataSimplex(string path, string NombreHoja, out FuzzyTableau tableau)
        {
            bool isCorrect = false;
            tableau = null;
            List<string> cabeceraFila = new List<string>();
            List<string> cabeceraColumna = new List<string>();

            if(!string.IsNullOrWhiteSpace(path) && !string.IsNullOrWhiteSpace(NombreHoja))
            {
                UsoExcel helperExcel = new UsoExcel(path);
                FuzzyPrimalSimplexService fpsService = new FuzzyPrimalSimplexService();

                if (helperExcel.SiProcesoCorrecto && helperExcel.ComprobarSiExisteHoja(NombreHoja, out int indiceHoja) &&
                    helperExcel.ObtenerDimensionesHoja(indiceHoja, out int countFila, out int countCol))
                {
                    string[,] data = helperExcel.ObtenerDatosHoja(NombreHoja);
                    if(GetEquations(data, countFila - 1, countCol - 1, out List<string> header, out List<FuzzyConstraint> fuzzyEquations, out FuzzyObjectiveFunction fuzzyObjectiveFunction, out List<Constraint> equations, out ObjectiveFunction objectiveFunction) && fuzzyEquations.Count > 0)
                    {
                        List<FuzzyVectorEquation> constraints = fpsService.StandardizeConstraints(fuzzyEquations).ToList();
                        if(fpsService.StandardizeObjectiveFunction(fuzzyEquations, ref fuzzyObjectiveFunction)) tableau = new FuzzyTableau(constraints, fuzzyObjectiveFunction); isCorrect = true;
                    }
                }
            }

            return isCorrect;
        }

        public bool GetEquations(string[,] data, int numRow, int numCol, out List<string> header, out List<FuzzyConstraint> fuzzyEquations, out FuzzyObjectiveFunction fuzzyObjectiveFunction, out List<Constraint> equations, out ObjectiveFunction objectiveFunction)
        {
            equations = new List<Constraint>();
            fuzzyEquations = new List<FuzzyConstraint>();
            header = new List<string>();
            fuzzyObjectiveFunction = null;
            objectiveFunction = null;

            if (data != null && !Decimal.TryParse(data[0, 0], out decimal num))
            {
                for (int i = 0; i < numRow; i++)
                {
                    bool ifPassOperator = false;
                    bool isMax = false;
                    string nameEV = string.Empty;
                    string op = string.Empty;
                    List<double> valuesN = new List<double>();
                    List<TRFN> valuesFuzzy = new List<TRFN>();
                    double terminoIndepe = Double.NaN;
                    TRFN fuzzyIndependtTerm = null;

                    if (i == 0)
                    {
                        for (int j = 1; j < numCol; j++)
                        {
                            header.Add(data[i, j]);
                        }
                    }
                    else
                    {
                        for (int j = 0; j < numCol; j++)
                        {
                            double numA = Double.NaN;
                            TRFN numT = null;
                            if (j == 0) {
                                nameEV = data[i, j];
                            }
                            else if (Double.TryParse(data[i, j], out numA) && !ifPassOperator) { valuesN.Add(numA); }
                            else if (!Double.TryParse(data[i, j], out numA) && !GetFuzzyNumber(data[i, j], out numT) && !ifPassOperator) { op = data[i, j]; ifPassOperator = true; }
                            else if (Double.TryParse(data[i, j], out numA) && ifPassOperator) { terminoIndepe = numA; }
                            else if (!Double.TryParse(data[i, j], out numA) && !GetFuzzyNumber(data[i, j], out numT) && ifPassOperator) { if (data[i, j] == Constantes.Maximizar) isMax = true; }
                            else if (GetFuzzyNumber(data[i, j], out numT) && !ifPassOperator) { valuesFuzzy.Add(numT); }
                            else if (GetFuzzyNumber(data[i, j], out numT) && ifPassOperator) { fuzzyIndependtTerm = numT; }
                        }

                        if (op != Constantes.IgualQue && fuzzyIndependtTerm == null) { equations.Add(new Constraint(nameEV, header, valuesN, op, terminoIndepe)); }
                        if (op != Constantes.IgualQue && fuzzyIndependtTerm != null && valuesFuzzy.Count == 0) { fuzzyEquations.Add(new FuzzyConstraint(nameEV, header, valuesN, op, fuzzyIndependtTerm)); }
                        if (op != Constantes.IgualQue && fuzzyIndependtTerm != null && valuesFuzzy.Count > 0) { fuzzyEquations.Add(new FuzzyConstraint(nameEV, header, valuesFuzzy, op, fuzzyIndependtTerm)); }
                        else if (op == Constantes.IgualQue && valuesFuzzy.Count == 0) { objectiveFunction = new ObjectiveFunction(header, valuesN, isMax); }
                        else if (op == Constantes.IgualQue && valuesFuzzy.Count > 0) { fuzzyObjectiveFunction = new FuzzyObjectiveFunction(header, valuesFuzzy, new TRFN(0), isMax); }
                    }
                }
            }

            return ((header.Count > 0 && fuzzyEquations.Count > 0 && fuzzyObjectiveFunction != null) || (header.Count > 0 && equations.Count > 0 && objectiveFunction != null));
        }

        private bool GetFuzzyNumber(string data, out TRFN FuzzyNumber)
        {
            bool isCorrect = false;
            FuzzyNumber = null;
            string[] numbers = data.Split(Constantes.Separator);

            if (numbers.Length == 4 && double.TryParse(numbers[0], out double L) && double.TryParse(numbers[1], out double U) && double.TryParse(numbers[2], out double alfa) && double.TryParse(numbers[3], out double beta)) { FuzzyNumber = new TRFN(Constantes.NDType.AlfaBetaType, L, U, alfa, beta); isCorrect = true; }

            return isCorrect;
        }
    }
}
