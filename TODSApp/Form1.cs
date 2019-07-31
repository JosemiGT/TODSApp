using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TODSLibreria.ODatosExcel;

namespace TODSApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PathBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void listBoxTipoProblema_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BotonEjecutar_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                PathBox.Text = ofd.FileName;
            }
        }

        private void BotonDatos_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(PathBox.Text))
            {
                try
                {
                    UsoExcel excel = new UsoExcel(PathBox.Text);

                    bool siExiste = excel.ComprobarSiExisteHoja("Datos", out int indiceHoja);

                    if (siExiste)
                    {
                        string message = "Los datos introducidos tienen formato de pestañas adecuado.";
                        string caption = "Comprobación de formato de datos";
                        siDatos.Checked = true;
                        MessageBoxButtons botonOK = MessageBoxButtons.OK;

                        var result = MessageBox.Show(message, caption, botonOK);
                    }
                    else
                    {
                        string message = "Error en la comprobación de datos.";
                        string caption = "Comprobación de formato de datos";
                        MessageBoxButtons botonOK = MessageBoxButtons.OK;

                        var result = MessageBox.Show(message, caption, botonOK);
                    }
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                    string caption = "Comprobación de formato de datos";
                    MessageBoxButtons botonOK = MessageBoxButtons.OK;

                    var result = MessageBox.Show(message, caption, botonOK);
                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int posY = 0;
        int posX = 0;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button != MouseButtons.Left)
            {
                posX = e.X;
                posY = e.Y;
            }
            else
            {
                Left = Left + (e.X - posX);
                Top = Top + (e.Y - posY);
            }
        }

        private void buttonConfig_Click(object sender, EventArgs e)
        {

        }
    }
}
