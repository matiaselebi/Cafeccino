namespace Cafeccinoo
{
    partial class FRMBitacoraEventos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMBitacoraEventos));
            this.BTNImprimir = new System.Windows.Forms.Button();
            this.BTNLimpiar = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.CBCriticidad = new System.Windows.Forms.ComboBox();
            this.CBEvento = new System.Windows.Forms.ComboBox();
            this.CBModulo = new System.Windows.Forms.ComboBox();
            this.CBLogin = new System.Windows.Forms.ComboBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // BTNImprimir
            // 
            this.BTNImprimir.Location = new System.Drawing.Point(424, 399);
            this.BTNImprimir.Name = "BTNImprimir";
            this.BTNImprimir.Size = new System.Drawing.Size(100, 50);
            this.BTNImprimir.TabIndex = 38;
            this.BTNImprimir.Text = "Imprimir";
            this.BTNImprimir.UseVisualStyleBackColor = true;
            this.BTNImprimir.Click += new System.EventHandler(this.BTNImprimir_Click);
            // 
            // BTNLimpiar
            // 
            this.BTNLimpiar.Location = new System.Drawing.Point(250, 399);
            this.BTNLimpiar.Name = "BTNLimpiar";
            this.BTNLimpiar.Size = new System.Drawing.Size(100, 50);
            this.BTNLimpiar.TabIndex = 37;
            this.BTNLimpiar.Text = "Limpiar";
            this.BTNLimpiar.UseVisualStyleBackColor = true;
            this.BTNLimpiar.Click += new System.EventHandler(this.BTNLimpiar_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(474, 286);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 36;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(271, 286);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 35;
            // 
            // CBCriticidad
            // 
            this.CBCriticidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBCriticidad.FormattingEnabled = true;
            this.CBCriticidad.Items.AddRange(new object[] {
            "",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.CBCriticidad.Location = new System.Drawing.Point(634, 360);
            this.CBCriticidad.MaxLength = 1;
            this.CBCriticidad.Name = "CBCriticidad";
            this.CBCriticidad.Size = new System.Drawing.Size(38, 21);
            this.CBCriticidad.TabIndex = 34;
            this.CBCriticidad.TextChanged += new System.EventHandler(this.CBCriticidad_TextChanged);
            // 
            // CBEvento
            // 
            this.CBEvento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBEvento.FormattingEnabled = true;
            this.CBEvento.Location = new System.Drawing.Point(289, 360);
            this.CBEvento.MaxLength = 100;
            this.CBEvento.Name = "CBEvento";
            this.CBEvento.Size = new System.Drawing.Size(200, 21);
            this.CBEvento.TabIndex = 33;
            this.CBEvento.TextChanged += new System.EventHandler(this.CBEvento_TextChanged);
            // 
            // CBModulo
            // 
            this.CBModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBModulo.FormattingEnabled = true;
            this.CBModulo.Location = new System.Drawing.Point(88, 360);
            this.CBModulo.MaxLength = 50;
            this.CBModulo.Name = "CBModulo";
            this.CBModulo.Size = new System.Drawing.Size(121, 21);
            this.CBModulo.TabIndex = 32;
            this.CBModulo.TextChanged += new System.EventHandler(this.CBModulo_TextChanged);
            // 
            // CBLogin
            // 
            this.CBLogin.FormattingEnabled = true;
            this.CBLogin.Location = new System.Drawing.Point(88, 322);
            this.CBLogin.MaxLength = 20;
            this.CBLogin.Name = "CBLogin";
            this.CBLogin.Size = new System.Drawing.Size(121, 21);
            this.CBLogin.TabIndex = 31;
            this.CBLogin.TextChanged += new System.EventHandler(this.CBLogin_TextChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(563, 322);
            this.dateTimePicker2.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker2.MinDate = new System.DateTime(2024, 1, 2, 0, 0, 0, 0);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 30;
            this.dateTimePicker2.Value = new System.DateTime(2024, 9, 10, 0, 0, 0, 0);
            this.dateTimePicker2.CloseUp += new System.EventHandler(this.dateTimePicker2_CloseUp);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(289, 322);
            this.dateTimePicker1.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker1.MinDate = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 29;
            this.dateTimePicker1.Value = new System.DateTime(2024, 9, 8, 0, 0, 0, 0);
            this.dateTimePicker1.CloseUp += new System.EventHandler(this.dateTimePicker1_CloseUp);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(575, 365);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Criticidad:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(227, 363);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Evento:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 363);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Módulo:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(495, 325);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Fecha final:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(217, 325);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Fecha inicial:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 325);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Login:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(421, 289);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Apellido:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(221, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Nombre:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(16, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(768, 257);
            this.dataGridView1.TabIndex = 20;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // FRMBitacoraEventos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Chocolate;
            this.ClientSize = new System.Drawing.Size(821, 461);
            this.Controls.Add(this.BTNImprimir);
            this.Controls.Add(this.BTNLimpiar);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.CBCriticidad);
            this.Controls.Add(this.CBEvento);
            this.Controls.Add(this.CBModulo);
            this.Controls.Add(this.CBLogin);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRMBitacoraEventos";
            this.Text = "Bitacora de eventos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FRMBitacoraEventos_FormClosing);
            this.Load += new System.EventHandler(this.FRMBitacoraEventos_Load);
            this.VisibleChanged += new System.EventHandler(this.FRMBitacoraEventos_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTNImprimir;
        private System.Windows.Forms.Button BTNLimpiar;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox CBCriticidad;
        private System.Windows.Forms.ComboBox CBEvento;
        private System.Windows.Forms.ComboBox CBModulo;
        private System.Windows.Forms.ComboBox CBLogin;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}