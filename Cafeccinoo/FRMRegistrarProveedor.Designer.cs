﻿namespace Cafeccinoo
{
    partial class FRMRegistrarProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMRegistrarProveedor));
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CBCuit = new System.Windows.Forms.ComboBox();
            this.BTNRegistrarProveedor = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(112, 70);
            this.textBox2.MaxLength = 34;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(139, 20);
            this.textBox2.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "Cuenta bancaria";
            // 
            // CBCuit
            // 
            this.CBCuit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBCuit.FormattingEnabled = true;
            this.CBCuit.Location = new System.Drawing.Point(112, 17);
            this.CBCuit.Name = "CBCuit";
            this.CBCuit.Size = new System.Drawing.Size(139, 21);
            this.CBCuit.TabIndex = 38;
            // 
            // BTNRegistrarProveedor
            // 
            this.BTNRegistrarProveedor.Location = new System.Drawing.Point(62, 96);
            this.BTNRegistrarProveedor.Name = "BTNRegistrarProveedor";
            this.BTNRegistrarProveedor.Size = new System.Drawing.Size(136, 23);
            this.BTNRegistrarProveedor.TabIndex = 37;
            this.BTNRegistrarProveedor.Text = "Registrar proveedor";
            this.BTNRegistrarProveedor.UseVisualStyleBackColor = true;
            this.BTNRegistrarProveedor.Click += new System.EventHandler(this.BTNRegistrarProveedor_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(112, 44);
            this.textBox1.MaxLength = 100;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(139, 20);
            this.textBox1.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Dirección";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "CUIT";
            // 
            // FRMRegistrarProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Chocolate;
            this.ClientSize = new System.Drawing.Size(282, 131);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CBCuit);
            this.Controls.Add(this.BTNRegistrarProveedor);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRMRegistrarProveedor";
            this.Text = "Registrar proveedor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FRMRegistrarProveedor_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.FRMRegistrarProveedor_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CBCuit;
        private System.Windows.Forms.Button BTNRegistrarProveedor;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}