namespace TODSApp
{
    partial class FormAjustes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonReturn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.labelInformacion = new System.Windows.Forms.Label();
            this.InformacionBox = new System.Windows.Forms.RichTextBox();
            this.labelDatos = new System.Windows.Forms.Label();
            this.listBoxTipoNumeros = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxFormatoDatos = new System.Windows.Forms.ListBox();
            this.BotonCambios = new System.Windows.Forms.Button();
            this.listBoxSolver = new System.Windows.Forms.ListBox();
            this.labelTipoProblema = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxProblemName = new System.Windows.Forms.TextBox();
            this.labelParameter = new System.Windows.Forms.Label();
            this.textBoxFuzzyParameter = new System.Windows.Forms.TextBox();
            this.checkBoxFuzzyParameter = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(93)))));
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Controls.Add(this.buttonReturn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1375, 84);
            this.panel1.TabIndex = 11;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.Transparent;
            this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Image = global::TODSApp.Properties.Resources.X1;
            this.buttonClose.Location = new System.Drawing.Point(1277, 6);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(79, 74);
            this.buttonClose.TabIndex = 5;
            this.buttonClose.UseMnemonic = false;
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonReturn
            // 
            this.buttonReturn.BackColor = System.Drawing.Color.Transparent;
            this.buttonReturn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonReturn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonReturn.FlatAppearance.BorderSize = 0;
            this.buttonReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReturn.Image = global::TODSApp.Properties.Resources.Untitled1;
            this.buttonReturn.Location = new System.Drawing.Point(1015, 9);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(77, 68);
            this.buttonReturn.TabIndex = 6;
            this.buttonReturn.UseMnemonic = false;
            this.buttonReturn.UseVisualStyleBackColor = false;
            this.buttonReturn.Click += new System.EventHandler(this.buttonConfig_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 16F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(27, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "TODS App";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(102)))), ((int)(((byte)(106)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.richTextBox1);
            this.panel2.Controls.Add(this.labelInformacion);
            this.panel2.Controls.Add(this.InformacionBox);
            this.panel2.Location = new System.Drawing.Point(1015, 82);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(363, 686);
            this.panel2.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(31, 540);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(275, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tranporte Optimización Difuso";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(102)))), ((int)(((byte)(106)))));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.ForeColor = System.Drawing.Color.White;
            this.richTextBox1.Location = new System.Drawing.Point(36, 584);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(220, 68);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "Trabajo de Fin de Grado\nJosé Miguel Gamarro Tornay";
            // 
            // labelInformacion
            // 
            this.labelInformacion.AutoSize = true;
            this.labelInformacion.Font = new System.Drawing.Font("Arial Narrow", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInformacion.ForeColor = System.Drawing.Color.White;
            this.labelInformacion.Location = new System.Drawing.Point(94, 123);
            this.labelInformacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelInformacion.Name = "labelInformacion";
            this.labelInformacion.Size = new System.Drawing.Size(171, 33);
            this.labelInformacion.TabIndex = 3;
            this.labelInformacion.Text = "Configuración";
            // 
            // InformacionBox
            // 
            this.InformacionBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(102)))), ((int)(((byte)(106)))));
            this.InformacionBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InformacionBox.ForeColor = System.Drawing.Color.White;
            this.InformacionBox.Location = new System.Drawing.Point(36, 194);
            this.InformacionBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.InformacionBox.Name = "InformacionBox";
            this.InformacionBox.ReadOnly = true;
            this.InformacionBox.Size = new System.Drawing.Size(298, 245);
            this.InformacionBox.TabIndex = 0;
            this.InformacionBox.Text = "Aquí puede configurar los parámetros de ajuste para tener en cuenta en la resoluc" +
    "ión de un problema dado.";
            // 
            // labelDatos
            // 
            this.labelDatos.AutoSize = true;
            this.labelDatos.Font = new System.Drawing.Font("Arial Narrow", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDatos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(93)))));
            this.labelDatos.Location = new System.Drawing.Point(147, 151);
            this.labelDatos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDatos.Name = "labelDatos";
            this.labelDatos.Size = new System.Drawing.Size(207, 33);
            this.labelDatos.TabIndex = 13;
            this.labelDatos.Text = "Tipo de números:";
            // 
            // listBoxTipoNumeros
            // 
            this.listBoxTipoNumeros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(93)))));
            this.listBoxTipoNumeros.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxTipoNumeros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxTipoNumeros.ForeColor = System.Drawing.Color.White;
            this.listBoxTipoNumeros.FormattingEnabled = true;
            this.listBoxTipoNumeros.ItemHeight = 29;
            this.listBoxTipoNumeros.Items.AddRange(new object[] {
            "Reales",
            "Trapezoidales Difusos"});
            this.listBoxTipoNumeros.Location = new System.Drawing.Point(376, 155);
            this.listBoxTipoNumeros.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBoxTipoNumeros.Name = "listBoxTipoNumeros";
            this.listBoxTipoNumeros.Size = new System.Drawing.Size(310, 29);
            this.listBoxTipoNumeros.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(93)))));
            this.label3.Location = new System.Drawing.Point(147, 236);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 33);
            this.label3.TabIndex = 20;
            this.label3.Text = "Formato datos:";
            // 
            // listBoxFormatoDatos
            // 
            this.listBoxFormatoDatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(93)))));
            this.listBoxFormatoDatos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxFormatoDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxFormatoDatos.ForeColor = System.Drawing.Color.White;
            this.listBoxFormatoDatos.FormattingEnabled = true;
            this.listBoxFormatoDatos.ItemHeight = 29;
            this.listBoxFormatoDatos.Items.AddRange(new object[] {
            ".xmls",
            "CSV"});
            this.listBoxFormatoDatos.Location = new System.Drawing.Point(376, 240);
            this.listBoxFormatoDatos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBoxFormatoDatos.Name = "listBoxFormatoDatos";
            this.listBoxFormatoDatos.Size = new System.Drawing.Size(310, 29);
            this.listBoxFormatoDatos.TabIndex = 21;
            // 
            // BotonCambios
            // 
            this.BotonCambios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(102)))), ((int)(((byte)(106)))));
            this.BotonCambios.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(62)))), ((int)(((byte)(27)))));
            this.BotonCambios.FlatAppearance.BorderSize = 0;
            this.BotonCambios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BotonCambios.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotonCambios.ForeColor = System.Drawing.Color.White;
            this.BotonCambios.Location = new System.Drawing.Point(373, 534);
            this.BotonCambios.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BotonCambios.Name = "BotonCambios";
            this.BotonCambios.Size = new System.Drawing.Size(172, 46);
            this.BotonCambios.TabIndex = 23;
            this.BotonCambios.Text = "Aplicar cambios";
            this.BotonCambios.UseVisualStyleBackColor = false;
            this.BotonCambios.Click += new System.EventHandler(this.BotonCambios_Click);
            // 
            // listBoxSolver
            // 
            this.listBoxSolver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(93)))));
            this.listBoxSolver.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxSolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxSolver.ForeColor = System.Drawing.Color.White;
            this.listBoxSolver.FormattingEnabled = true;
            this.listBoxSolver.ItemHeight = 29;
            this.listBoxSolver.Items.AddRange(new object[] {
            "Algoritmo Simplex Real",
            "Algoritmo Simplex Primal Difuso"});
            this.listBoxSolver.Location = new System.Drawing.Point(301, 391);
            this.listBoxSolver.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBoxSolver.Name = "listBoxSolver";
            this.listBoxSolver.Size = new System.Drawing.Size(385, 29);
            this.listBoxSolver.TabIndex = 25;
            // 
            // labelTipoProblema
            // 
            this.labelTipoProblema.AutoSize = true;
            this.labelTipoProblema.Font = new System.Drawing.Font("Arial Narrow", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTipoProblema.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(93)))));
            this.labelTipoProblema.Location = new System.Drawing.Point(147, 391);
            this.labelTipoProblema.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTipoProblema.Name = "labelTipoProblema";
            this.labelTipoProblema.Size = new System.Drawing.Size(93, 33);
            this.labelTipoProblema.TabIndex = 24;
            this.labelTipoProblema.Text = "Solver:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::TODSApp.Properties.Resources.logoUMA;
            this.pictureBox1.InitialImage = global::TODSApp.Properties.Resources.logoUMA;
            this.pictureBox1.Location = new System.Drawing.Point(34, 624);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(320, 110);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::TODSApp.Properties.Resources.EIILogo;
            this.pictureBox2.Location = new System.Drawing.Point(655, 624);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(319, 110);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 27;
            this.pictureBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(93)))));
            this.label4.Location = new System.Drawing.Point(147, 314);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(258, 33);
            this.label4.TabIndex = 28;
            this.label4.Text = "Nombre del problema:";
            // 
            // textBoxProblemName
            // 
            this.textBoxProblemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.textBoxProblemName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(93)))));
            this.textBoxProblemName.Location = new System.Drawing.Point(412, 321);
            this.textBoxProblemName.Name = "textBoxProblemName";
            this.textBoxProblemName.Size = new System.Drawing.Size(274, 35);
            this.textBoxProblemName.TabIndex = 29;
            // 
            // labelParameter
            // 
            this.labelParameter.AutoSize = true;
            this.labelParameter.Font = new System.Drawing.Font("Arial Narrow", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelParameter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(93)))));
            this.labelParameter.Location = new System.Drawing.Point(147, 467);
            this.labelParameter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelParameter.Name = "labelParameter";
            this.labelParameter.Size = new System.Drawing.Size(238, 33);
            this.labelParameter.TabIndex = 30;
            this.labelParameter.Text = "Parámetros difusos:";
            // 
            // textBoxFuzzyParameter
            // 
            this.textBoxFuzzyParameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.textBoxFuzzyParameter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(93)))));
            this.textBoxFuzzyParameter.Location = new System.Drawing.Point(392, 465);
            this.textBoxFuzzyParameter.Name = "textBoxFuzzyParameter";
            this.textBoxFuzzyParameter.Size = new System.Drawing.Size(274, 35);
            this.textBoxFuzzyParameter.TabIndex = 31;
            // 
            // checkBoxFuzzyParameter
            // 
            this.checkBoxFuzzyParameter.AutoSize = true;
            this.checkBoxFuzzyParameter.Location = new System.Drawing.Point(707, 323);
            this.checkBoxFuzzyParameter.Name = "checkBoxFuzzyParameter";
            this.checkBoxFuzzyParameter.Size = new System.Drawing.Size(190, 24);
            this.checkBoxFuzzyParameter.TabIndex = 32;
            this.checkBoxFuzzyParameter.Text = "¿Parámetros difusos?";
            this.checkBoxFuzzyParameter.UseVisualStyleBackColor = true;
            this.checkBoxFuzzyParameter.CheckedChanged += new System.EventHandler(this.checkBoxFuzzyParameter_CheckedChanged);
            // 
            // FormAjustes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1368, 761);
            this.Controls.Add(this.checkBoxFuzzyParameter);
            this.Controls.Add(this.textBoxFuzzyParameter);
            this.Controls.Add(this.labelParameter);
            this.Controls.Add(this.textBoxProblemName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listBoxSolver);
            this.Controls.Add(this.labelTipoProblema);
            this.Controls.Add(this.BotonCambios);
            this.Controls.Add(this.listBoxFormatoDatos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBoxTipoNumeros);
            this.Controls.Add(this.labelDatos);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAjustes";
            this.Text = "FormAjustes";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label labelInformacion;
        private System.Windows.Forms.RichTextBox InformacionBox;
        private System.Windows.Forms.Label labelDatos;
        private System.Windows.Forms.ListBox listBoxTipoNumeros;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxFormatoDatos;
        private System.Windows.Forms.Button BotonCambios;
        private System.Windows.Forms.ListBox listBoxSolver;
        private System.Windows.Forms.Label labelTipoProblema;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxProblemName;
        private System.Windows.Forms.Label labelParameter;
        private System.Windows.Forms.TextBox textBoxFuzzyParameter;
        private System.Windows.Forms.CheckBox checkBoxFuzzyParameter;
    }
}