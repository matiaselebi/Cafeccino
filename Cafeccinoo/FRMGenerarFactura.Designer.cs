namespace Cafeccinoo
{
    partial class FRMGenerarFactura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRMGenerarFactura));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BTNGenerarFactura = new System.Windows.Forms.Button();
            this.BTNCobrarVenta = new System.Windows.Forms.Button();
            this.BTNSeleccionarProductos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // BTNGenerarFactura
            // 
            resources.ApplyResources(this.BTNGenerarFactura, "BTNGenerarFactura");
            this.BTNGenerarFactura.Name = "BTNGenerarFactura";
            this.BTNGenerarFactura.UseVisualStyleBackColor = true;
            this.BTNGenerarFactura.Click += new System.EventHandler(this.BTNGenerarFactura_Click);
            // 
            // BTNCobrarVenta
            // 
            resources.ApplyResources(this.BTNCobrarVenta, "BTNCobrarVenta");
            this.BTNCobrarVenta.Name = "BTNCobrarVenta";
            this.BTNCobrarVenta.UseVisualStyleBackColor = true;
            this.BTNCobrarVenta.Click += new System.EventHandler(this.BTNCobrarVenta_Click);
            // 
            // BTNSeleccionarProductos
            // 
            resources.ApplyResources(this.BTNSeleccionarProductos, "BTNSeleccionarProductos");
            this.BTNSeleccionarProductos.Name = "BTNSeleccionarProductos";
            this.BTNSeleccionarProductos.UseVisualStyleBackColor = true;
            this.BTNSeleccionarProductos.Click += new System.EventHandler(this.BTNSeleccionarProductos_Click);
            // 
            // FRMGenerarFactura
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Chocolate;
            this.Controls.Add(this.BTNGenerarFactura);
            this.Controls.Add(this.BTNCobrarVenta);
            this.Controls.Add(this.BTNSeleccionarProductos);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FRMGenerarFactura";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FRMGenerarFactura_FormClosing);
            this.Load += new System.EventHandler(this.FRMGenerarFactura_Load);
            this.VisibleChanged += new System.EventHandler(this.FRMGenerarFactura_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTNGenerarFactura;
        private System.Windows.Forms.Button BTNCobrarVenta;
        private System.Windows.Forms.Button BTNSeleccionarProductos;
    }
}