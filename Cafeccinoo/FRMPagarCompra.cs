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
    public partial class FRMPagarCompra : Form, IObserver
    {
        Negocios negocios = new Negocios();
        public FRMPagarCompra()
        {
            InitializeComponent();
            LanguageManager.ObtenerInstancia().Agregar(this);
        }
        public void ActualizarIdioma()
        {
            LanguageManager.ObtenerInstancia().CambiarIdiomaControles(this);
        }

        private void FRMPagarCompra_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void BTNPagar_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show(LanguageManager.ObtenerInstancia().ObtenerTexto("FRMPagarCompra.Etiquetas.LlenarCampos"));
            }
            else if (!textBox2.Text.All(char.IsDigit))
            {
                MessageBox.Show(LanguageManager.ObtenerInstancia().ObtenerTexto("FRMPagarCompra.Etiquetas.SoloNumeros"));
            }
            else if (negocios.RevisarDisponibilidad(textBox2.Text, "NumTransaccion", "OrdenCompra"))
            {
                MessageBox.Show(LanguageManager.ObtenerInstancia().ObtenerTexto("FRMPagarCompra.Etiquetas.NumTransaccionEnUso"));
            }
            else if (negocios.RevisarDisponibilidad(textBox4.Text, "CodFactura", "OrdenCompra"))
            {
                MessageBox.Show(LanguageManager.ObtenerInstancia().ObtenerTexto("FRMPagarCompra.Etiquetas.CodFacturaEnUso"));
            }
            else
            {
                FRMUI parent = this.MdiParent as FRMUI;
                parent.FormOrdenCompra.orden.NumTransaccion = textBox2.Text;
                parent.FormOrdenCompra.orden.CodFactura = textBox4.Text;

                MessageBox.Show(LanguageManager.ObtenerInstancia().ObtenerTexto("FRMPagarCompra.Etiquetas.ConformacionPago"));

                this.Hide();
            }
        }
        private void FRMPagarCompra_VisibleChanged(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox4.Text = "";
        }
    }
}
