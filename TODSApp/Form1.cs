using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TODSLibreria;
using TODSLibreria.ODatosExcel;
using TODSLibreria.SimplexSpine;

namespace TODSApp
{
    public partial class MainForm : Form
    {
        public int posX { get; set; }
        public int posY { get; set; }
        public FormAjustes ajustesForm { get; set; }
        public FormLoading loadingF { get; set; }

        public MainForm()
        {
            InitializeComponent();
            ajustesForm = new FormAjustes(this);
            loadingF = new FormLoading();
            ajustesForm.Left = this.Left;
            ajustesForm.Top = this.Top;
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
            SimplexSpine spine = new SimplexSpine(PathBox.Text, ajustesForm.config);

            if (siDatos.Checked && ajustesForm.config.DataType == Config.EDataType.XLS)
            {
                Task simplexTask = new Task(() => spine.ExecuteSimplexSpine(ajustesForm.config.Solver.ToString(), ajustesForm.config.ProblemName));
                simplexTask.Start();
                loadingF.Top = this.Top;
                loadingF.Left = this.Left;
                loadingF.Show();
                simplexTask.Wait();
                loadingF.Hide();
                this.siDatos.Checked = false; 

                if (MessageBox.Show("Ha finalizado el cálculo", "Proceso completado. ¿Quiere ver la solución?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Config resultConfig = new Config();
                    using (Stream str = File.Open(resultConfig.ResultPath, FileMode.Open))
                    {
                        Process.Start("notepad.exe", resultConfig.ResultPath);
                    }
                } 




            }
            else if (siDatos.Checked && ajustesForm.config.DataType == Config.EDataType.CSV) MessageBox.Show("En la versión actual no está disponible lectura de archivos CSV", "No disponible", MessageBoxButtons.OK);
            else MessageBox.Show("Requiere comprobar los datos previamente", "Acción necesaria", MessageBoxButtons.OK);
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
                    if (excel.ComprobarSiExisteHoja(ajustesForm.config.ProblemName, out int indiceHoja)) { MessageBox.Show(Config.dataMessageCheckOk, Config.dataTittleCheck, MessageBoxButtons.OK); siDatos.Checked = true; }
                    else MessageBox.Show(Config.dataMessageCheckNoOk, Config.dataTittleCheck, MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Config.dataTittleCheck, MessageBoxButtons.OK);
                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ajustesForm.Close();
            this.Close();
        }

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
                ajustesForm.Left = Left + (e.X - posX);
                Top = Top + (e.Y - posY);
                ajustesForm.Top = Top + (e.Y - posY);
            }
        }

        private void buttonConfig_Click(object sender, EventArgs e)
        {
            ajustesForm.Show();
            this.Hide();
        }
    }
}
