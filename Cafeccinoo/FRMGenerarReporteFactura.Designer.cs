namespace Cafeccinoo
{
    partial class FRMGenerarReporteFactura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMGenerarReporteFactura));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.BTNGenerarReporte = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(766, 299);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(185, 323);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(415, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Seleccione la factura en la grilla y presione el botón para guardar el reporte co" +
    "mo .PDF";
            // 
            // BTNGenerarReporte
            // 
            this.BTNGenerarReporte.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BTNGenerarReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNGenerarReporte.ForeColor = System.Drawing.Color.Black;
            this.BTNGenerarReporte.Location = new System.Drawing.Point(188, 339);
            this.BTNGenerarReporte.Name = "BTNGenerarReporte";
            this.BTNGenerarReporte.Size = new System.Drawing.Size(412, 60);
            this.BTNGenerarReporte.TabIndex = 4;
            this.BTNGenerarReporte.Text = "Generar reporte";
            this.BTNGenerarReporte.UseVisualStyleBackColor = false;
            this.BTNGenerarReporte.Click += new System.EventHandler(this.BTNGenerarReporte_Click);
            // 
            // FRMGenerarReporteFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Chocolate;
            this.ClientSize = new System.Drawing.Size(800, 411);
            this.Controls.Add(this.BTNGenerarReporte);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRMGenerarReporteFactura";
            this.Text = "Generar reporte factura";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FRMGenerarReporteFactura_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.FRMGenerarReporteFactura_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTNGenerarReporte;
    }
}