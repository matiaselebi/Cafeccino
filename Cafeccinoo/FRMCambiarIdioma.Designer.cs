﻿namespace Cafeccinoo
{
    partial class FRMCambiarIdioma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMCambiarIdioma));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.BTNCambiarIdioma = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Idioma";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Español",
            "English"});
            this.comboBox1.Location = new System.Drawing.Point(13, 30);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(200, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // BTNCambiarIdioma
            // 
            this.BTNCambiarIdioma.Location = new System.Drawing.Point(13, 58);
            this.BTNCambiarIdioma.Name = "BTNCambiarIdioma";
            this.BTNCambiarIdioma.Size = new System.Drawing.Size(200, 23);
            this.BTNCambiarIdioma.TabIndex = 2;
            this.BTNCambiarIdioma.Text = "Cambiar Idioma";
            this.BTNCambiarIdioma.UseVisualStyleBackColor = true;
            this.BTNCambiarIdioma.Click += new System.EventHandler(this.BTNCambiarIdioma_Click_1);
            // 
            // FRMCambiarIdioma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Chocolate;
            this.ClientSize = new System.Drawing.Size(229, 99);
            this.Controls.Add(this.BTNCambiarIdioma);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRMCambiarIdioma";
            this.Text = "Cambiar idioma";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FRMCambiarIdioma_FormClosing_1);
            this.Load += new System.EventHandler(this.FRMCambiarIdioma_Load);
            this.VisibleChanged += new System.EventHandler(this.FRMCambiarIdioma_VisibleChanged_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button BTNCambiarIdioma;
    }
}