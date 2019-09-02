using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TODSLibreria;

namespace TODSApp
{
    public partial class FormAjustes : Form
    {
        private MainForm mainForm { get; set; }
        public int posX { get; set; }
        public int posY { get; set; }
        public Config config { get; set; }

        public FormAjustes(MainForm _mainForm)
        {
            InitializeComponent();
            mainForm = _mainForm;
            config = new Config();
            GetParameterFile();
            if (!checkBoxFuzzyParameter.Checked) { labelParameter.Hide(); textBoxFuzzyParameter.Hide(); }
            else { labelParameter.Show(); textBoxFuzzyParameter.Show(); }
        }

        private void buttonConfig_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainForm.Show();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
            mainForm.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                posX = e.X;
                posY = e.Y;
            }
            else
            {
                Left = Left + (e.X - posX);
                mainForm.Left = Left + (e.X - posX);
                Top = Top + (e.Y - posY);
                mainForm.Top = Top + (e.Y - posY);
            }
        }

        private void BotonCambios_Click(object sender, EventArgs e)
        {
            if (CheckParameter()) { SetParameterFile(); if (config.WriteConfig()) MessageBox.Show(Config.CorrectConfifMessage, Config.CorrectConfif, MessageBoxButtons.OK); }
            else MessageBox.Show(Config.IncorrectConfifMessage, Config.IncorrectConfif, MessageBoxButtons.OK);
        }

        private void GetParameterFile()
        {
            if(config.NumberType != null && config.NumberType == Config.ENumberType.Real)  this.listBoxTipoNumeros.SelectedItem = this.listBoxTipoNumeros.Items[0]; 
            else if(config.NumberType != null && config.NumberType == Config.ENumberType.FuzzyTrap)  this.listBoxTipoNumeros.SelectedItem = this.listBoxTipoNumeros.Items[1]; 

            if(config.DataType != null && config.DataType == Config.EDataType.XLS)  this.listBoxFormatoDatos.SelectedItem = this.listBoxFormatoDatos.Items[0];
            else if(config.DataType != null && config.DataType == Config.EDataType.CSV)  this.listBoxFormatoDatos.SelectedItem = this.listBoxFormatoDatos.Items[1];

            if (config.Solver != null && config.Solver == Config.ESolver.BasicSimplex)  this.listBoxSolver.SelectedItem = this.listBoxSolver.Items[0];
            else if (config.Solver != null && config.Solver == Config.ESolver.FuzzyPrimalSimplex)  this.listBoxSolver.SelectedItem = this.listBoxSolver.Items[1];

            if(config.AnyFuzzyParameter)  this.checkBoxFuzzyParameter.Checked = true; 
            else this.checkBoxFuzzyParameter.Checked = false; 

            if (!string.IsNullOrEmpty(config.ProblemName)) this.textBoxProblemName.Text = config.ProblemName;

            if (!string.IsNullOrEmpty(config.FuzzyParameterName)) this.textBoxFuzzyParameter.Text = config.FuzzyParameterName;
        }

        private void SetParameterFile()
        {
            if (this.listBoxTipoNumeros.SelectedItem == this.listBoxTipoNumeros.Items[0]) config.NumberType = Config.ENumberType.Real;
            else if (this.listBoxTipoNumeros.SelectedItem == this.listBoxTipoNumeros.Items[1]) config.NumberType = Config.ENumberType.FuzzyTrap;

            if (this.listBoxFormatoDatos.SelectedItem == this.listBoxFormatoDatos.Items[0]) config.DataType = Config.EDataType.XLS;
            else if (this.listBoxFormatoDatos.SelectedItem == this.listBoxFormatoDatos.Items[1]) config.DataType = Config.EDataType.CSV;

            if (this.listBoxSolver.SelectedItem == this.listBoxSolver.Items[0]) config.Solver = Config.ESolver.BasicSimplex;
            else if (this.listBoxSolver.SelectedItem == this.listBoxSolver.Items[1]) config.Solver = Config.ESolver.FuzzyPrimalSimplex;

            if (!string.IsNullOrEmpty(this.textBoxProblemName.Text)) config.ProblemName = this.textBoxProblemName.Text;

            config.AnyFuzzyParameter = this.checkBoxFuzzyParameter.Checked;

            if (!string.IsNullOrEmpty(this.textBoxFuzzyParameter.Text)) config.FuzzyParameterName = this.textBoxFuzzyParameter.Text;
        }

        private bool CheckParameter()
        {
            return ((this.listBoxTipoNumeros.SelectedItem == this.listBoxTipoNumeros.Items[0] && this.listBoxSolver.SelectedItem == this.listBoxSolver.Items[0]) || (this.listBoxTipoNumeros.SelectedItem == this.listBoxTipoNumeros.Items[1] && this.listBoxSolver.SelectedItem != this.listBoxSolver.Items[0]));
        }

        private void checkBoxFuzzyParameter_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxFuzzyParameter.Checked) { labelParameter.Hide(); textBoxFuzzyParameter.Hide(); }
            else { labelParameter.Show(); textBoxFuzzyParameter.Show(); }
        }
    }
}
