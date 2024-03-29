﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODSLibreria.FuzzyEntity;
using TODSLibreria.FuzzySimplexEntity;
using TODSLibreria.SimplexEntity;

namespace TODSLibreria.SimplexSpine
{
    public class ServicioTraza
    {
        private const string Titulo = "Informe de resultados";
        private const string TextoInicial = "Resolución del problema";
        private const string TextoInicialConNombre = "Resolución del problema: {0}";

        private string Path { get; set; }
        private Config _config { get; set; }

        public ServicioTraza(string path)
        {
            Path = path;

            StreamWriter mytxt = File.AppendText(path);

            DateTime fechaActual = new DateTime();
            fechaActual = DateTime.Now;
            string strDate = Convert.ToDateTime(fechaActual).ToString("F");

            mytxt.WriteLine(Titulo);
            mytxt.WriteLine("");
            mytxt.WriteLine(TextoInicial);
            mytxt.WriteLine("");
            mytxt.WriteLine("Se inicia el proceso - {0}", strDate);
            mytxt.WriteLine("------------------------------------");
            mytxt.WriteLine("");
            mytxt.Close();
        }

        public ServicioTraza(string path, Config config)
        {
            Path = path;
            _config = config;
            _config.ResultPath = path;
            _config.WriteConfig();
            StreamWriter mytxt = File.AppendText(path);

            DateTime fechaActual = new DateTime();
            fechaActual = DateTime.Now;
            string strDate = Convert.ToDateTime(fechaActual).ToString("F");

            mytxt.WriteLine(Constantes.Separador);
            mytxt.WriteLine("");
            mytxt.WriteLine(Titulo);
            mytxt.WriteLine("");
            mytxt.WriteLine(string.Format(TextoInicialConNombre,_config.ProblemName));
            mytxt.WriteLine("");
            mytxt.WriteLine(string.Format("Parámetros de configuración: "));
            mytxt.WriteLine("");
            mytxt.WriteLine(string.Format("Tipos de números: {0} - Solver emplado: {1} ", _config.NumberType.ToString(), _config.Solver.ToString()));
            if(_config.AnyFuzzyParameter) mytxt.WriteLine(string.Format("Función objetivo con parámetros difusos en pestaña: {0}", _config.FuzzyParameterName));
            mytxt.WriteLine(string.Format("Tipos de fuente de datos: {0}", _config.DataType.ToString()));
            mytxt.WriteLine("");
            mytxt.WriteLine("Se inicia el proceso - {0}", strDate);
            mytxt.WriteLine(Constantes.Separador);
            mytxt.WriteLine("");
            mytxt.Close();
        }

        public void TrazaTexto(string texto)
        {
            if (!string.IsNullOrEmpty(texto))
            {
                StreamWriter mytxt = File.AppendText(Path);

                mytxt.WriteLine(texto);
                mytxt.Close();
            }

        }

        public void TrazaTextoConFecha(string texto)
        {
            if (!string.IsNullOrEmpty(texto))
            {
                StreamWriter mytxt = File.AppendText(Path);

                DateTime fechaActual = new DateTime();
                fechaActual = DateTime.Now;
                string strDate = Convert.ToDateTime(fechaActual).ToString("F");

                mytxt.WriteLine(strDate + " : " + texto);
                mytxt.WriteLine("");
                mytxt.Close();
            }

        }

        public void TrazaLista(IEnumerable<string> lista)
        {
            if (lista != null && lista.Count() > 0)
            {
                StreamWriter mytxt = File.AppendText(Path);

                foreach (string variable in lista)
                {
                    if (!string.IsNullOrEmpty(variable)) { mytxt.Write(variable); mytxt.Write(" "); }
                }

                mytxt.WriteLine("");

                mytxt.Close();

            }
        }

        public void TrazaLista(IEnumerable<double> lista)
        {
            if (lista != null && lista.Count() > 0)
            {
                StreamWriter mytxt = File.AppendText(Path);

                foreach (double variable in lista)
                {
                    mytxt.Write(variable.ToString()); mytxt.Write(" "); 
                }

                mytxt.WriteLine("");

                mytxt.Close();

            }
        }

        public void TrazaEcuacionVectorialVertical(VectorEquation ev)
        {
            if (ev != null && ev.CuerpoVector.Count() > 0)
            {
                StreamWriter mytxt = File.AppendText(Path);

                mytxt.WriteLine("");

                foreach (KeyValuePair<string,double> valor in ev.CuerpoVector)
                {
                    mytxt.WriteLine("{0} --> {1}", valor.Key, valor.Value.ToString());
                }

                mytxt.WriteLine("");
                mytxt.WriteLine("Termino Independiente: {0}",ev.TerminoIndependiente.ToString());
                mytxt.WriteLine("");
                mytxt.Close();

            }
        }



        public void TrazaSolution(FuzzySimplexSolution solution)
        {
            if(solution != null && solution.VarValue.Count() > 0 && solution.OptimalSolution != null)
            {

                StreamWriter mytxt = File.AppendText(Path);
                mytxt.WriteLine(Constantes.Separador);
                mytxt.WriteLine("");
                mytxt.WriteLine("###-Resultado del problema:-###");
                mytxt.WriteLine("");

                foreach(KeyValuePair<string, TRFN> var in solution.VarValue)
                {
                    mytxt.WriteLine("{0} ==> [{1}; {2}; {3}; {4}]",var.Key, var.Value.L.ToString(), var.Value.U.ToString(), var.Value.Alfa.ToString(), var.Value.Beta.ToString());
                }

                mytxt.WriteLine("Valor Óptimo (Z) ==> [{0}; {1}; {2}; {3}]", solution.OptimalSolution.L.ToString(), solution.OptimalSolution.U.ToString(), solution.OptimalSolution.Alfa.ToString(), solution.OptimalSolution.Beta.ToString());
                mytxt.WriteLine("");
                mytxt.WriteLine(Constantes.Separador);

                mytxt.Close();

            }
        }

    }
}
