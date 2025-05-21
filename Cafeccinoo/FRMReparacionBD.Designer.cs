namespace Cafeccinoo
{
    partial class FRMReparacionBD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMReparacionBD));
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BTNSalir = new System.Windows.Forms.Button();
            this.BTNRestaurar = new System.Windows.Forms.Button();
            this.BTNRecalcular = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(316, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = ".";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(222, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "TABLA AFECTADA: ";
            // 
            // BTNSalir
            // 
            this.BTNSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNSalir.Location = new System.Drawing.Point(167, 293);
            this.BTNSalir.Name = "BTNSalir";
            this.BTNSalir.Size = new System.Drawing.Size(309, 64);
            this.BTNSalir.TabIndex = 10;
            this.BTNSalir.Text = "Salir";
            this.BTNSalir.UseVisualStyleBackColor = true;
            this.BTNSalir.Click += new System.EventHandler(this.BTNSalir_Click);
            // 
            // BTNRestaurar
            // 
            this.BTNRestaurar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNRestaurar.Location = new System.Drawing.Point(167, 223);
            this.BTNRestaurar.Name = "BTNRestaurar";
            this.BTNRestaurar.Size = new System.Drawing.Size(309, 64);
            this.BTNRestaurar.TabIndex = 9;
            this.BTNRestaurar.Text = "Restaurar base de datos";
            this.BTNRestaurar.UseVisualStyleBackColor = true;
            this.BTNRestaurar.Click += new System.EventHandler(this.BTNRestaurar_Click);
            // 
            // BTNRecalcular
            // 
            this.BTNRecalcular.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTNRecalcular.Location = new System.Drawing.Point(167, 153);
            this.BTNRecalcular.Name = "BTNRecalcular";
            this.BTNRecalcular.Size = new System.Drawing.Size(309, 64);
            this.BTNRecalcular.TabIndex = 8;
            this.BTNRecalcular.Text = "Recalcular dígito verificador";
            this.BTNRecalcular.UseVisualStyleBackColor = true;
            this.BTNRecalcular.Click += new System.EventHandler(this.BTNRecalcular_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(566, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "INCONSISTENCIA PRESENTE EN LA BASE DE DATOS";
            // 
            // FRMReparacionBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Chocolate;
            this.ClientSize = new System.Drawing.Size(673, 400);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BTNSalir);
            this.Controls.Add(this.BTNRestaurar);
            this.Controls.Add(this.BTNRecalcular);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRMReparacionBD";
            this.Text = "Reparacion de base de datos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FRMReparacionBD_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.FRMReparacionBD_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BTNSalir;
        private System.Windows.Forms.Button BTNRestaurar;
        private System.Windows.Forms.Button BTNRecalcular;
        private System.Windows.Forms.Label label1;
    }
}