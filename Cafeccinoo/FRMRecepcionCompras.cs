﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BE;
using Servicio;

namespace Cafeccinoo
{
    public partial class FRMRecepcionCompras : Form, IObserver
    {
        Negocios negocios = new Negocios();
        BLLOrdenCompra NegociosOrdenCompra = new BLLOrdenCompra();
        BLLEvento NegociosEvento = new BLLEvento();
        FRMUI parent;

        public FRMRecepcionCompras()
        {
            InitializeComponent();
            LanguageManager.ObtenerInstancia().Agregar(this);
        }
        public void ActualizarIdioma()
        {
            LanguageManager.ObtenerInstancia().CambiarIdiomaControles(this);
        }

        private void FRMRecepcionCompras_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void BTNGuardarCambios_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                if (dr.Cells[4].Value.ToString().Length > 0)
                {
                    NegociosOrdenCompra.RecibirProducto(Convert.ToInt32(dr.Cells[0].Value.ToString()), Convert.ToInt32(dr.Cells[4].Value), Convert.ToDateTime(dr.Cells[5].Value), dr.Cells[6].Value.ToString());
                }
            }

            NegociosEvento.RegistrarEvento(new Evento(SessionManager.ObtenerInstancia().ObtenerDatosUsuario().Username, DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("HH:mm:ss"), "Compra", "Recepción de compras", 3));

            GenerarReportePDF();

            MessageBox.Show(LanguageManager.ObtenerInstancia().ObtenerTexto("FRMRecepcionCompras.Etiquetas.CambiosGuardados"));

