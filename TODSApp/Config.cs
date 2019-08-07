using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODSApp
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
        public const string PN = "ProblemName";
        private const string fileName = "TODSconfig.txt";

        public enum ENumberType { Real, FuzzyTrap}
        public enum EDataType { XLS, CSV }
        public enum ESolver { Simplex, FSP }

        public ENumberType? NumberType { get; set; }
        public EDataType? DataType { get; set; }
        public ESolver? Solver { get; set; }
        public string ProblemName { get; set; }

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
                    if(!string.IsNullOrEmpty(ProblemName)) writer.WriteLine(string.Format(PN + " : {0}", ProblemName));
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

                if (line.Contains(S) && line.Contains(ESolver.Simplex.ToString())) { Solver = ESolver.Simplex; }
                else if (line.Contains(S) && line.Contains(ESolver.FSP.ToString())) { Solver = ESolver.FSP; }

                if (line.Contains(PN)) { ProblemName = line.Replace(PN, "").Replace(":", "").Replace(" ", ""); }
            }

            return (NumberType != null || DataType != null || Solver != null || !string.IsNullOrEmpty(ProblemName));
        }

        private bool WriteDefaultConfig()
        {
            bool isWrite = false;

            NumberType = ENumberType.FuzzyTrap;
            DataType = EDataType.XLS;
            Solver = ESolver.FSP;
            ProblemName = string.Empty;

            try
            {
                using (StreamWriter writer = new StreamWriter(Path))
                {
                    writer.WriteLine(string.Format(NT + " : {0}", NumberType.ToString()));
                    writer.WriteLine(string.Format(DT + " : {0}", DataType.ToString()));
                    writer.WriteLine(string.Format(S + " : {0}", Solver.ToString()));
                    isWrite = true;
                }
            }
            catch(Exception e)
            {
                isWrite = false;
            }

            return isWrite;
        }
    }
}
