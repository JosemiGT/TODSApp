using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TODSApp
{
    public partial class FormAjustes : Form
    {
        private MainForm mainForm { get; set; }
        public int posX { get; set; }
        public int posY { get; set; }

        public FormAjustes(MainForm _mainForm)
        {
            InitializeComponent();
            mainForm = _mainForm;
            this.Left = mainForm.Left;
            this.Top = mainForm.Top;
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

        }
    }
}
