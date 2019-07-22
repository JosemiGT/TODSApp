using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODSLibreria.SimplexSpine
{
    public class ServicioTraza
    {
        private const string Titulo = "Informe de resultados";
        private const string TextoInicial = "Resolución del problema";

        private string Path { get; set; }

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
                    if (!string.IsNullOrEmpty(variable)) { mytxt.WriteLine(variable); mytxt.WriteLine(" "); }
                }

                mytxt.Close();

            }
        }

    }
}
