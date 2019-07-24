using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODSLibreria
{
    public class Constantes
    {
        public const string ResultadoTxt = @"\Resultado_";
        public const string ExtensionTxt = ".txt";

        //Utilidades para lógicas
        public static readonly char[] Separadores = { ',', ';', '/' };
        public static readonly string[] Operadores = { "<", "<=", "=", ">=", ">=", };
        public const string Suma = "+";
        public const string Resta = "-";
        public const string Division = "/";
        public const string Multiplicacion = "*";
        public const string MenorIgual = "<=";
        public const string MenorQue = "<";
        public const string IgualQue = "=";
        public const string MayorIgual = ">=";
        public const string MayorQue = ">";
        public const string Maximizar = "Max";
        public const string Minimizar = "Min";
        public const string COferta = "Ofertas";
        public const string CDemanda = "Demandas";

        //Texto para resoluciones
        public const string TextoSiSolucion = "Se ha encontrado solución óptima.";
        public const string TextoVariablesProblemaMatricial = "Las variables del problema planteado (para filas y columnas): ";
        public const string TextoValorVariablesMatriciales = "El valor óptimo de las variables en su forma matricial: ";
        public const string TextoValor = "El valor óptimo de las variables: ";
        public const string TextoResultado = "El resultado de la función objetivo sería: ";

        public const string TextoNoSolucion = "No se ha encontrado solución al problema.";
        public const string TextoNoDatos = "El formato de los datos introducidos no es correcto.";

        public enum NDType { NumType, AlfaBetaType};
    }
}
