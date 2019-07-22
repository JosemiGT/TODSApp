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
        public SimplexSpine(string path)
        {
            string pathParent = Directory.GetParent(path).ToString();
            ServicioTraza trace = new ServicioTraza(pathParent + Constantes.ResultadoTxt + DateTime.Now.ToString());
        }

        public bool Ejecutar()
        {
            bool siCorrecto = false;



            return siCorrecto;
        }
    }
}
