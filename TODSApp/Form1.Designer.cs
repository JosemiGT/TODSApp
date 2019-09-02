namespace TODSApp
{
    partial class MainForm
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
            this.buttonConfig = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelDatos = new System.Windows.Forms.Label();
            this.BuscarButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.labelInformacion = new System.Windows.Forms.Label();
            this.InformacionBox = new System.Windows.Forms.RichTextBox();
            this.PathBox = new System.Windows.Forms.TextBox();
            this.BotonDatos = new System.Windows.Forms.Button();
            this.siDatos = new System.Windows.Forms.CheckBox();
            this.BotonEjecutar = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(93)))));
            this.panel1.Controls.Add(this.buttonConfig);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1368, 84);
            this.panel1.TabIndex = 10;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.Transparent;
            this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Image = global::TODSApp.Properties.Resources.X1;
            this.buttonClose.Location = new System.Drawing.Point(1289, 0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(79, 84);
            this.buttonClose.TabIndex = 5;
            this.buttonClose.UseMnemonic = false;
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonConfig
            // 
            this.buttonConfig.BackColor = System.Drawing.Color.Transparent;
            this.buttonConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonConfig.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonConfig.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonConfig.FlatAppearance.BorderSize = 0;
            this.buttonConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfig.Image = global::TODSApp.Properties.Resources.Configuracion;
            this.buttonConfig.Location = new System.Drawing.Point(1212, 0);
            this.buttonConfig.Name = "buttonConfig";
            this.buttonConfig.Size = new System.Drawing.Size(77, 84);
            this.buttonConfig.TabIndex = 6;
            this.buttonConfig.UseMnemonic = false;
            this.buttonConfig.UseVisualStyleBackColor = false;
            this.buttonConfig.Click += new System.EventHandler(this.buttonConfig_Click);
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
            // labelDatos
            // 
            this.labelDatos.AutoSize = true;
            this.labelDatos.Font = new System.Drawing.Font("Arial Narrow", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDatos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(93)))));
            this.labelDatos.Location = new System.Drawing.Point(169, 200);
            this.labelDatos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDatos.Name = "labelDatos";
            this.labelDatos.Size = new System.Drawing.Size(200, 33);
            this.labelDatos.TabIndex = 7;
            this.labelDatos.Text = "Fuente de datos:";
            // 
            // BuscarButton
            // 
            this.BuscarButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(93)))));
            this.BuscarButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(62)))), ((int)(((byte)(27)))));
            this.BuscarButton.FlatAppearance.BorderSize = 0;
            this.BuscarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BuscarButton.ForeColor = System.Drawing.Color.White;
            this.BuscarButton.Location = new System.Drawing.Point(673, 204);
            this.BuscarButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(80, 29);
            this.BuscarButton.TabIndex = 9;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.UseVisualStyleBackColor = false;
            this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(102)))), ((int)(((byte)(106)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.richTextBox1);
            this.panel2.Controls.Add(this.labelInformacion);
            this.panel2.Controls.Add(this.InformacionBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1005, 84);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(363, 677);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
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
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // labelInformacion
            // 
            this.labelInformacion.AutoSize = true;
            this.labelInformacion.Font = new System.Drawing.Font("Arial Narrow", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInformacion.ForeColor = System.Drawing.Color.White;
            this.labelInformacion.Location = new System.Drawing.Point(94, 123);
            this.labelInformacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelInformacion.Name = "labelInformacion";
            this.labelInformacion.Size = new System.Drawing.Size(146, 33);
            this.labelInformacion.TabIndex = 3;
            this.labelInformacion.Text = "Información";
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
            this.InformacionBox.Text = "Bienvenido a Transporte Optimización Difusa (TOD) Software.";
            // 
            // PathBox
            // 
            this.PathBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PathBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(93)))));
            this.PathBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PathBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PathBox.ForeColor = System.Drawing.Color.White;
            this.PathBox.Location = new System.Drawing.Point(389, 205);
            this.PathBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PathBox.Name = "PathBox";
            this.PathBox.ReadOnly = true;
            this.PathBox.Size = new System.Drawing.Size(242, 25);
            this.PathBox.TabIndex = 12;
            this.PathBox.Text = "C:\\";
            // 
            // BotonDatos
            // 
            this.BotonDatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(102)))), ((int)(((byte)(106)))));
            this.BotonDatos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(62)))), ((int)(((byte)(27)))));
            this.BotonDatos.FlatAppearance.BorderSize = 0;
            this.BotonDatos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BotonDatos.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotonDatos.ForeColor = System.Drawing.Color.White;
            this.BotonDatos.Location = new System.Drawing.Point(325, 270);
            this.BotonDatos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BotonDatos.Name = "BotonDatos";
            this.BotonDatos.Size = new System.Drawing.Size(172, 46);
            this.BotonDatos.TabIndex = 15;
            this.BotonDatos.Text = "Comprobar datos";
            this.BotonDatos.UseVisualStyleBackColor = false;
            this.BotonDatos.Click += new System.EventHandler(this.BotonDatos_Click);
            // 
            // siDatos
            // 
            this.siDatos.AutoSize = true;
            this.siDatos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.siDatos.Enabled = false;
            this.siDatos.FlatAppearance.BorderSize = 0;
            this.siDatos.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.siDatos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(102)))), ((int)(((byte)(106)))));
            this.siDatos.Location = new System.Drawing.Point(520, 280);
            this.siDatos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.siDatos.Name = "siDatos";
            this.siDatos.Size = new System.Drawing.Size(183, 28);
            this.siDatos.TabIndex = 16;
            this.siDatos.Text = "Datos comprobados";
            this.siDatos.UseVisualStyleBackColor = true;
            // 
            // BotonEjecutar
            // 
            this.BotonEjecutar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(93)))));
            this.BotonEjecutar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(62)))), ((int)(((byte)(27)))));
            this.BotonEjecutar.FlatAppearance.BorderSize = 0;
            this.BotonEjecutar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BotonEjecutar.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotonEjecutar.ForeColor = System.Drawing.Color.White;
            this.BotonEjecutar.Location = new System.Drawing.Point(387, 483);
            this.BotonEjecutar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BotonEjecutar.Name = "BotonEjecutar";
            this.BotonEjecutar.Size = new System.Drawing.Size(172, 46);
            this.BotonEjecutar.TabIndex = 19;
            this.BotonEjecutar.Text = "Ejecutar programa";
            this.BotonEjecutar.UseVisualStyleBackColor = false;
            this.BotonEjecutar.Click += new System.EventHandler(this.BotonEjecutar_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::TODSApp.Properties.Resources.EIILogo;
            this.pictureBox2.Location = new System.Drawing.Point(655, 624);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(319, 110);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
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
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1368, 761);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.BotonEjecutar);
            this.Controls.Add(this.siDatos);
            this.Controls.Add(this.BotonDatos);
            this.Controls.Add(this.PathBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.BuscarButton);
            this.Controls.Add(this.labelDatos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "TODSApp";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelDatos;
        private System.Windows.Forms.Button BuscarButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label labelInformacion;
        private System.Windows.Forms.RichTextBox InformacionBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox PathBox;
        private System.Windows.Forms.Button BotonDatos;
        private System.Windows.Forms.CheckBox siDatos;
        private System.Windows.Forms.Button BotonEjecutar;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonConfig;
    }
}

