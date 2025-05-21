﻿namespace Cafeccinoo
{
    partial class FRMReporteInteligente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMReporteInteligente));
            this.BTNGenerarReporte = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // BTNGenerarReporte
            // 
            this.BTNGenerarReporte.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BTNGenerarReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNGenerarReporte.ForeColor = System.Drawing.Color.Black;
            this.BTNGenerarReporte.Location = new System.Drawing.Point(210, 319);
            this.BTNGenerarReporte.Name = "BTNGenerarReporte";
            this.BTNGenerarReporte.Size = new System.Drawing.Size(345, 119);
            this.BTNGenerarReporte.TabIndex = 7;
            this.BTNGenerarReporte.Text = "Generar reporte";
            this.BTNGenerarReporte.UseVisualStyleBackColor = false;
            this.BTNGenerarReporte.Click += new System.EventHandler(this.BTNGenerarReporte_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(67, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(628, 249);
            this.dataGridView1.TabIndex = 6;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Ventas por tipo de producto",
            "Productos con stock crítico",
            "Clientes inactivos en 6 meses",
            "Productos ordenados por ventas",
            "Clientes que más compraron",
            "Promedio de precio de productos por orden de compra",
            "Proveedores con más solicitudes de cotización",
            "Proveedores con más órdenes de compra",
            "Órdenes de compra sin entregar",
            "Predicción de productos con mayor probabilidad de stock crítico",
            "Predicción de productos que probablemente serán más rentables",
            "Métodos de pago más utilizados",
            "Predicción de temporadas de alta demanda"});
            this.comboBox1.Location = new System.Drawing.Point(348, 14);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(347, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(260, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tipo de reporte:";
            // 
            // FRMReporteInteligente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Chocolate;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BTNGenerarReporte);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRMReporteInteligente";
            this.Text = "Reporte inteligente";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FRMReporteInteligente_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTNGenerarReporte;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
    }
}