            parent.FormGestionProductos.RefrescarGrilla();
            CargarCB();
        }
        public void CargarCB()
        {
            CBOrdenCompra.DataSource = negocios.ObtenerTabla("DISTINCT CodOrdenCompra", "ItemOrden", "FechaEntrega IS NULL");
            CBOrdenCompra.DisplayMember = "CodOrdenCompra";
            CBOrdenCompra.ValueMember = "CodOrdenCompra";

            CBOrdenCompra.SelectedItem = null;

            if (CBOrdenCompra.Items.Count == 0)
            {
                CBOrdenCompra.Text = "";
            }
        }

        private void FRMRecepcionCompras_VisibleChanged(object sender, EventArgs e)
        {
            CargarCB();
        }
        private void CBOrdenCompra_TextChanged(object sender, EventArgs e)
        {
            if (negocios.RevisarDisponibilidad(CBOrdenCompra.Text, "CodOrdenCompra", "ItemOrden WHERE FechaEntrega IS NULL"))
            {
                DataTable dt = negocios.ObtenerTabla("Producto.CodProducto, Tipo, Nombre, StockCompra, StockRecepcion, FechaEntrega, CodFactura", "ItemOrden INNER JOIN Producto ON Producto.CodProducto = ItemOrden.CodProducto", $"CodOrdenCompra = {CBOrdenCompra.Text} AND FechaEntrega IS NULL");
                dt = TraducirTabla(dt);
                dataGridView1.DataSource = dt;

                dt = negocios.ObtenerTabla("FechaCreacion, NumTransaccion, OrdenCompra.CUIT, Nombre, CodFactura", "OrdenCompra INNER JOIN Proveedor ON Proveedor.CUIT = OrdenCompra.CUIT", $"CodOrdenCompra = {CBOrdenCompra.Text}");

                textBox1.Text = dt.Rows[0][0].ToString();
                textBox2.Text = dt.Rows[0][1].ToString();
                textBox3.Text = dt.Rows[0][2].ToString();
                textBox4.Text = dt.Rows[0][3].ToString();
                textBox5.Text = dt.Rows[0][4].ToString();
            }
            else
            {
                dataGridView1.DataSource = null;

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string cantidadRecibida = Microsoft.VisualBasic.Interaction.InputBox(LanguageManager.ObtenerInstancia().ObtenerTexto("FRMRecepcionCompras.Etiquetas.IngresarCantidadRecibida"), LanguageManager.ObtenerInstancia().ObtenerTexto("FRMRecepcionCompras.Etiquetas.CantidadRecibida"));
                string codFactura = Microsoft.VisualBasic.Interaction.InputBox(LanguageManager.ObtenerInstancia().ObtenerTexto("FRMRecepcionCompras.Etiquetas.IngresarCodFactura"), LanguageManager.ObtenerInstancia().ObtenerTexto("FRMRecepcionCompras.Etiquetas.CodFactura"));

                bool ValidarNumero = cantidadRecibida.All(char.IsDigit);

                if (cantidadRecibida.Length >= 11)
                {
                    cantidadRecibida = cantidadRecibida.Substring(0, 11);
                }

                if (codFactura.Length > 30)
                {
                    MessageBox.Show(LanguageManager.ObtenerInstancia().ObtenerTexto("FRMRecepcionCompras.Etiquetas.FacturaLarga"));
                    throw new Exception();
                }

                if (ValidarNumero == false || cantidadRecibida == "" || codFactura == "" || Convert.ToInt64(cantidadRecibida) > 2147483647)
                {
                    MessageBox.Show(LanguageManager.ObtenerInstancia().ObtenerTexto("FRMRecepcionCompras.Etiquetas.NumeroInvalido"));
                    throw new Exception();
                }

                dataGridView1.Rows[e.RowIndex].Cells[4].Value = cantidadRecibida;
                dataGridView1.Rows[e.RowIndex].Cells[5].Value = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff");
                dataGridView1.Rows[e.RowIndex].Cells[6].Value = codFactura;

                dataGridView1.Rows[e.RowIndex].Selected = true;
            }
            catch (Exception) { }
        }

        DataTable TraducirTabla(DataTable dt)
        {
            dt.Columns[0].ColumnName = LanguageManager.ObtenerInstancia().ObtenerTexto("dgv.CodProducto");
            dt.Columns[1].ColumnName = LanguageManager.ObtenerInstancia().ObtenerTexto("dgv.Tipo");
            dt.Columns[2].ColumnName = LanguageManager.ObtenerInstancia().ObtenerTexto("dgv.Nombre");
            dt.Columns[3].ColumnName = LanguageManager.ObtenerInstancia().ObtenerTexto("dgv.StockCompra");
            dt.Columns[4].ColumnName = LanguageManager.ObtenerInstancia().ObtenerTexto("dgv.StockRecepcion");
            dt.Columns[5].ColumnName = LanguageManager.ObtenerInstancia().ObtenerTexto("dgv.FechaEntrega");
            dt.Columns[6].ColumnName = LanguageManager.ObtenerInstancia().ObtenerTexto("dgv.CodFactura");

            return dt;
        }

        void GenerarReportePDF()
        {
            DataTable ProductosCompra = negocios.ObtenerTabla("Producto.CodProducto, Tipo, Nombre, Cotizacion, StockCompra, FechaEntrega, StockRecepcion", "Producto INNER JOIN ItemOrden ON Producto.CodProducto = ItemOrden.CodProducto", $"CodOrdenCompra = {CBOrdenCompra.Text}");

            DataTable dt = negocios.ObtenerTabla("CUIT, RazonSocial, Nombre, Email, NumTelefono, Direccion, CuentaBancaria", "Proveedor", $"CUIT = {textBox3.Text}");
            Proveedor prov = new Proveedor(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), dt.Rows[0][3].ToString(), dt.Rows[0][4].ToString(), dt.Rows[0][5].ToString(), dt.Rows[0][6].ToString());

            dt = negocios.ObtenerTabla("FechaCreacion, PrecioTotal, NumTransaccion, CodFactura", "OrdenCompra", $"CodOrdenCompra = {CBOrdenCompra.Text}");
            OrdenCompra orden = new OrdenCompra(textBox3.Text, Convert.ToDateTime(dt.Rows[0][0]), Convert.ToDouble(dt.Rows[0][1].ToString()), dt.Rows[0][2].ToString(), dt.Rows[0][3].ToString());

            try
            {
                ReportesPDF.ReporteRecepcion(ProductosCompra, CBOrdenCompra.Text, orden, prov);

                NegociosEvento.RegistrarEvento(new Evento(SessionManager.ObtenerInstancia().ObtenerDatosUsuario().Username, DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("HH:mm:ss"), "Ventas", "Generación de reporte de recepción de compras", 5));

                parent.FormBitacoraEventos.Actualizar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FRMRecepcionCompras_Load(object sender, EventArgs e)
        {
            parent = this.MdiParent as FRMUI;
        }
    }
}
