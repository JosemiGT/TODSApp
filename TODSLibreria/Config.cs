using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODSLibreria
{
    public class Config
    {
        public const string IncorrectConfif = "Configuración incorrecta";
        public const string IncorrectConfifMessage = "No puede seleccionar un solver difuso para números reales o viceversa.";
        public const string CorrectConfif = "Cambios realizados";
        public const string CorrectConfifMessage = "Cambios de configuración realizados correctamente.";

        public const string dataMessageCheckOk = "Los datos introducidos tienen formato de pestañas adecuado.";
        public const string dataMessageCheckNoOk = "Error en la comprobación de datos, revise los datos introducidos.";
        public const string dataTittleCheck = "Comprobación de formato de datos";

        public const string NT = "NumberType";
        public const string DT = "DataType";
        public const string S = "Solver";
        public const string aFP = "AnyFuzzyParameter";
        public const string PN = "ProblemName";
        public const string FPN = "FuzzyParameterName";
        private const string fileName = "TODSconfig.txt";

        public enum ENumberType { Real, FuzzyTrap}
        public enum EDataType { XLS, CSV }
        public enum ESolver { BasicSimplex, FuzzyPrimalSimplex }

        public ENumberType? NumberType { get; set; }
        public EDataType? DataType { get; set; }
        public ESolver? Solver { get; set; }
        public bool AnyFuzzyParameter { get; set; }
        public string ProblemName { get; set; }
        public string FuzzyParameterName { get; set; }

        private string Path { get; set; }
        private StreamWriter configFile { get; set; }

        public Config()
        {
            this.Path = Directory.GetCurrentDirectory();
            this.Path += string.Format("/{0}", fileName);

            if (!ReadConfig()) WriteDefaultConfig();

        }

        public bool ReadConfig()
        {
            bool isRead = false;
            NumberType = null;
            DataType = null;

            if (File.Exists(Path))
            {
                using (StreamReader reader = new StreamReader(Path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        isRead = ReadParameter(line);
                    }
                }
            }

            return isRead;

        }

        public bool WriteConfig()
        {
            bool isWrite = false;

            try
            {
                File.Delete(Path);

                using (StreamWriter writer = new StreamWriter(Path))
                {
                    writer.WriteLine(string.Format(NT + " : {0}", NumberType.ToString()));
                    writer.WriteLine(string.Format(DT + " : {0}", DataType.ToString()));
                    writer.WriteLine(string.Format(S + " : {0}", Solver.ToString()));
                    writer.WriteLine(string.Format(aFP + ": {0}", AnyFuzzyParameter.ToString()));
                    if(!string.IsNullOrEmpty(ProblemName)) writer.WriteLine(string.Format(PN + " : {0}", ProblemName));
                    if (!string.IsNullOrEmpty(FuzzyParameterName)) writer.WriteLine(string.Format(FPN + " {0}", FuzzyParameterName));
                    isWrite = true;
                }
            }
            catch (Exception e)
            {
                isWrite = false;
            }

            return isWrite;
        }

        public bool WriteConfig(ENumberType? eNumber, EDataType? eData, ESolver? eSolver, bool anyParameterFuzzy, string problemName, string fuzzyParameterName)
        {
            bool isWrite = false;

            try
            {
                File.Delete(Path);

                using (StreamWriter writer = new StreamWriter(Path))
                {
                    writer.WriteLine(string.Format(NT + " : {0}", eNumber.ToString()));
                    writer.WriteLine(string.Format(DT + " : {0}", eData.ToString()));
                    writer.WriteLine(string.Format(S + " : {0}", eSolver.ToString()));
                    writer.WriteLine(string.Format(aFP + ": {0}", anyParameterFuzzy.ToString()));
                    if (!string.IsNullOrEmpty(problemName)) writer.WriteLine(string.Format(PN + " : {0}", problemName));
                    if (!string.IsNullOrEmpty(fuzzyParameterName)) writer.WriteLine(string.Format(FPN + " {0}", fuzzyParameterName));
                    isWrite = true;
                }
            }
            catch (Exception e)
            {
                isWrite = false;
            }

            return isWrite;
        }

        private bool ReadParameter(string line)
        {

            if (!string.IsNullOrEmpty(line))
            {
                if(line.Contains(NT) && line.Contains(ENumberType.Real.ToString())) { NumberType = ENumberType.Real; }
                else if (line.Contains(NT) && line.Contains(ENumberType.FuzzyTrap.ToString())) { NumberType = ENumberType.FuzzyTrap; }

                if (line.Contains(DT) && line.Contains(EDataType.XLS.ToString())) { DataType = EDataType.XLS; }
                else if (line.Contains(DT) && line.Contains(EDataType.CSV.ToString())) { DataType = EDataType.CSV; }

                if (line.Contains(S) && line.Contains(ESolver.BasicSimplex.ToString())) { Solver = ESolver.BasicSimplex; }
                else if (line.Contains(S) && line.Contains(ESolver.FuzzyPrimalSimplex.ToString())) { Solver = ESolver.FuzzyPrimalSimplex; }

                if (line.Contains(aFP)) { AnyFuzzyParameter = line.Replace(aFP, "").Replace(":", "").Replace(" ", "").Contains(true.ToString()); }

                if (line.Contains(PN)) { ProblemName = line.Replace(PN, "").Replace(":", "").Replace(" ", ""); }

                if (line.Contains(FPN)) { FuzzyParameterName = line.Replace(FPN, "").Replace(":", "").Replace(" ", ""); }
            }

            return (NumberType != null || DataType != null || Solver != null || !string.IsNullOrEmpty(ProblemName));
        }

        private bool WriteDefaultConfig()
        {
            bool isWrite = false;

            NumberType = ENumberType.FuzzyTrap;
            DataType = EDataType.XLS;
            Solver = ESolver.FuzzyPrimalSimplex;
            ProblemName = string.Empty;
            FuzzyParameterName = string.Empty;

            try
            {
                WriteConfig(NumberType, DataType, Solver,false, ProblemName, FuzzyParameterName);

            }
            catch (Exception e)
            {
                isWrite = false;
            }

            return isWrite;
        }
    }
}
