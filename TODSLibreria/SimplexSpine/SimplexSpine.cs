using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODSLibreria.SimplexSpine
{
    public class SimplexSpine
    {
        private string Path { get; set; }
        private ServicioTraza Trace { get; set; }

        public SimplexSpine(string path, Config config)
        {
            string pathParent = Directory.GetParent(path).ToString();
            this.Trace = new ServicioTraza(pathParent + Constantes.ResultadoTxt + Constantes.ExtensionTxt, config);
            this.Path = path;
        }

        public void ExecuteSimplexSpine(string selectedOption, string Sheetname)
        {
            SimplexSpineLogic logic = new SimplexSpineLogic(Path);

            switch(selectedOption)
            {
                case Constantes.BasicSimplex: logic.EjecutarBasicSimplex(Sheetname);
                    break;
                case Constantes.FuzzyPrimalSimplex: logic.ExecuteFuzzyPrimalSimplex(Sheetname);
                    break;
            }

        }

    }
}
