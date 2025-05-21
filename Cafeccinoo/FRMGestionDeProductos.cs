﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Servicio;
using BE;
using BLL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Cafeccinoo
{
    public partial class FRMGestionDeProductos : Form, IObserver
    {
        Negocios negocios = new Negocios();
        BLLProducto NegociosProducto = new BLLProducto();
        BLLEvento NegociosEvento = new BLLEvento();

        public FRMGestionDeProductos()
        {
            InitializeComponent();
            LanguageManager.ObtenerInstancia().Agregar(this);
        }
        public void ActualizarIdioma()
        {
            LanguageManager.ObtenerInstancia().CambiarIdiomaControles(this);

            RefrescarGrilla();

            if (BTNAñadir.Enabled == false)
            {
                textBox8.Text = LanguageManager.ObtenerInstancia().ObtenerTexto("Etiquetas.ModoAñadir");
            }
            else if (BTNModificar.Enabled == false)
            {
                textBox8.Text = LanguageManager.ObtenerInstancia().ObtenerTexto("Etiquetas.ModoModificar");
            }
            else if (BTNEliminar.Enabled == false)
            {
                textBox8.Text = LanguageManager.ObtenerInstancia().ObtenerTexto("Etiquetas.ModoEliminar");
            }
            else
            {
                textBox8.Text = LanguageManager.ObtenerInstancia().ObtenerTexto("Etiquetas.ModoConsulta");
            }
        }
        public void RefrescarGrilla()
        {
            if (ObtenerCondicionesQuery().Length > 5)
            {
                DataTable dt = negocios.ObtenerTabla("CodProducto, Tipo, Nombre, Precio, Stock, Activo, MaxStock, MinStock", "Producto", ObtenerCondicionesQuery());
                dt = TraducirTabla(dt);
                dataGridView1.DataSource = dt;
            }
            else
            {
                DataTable dt = negocios.ObtenerTabla("CodProducto, Tipo, Nombre, Precio, Stock, Activo, MaxStock, MinStock", "Producto");
                dt = TraducirTabla(dt);
                dataGridView1.DataSource = dt;
            }

            ContarProductos();
        }
        private void FRMGestionDeProductos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }

            LimpiarCampos();

            DataTable dt = negocios.ObtenerTabla("CodProducto, Tipo, Nombre, Precio, Stock, Activo, MaxStock, MinStock", "Producto");
            dt = TraducirTabla(dt);
            dataGridView1.DataSource = dt;
        }

        private void FRMGestionDeProductos_VisibleChanged(object sender, EventArgs e)
        {
            DataTable dt = negocios.ObtenerTabla("CodProducto, Tipo, Nombre, Precio, Stock, Activo, MaxStock, MinStock", "Producto");
            dt = TraducirTabla(dt);
            dataGridView1.DataSource = dt;

            ContarProductos();
            LimpiarCampos();
        }
        private void BTNAñadir_Click(object sender, EventArgs e)
        {
            ActivarBotones(BTNAñadir, LanguageManager.ObtenerInstancia().ObtenerTexto("Etiquetas.ModoAñadir"));
        }

        private void BTNModificar_Click(object sender, EventArgs e)
        {
            ActivarBotones(BTNModificar, LanguageManager.ObtenerInstancia().ObtenerTexto("Etiquetas.ModoModificar"));
        }

        private void BTNEliminar_Click(object sender, EventArgs e)
        {
            ActivarBotones(BTNEliminar, LanguageManager.ObtenerInstancia().ObtenerTexto("Etiquetas.ModoEliminar"));
        }

        private void BTNAplicar_Click(object sender, EventArgs e)
        {
            if (textBox8.Text == LanguageManager.ObtenerInstancia().ObtenerTexto("Etiquetas.ModoConsulta"))
            {
                NegociosEvento.RegistrarEvento(new Evento(SessionManager.ObtenerInstancia().ObtenerDatosUsuario().Username, DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("HH:mm:ss"), "Productos", "Consulta de productos", 6));
            }

            if (textBox8.Text == LanguageManager.ObtenerInstancia().ObtenerTexto("Etiquetas.ModoAñadir"))
            {
                if (ValidarCampos() == true)
                {
                    Producto book = new Producto(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text, Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value), Convert.ToInt32(numericUpDown3.Value), Convert.ToInt32(numericUpDown4.Value));

                    NegociosProducto.RegistrarProducto(book);

                    NegociosEvento.RegistrarEvento(new Evento(SessionManager.ObtenerInstancia().ObtenerDatosUsuario().Username, DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("HH:mm:ss"), "Productos", "Registro de producto", 4));

                    MessageBox.Show(LanguageManager.ObtenerInstancia().ObtenerTexto("FRMGestionDeProductos.Etiquetas.ProductoRegistrado"));

                    ActivarBotones(BTNCancelar, LanguageManager.ObtenerInstancia().ObtenerTexto("Etiquetas.ModoConsulta"));

                    LimpiarCampos();
                }
            }

            if (textBox8.Text == LanguageManager.ObtenerInstancia().ObtenerTexto("Etiquetas.ModoModificar"))
            {
                if (ValidarCampos() == true)
                {
                    Producto book = new Producto(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text, Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value), Convert.ToInt32(numericUpDown3.Value), Convert.ToInt32(numericUpDown4.Value));

                    NegociosProducto.ModificarProducto(book);

                    NegociosEvento.RegistrarEvento(new Evento(SessionManager.ObtenerInstancia().ObtenerDatosUsuario().Username, DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("HH:mm:ss"), "Productos", "Modificación de producto", 4));

                    MessageBox.Show(LanguageManager.ObtenerInstancia().ObtenerTexto("FRMGestionDeProductos.Etiquetas.ProductoModificado"));

                    ActivarBotones(BTNCancelar, LanguageManager.ObtenerInstancia().ObtenerTexto("Etiquetas.ModoConsulta"));

                    LimpiarCampos();
                }
            }

            if (textBox8.Text == LanguageManager.ObtenerInstancia().ObtenerTexto("Etiquetas.ModoEliminar"))
            {
                if (negocios.RevisarDisponibilidad(textBox1.Text, "CodProducto", "Producto") == false)
                {
                    MessageBox.Show(LanguageManager.ObtenerInstancia().ObtenerTexto("FRMGestionDeProductos.Etiquetas.CodproductoNoExiste"));
                }
                else if (NegociosProducto.RevisarDesactivado(Convert.ToInt32(textBox1.Text)) == false)
                {
                    NegociosProducto.ActivarProducto(Convert.ToInt32(textBox1.Text));
                    NegociosEvento.RegistrarEvento(new Evento(SessionManager.ObtenerInstancia().ObtenerDatosUsuario().Username, DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("HH:mm:ss"), "Productos", "Restauración de producto", 4));
                    MessageBox.Show(LanguageManager.ObtenerInstancia().ObtenerTexto("FRMGestionDeProductos.Etiquetas.ProductoRestaurado"));
                    ActivarBotones(BTNCancelar, LanguageManager.ObtenerInstancia().ObtenerTexto("Etiquetas.ModoConsulta"));
                    LimpiarCampos();
                }
                else
                {
                    NegociosProducto.DesactivarProducto(Convert.ToInt32(textBox1.Text));

                    NegociosEvento.RegistrarEvento(new Evento(SessionManager.ObtenerInstancia().ObtenerDatosUsuario().Username, DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("HH:mm:ss"), "Productos", "Borrado lógico de producto", 4));

                    MessageBox.Show(LanguageManager.ObtenerInstancia().ObtenerTexto("FRMGestionDeProductos.Etiquetas.ProductoEliminado"));

                    ActivarBotones(BTNCancelar, LanguageManager.ObtenerInstancia().ObtenerTexto("Etiquetas.ModoConsulta"));

                    LimpiarCampos();
                }
            }

            FRMUI parent = this.MdiParent as FRMUI;
            parent.FormBitacoraEventos.Actualizar();
            parent.FormBitacoraCambios.Actualizar();

            if (ObtenerCondicionesQuery().Length > 5)
            {
                DataTable dt = negocios.ObtenerTabla("CodProducto, Tipo, Nombre, Precio, Stock, Activo, MaxStock, MinStock", "Producto", ObtenerCondicionesQuery()); ;
                dt = TraducirTabla(dt);
                dataGridView1.DataSource = dt;
            }
            else
            {
                DataTable dt = negocios.ObtenerTabla("CodProducto, Tipo, Nombre, Precio, Stock, Activo, MaxStock, MinStock", "Producto"); ;
                dt = TraducirTabla(dt);
                dataGridView1.DataSource = dt;
            }

            ContarProductos();
        }

        private void BTNCancelar_Click(object sender, EventArgs e)
        {
            ActivarBotones(BTNCancelar, LanguageManager.ObtenerInstancia().ObtenerTexto("Etiquetas.ModoConsulta"));
        }
        private string ObtenerCondicionesQuery()
        {
            //Esta función devuelve las condiciones para el WHERE de la consulta de productos

            string c = "";

            if (checkBox1.Checked == true)
            {
                c += "CodProducto = '" + textBox1.Text + "' AND ";
            }

            if (checkBox2.Checked == true)
            {
                c += "Tipo = '" + textBox2.Text + "' AND ";
            }

            if (checkBox3.Checked == true)
            {
                c += "Nombre = '" + textBox3.Text + "' AND ";
            }

            if (checkBox4.Checked == true)
            {
                c += "Precio = " + numericUpDown1.Value.ToString() + " AND ";
            }

            if (checkBox5.Checked == true)
            {
                c += "Stock = " + numericUpDown2.Value.ToString() + " AND ";
            }

            if (checkBox6.Checked == true)
            {
                c += "MaxStock = " + numericUpDown3.Value.ToString() + " AND ";
            }

            if (checkBox7.Checked == true)
            {
                c += "MinStock = " + numericUpDown4.Value.ToString() + " AND ";
            }

            if (checkBox8.Checked == true)
            {
                c += "Activo = '" + checkBox12.Checked.ToString() + "' AND ";
            }

            if (c.Length > 5)
            {
                c = c.Substring(0, c.Length - 5);
            }

            return c;
        }
        private void ActivarBotones(Button b, string modo)
        {
            //Este método hace que al seleccionar un modo el botón correspondiente quede inactivo y el resto de botones queden activos.

            textBox8.Text = modo;
            BTNAñadir.Enabled = true;
            BTNModificar.Enabled = true;
            BTNEliminar.Enabled = true;
            BTNCancelar.Enabled = true;

            b.Enabled = false;

            LimpiarCampos();

            if (modo == LanguageManager.ObtenerInstancia().ObtenerTexto("Etiquetas.ModoConsulta"))
            {
                foreach (System.Windows.Forms.CheckBox cb in this.Controls.OfType<System.Windows.Forms.CheckBox>())
                {
                    cb.Enabled = true;
                }
            }
            else
            {
                foreach (System.Windows.Forms.CheckBox cb in this.Controls.OfType<System.Windows.Forms.CheckBox>())
                {
                    cb.Enabled = false;
                }
            }

            if (modo == LanguageManager.ObtenerInstancia().ObtenerTexto("Etiquetas.ModoEliminar"))
            {
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
            }
            else
            {
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = true;
                numericUpDown3.Enabled = true;
                numericUpDown4.Enabled = true;
            }

            if (modo == LanguageManager.ObtenerInstancia().ObtenerTexto("Etiquetas.ModoModificar"))
            {
                numericUpDown2.Enabled = false;
            }
        }

        private void LimpiarCampos()
        {
            //Reinicia todos los campos del formulario

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            numericUpDown1.Value = numericUpDown1.Minimum;
            numericUpDown2.Value = numericUpDown2.Minimum;
            numericUpDown3.Value = numericUpDown3.Minimum;
            numericUpDown4.Value = numericUpDown4.Minimum;

            foreach (System.Windows.Forms.CheckBox cb in this.Controls.OfType<System.Windows.Forms.CheckBox>())
            {
                cb.Checked = false;
            }
        }

        private bool ValidarCampos()
        {
            //Valida todos los campos para verificar que los datos ingresados son válidos (Se usa al añadir y modificar productos)

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show(LanguageManager.ObtenerInstancia().ObtenerTexto("FRMGestionDeProductos.Etiquetas.LlenarCampos"));
            }
            else if (textBox1.Text.All(char.IsDigit) == false)
            {
                MessageBox.Show(LanguageManager.ObtenerInstancia().ObtenerTexto("FRMGestionDeProductos.Etiquetas.SoloNumeros"));
            }
            else if (negocios.RevisarDisponibilidad(textBox1.Text, "CodProducto", "Producto") && textBox8.Text == LanguageManager.ObtenerInstancia().ObtenerTexto("Etiquetas.ModoAñadir"))
            {
                MessageBox.Show(LanguageManager.ObtenerInstancia().ObtenerTexto("FRMGestionDeProductos.Etiquetas.YaRegistrado"));
            }
            else if (negocios.RevisarDisponibilidad(textBox1.Text, "CodProducto", "Producto") == false && textBox8.Text != LanguageManager.ObtenerInstancia().ObtenerTexto("Etiquetas.ModoAñadir"))
            {
                MessageBox.Show(LanguageManager.ObtenerInstancia().ObtenerTexto("FRMGestionDeProductos.Etiquetas.CodproductoNoExiste"));
            }
            else if (numericUpDown3.Value < numericUpDown4.Value)
            {
                MessageBox.Show(LanguageManager.ObtenerInstancia().ObtenerTexto("FRMGestionDeProductos.Etiquetas.StockMaxInvalido"));
            }
            else
            {
                return true;
            }

            return false;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                numericUpDown1.Value = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                numericUpDown2.Value = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
                numericUpDown3.Value = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[6].Value);
                numericUpDown4.Value = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[7].Value);

                dataGridView1.Rows[e.RowIndex].Selected = true;
            }
            catch (Exception)
            {

            }
        }
        private void ContarProductos()
        {
            int cont = 0;
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    cont++;

                    if (Convert.ToInt32(row.Cells[5].Value) == 0)
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(LanguageManager.ObtenerInstancia().ObtenerTexto("FRMGestionDeProductos.Etiquetas.ErrorConteo"));
            }

            label4.Text = cont.ToString();
        }

        DataTable TraducirTabla(DataTable dt)
        {
            dt.Columns[0].ColumnName = LanguageManager.ObtenerInstancia().ObtenerTexto("dgv.CodProducto");
            dt.Columns[1].ColumnName = LanguageManager.ObtenerInstancia().ObtenerTexto("dgv.Tipo");
            dt.Columns[2].ColumnName = LanguageManager.ObtenerInstancia().ObtenerTexto("dgv.Nombre");
            dt.Columns[3].ColumnName = LanguageManager.ObtenerInstancia().ObtenerTexto("dgv.Precio");
            dt.Columns[4].ColumnName = LanguageManager.ObtenerInstancia().ObtenerTexto("dgv.Stock");
            dt.Columns[5].ColumnName = LanguageManager.ObtenerInstancia().ObtenerTexto("dgv.Activo");
            dt.Columns[6].ColumnName = LanguageManager.ObtenerInstancia().ObtenerTexto("dgv.MaxStock");
            dt.Columns[7].ColumnName = LanguageManager.ObtenerInstancia().ObtenerTexto("dgv.MinStock");

            return dt;
        }
    }
}
