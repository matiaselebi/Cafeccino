using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BE;
using Servicio;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Cafeccinoo
{
    public partial class FRMBitacoraEventos : Form, IObserver
    {
        BLLUsuario NegociosUsuario = new BLLUsuario();
        BLLEvento NegociosEvento = new BLLEvento();
        Negocios negocios = new Negocios();
        FRMUI parent;

        Dictionary<string, string> dict = new Dictionary<string, string>();
        public FRMBitacoraEventos()
        {
            InitializeComponent();
            dict = NegociosEvento.CrearDiccionarioTraducido();
            LanguageManager.ObtenerInstancia().Agregar(this);
        }
        public void ActualizarIdioma()
        {
            LanguageManager.ObtenerInstancia().CambiarIdiomaControles(this);

            dict = NegociosEvento.CrearDiccionarioTraducido();
            LlenarCombobox();
            Actualizar();

            CBLogin.Text = "";
        }

        private void VaciarCampos()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            CBLogin.Text = "";
            CBModulo.Text = "";
            CBEvento.Text = "";
            CBCriticidad.Text = "";
            dateTimePicker1.Value = dateTimePicker1.MinDate;
            dateTimePicker2.Value = dateTimePicker2.MinDate;
        }

        private void FRMBitacoraEventos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox1.Text = NegociosUsuario.ObtenerUsuario(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()).Nombre;
                textBox2.Text = NegociosUsuario.ObtenerUsuario(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()).Apellido;

                dataGridView1.Rows[e.RowIndex].Selected = true;
            }
            catch (Exception) { }
        }
        public void Actualizar()
        {
            //DataTable dt = NegociosEvento.FiltrarDatos(dateTimePicker1.Value, dateTimePicker2.Value, dateTimePicker1.MinDate, dateTimePicker2.MinDate, CBCriticidad.Text, CBEvento.SelectedValue, CBLogin.Text, CBModulo.SelectedValue);

            //foreach (DataRow dr in dt.Rows)
            //{
            //    try
            //    {
            //        dr[4] = dict[dr[4].ToString()];
            //        dr[5] = dict[dr[5].ToString()];
            //    }
            //    catch (Exception ex) { throw ex; }
            //}

            //dataGridView1.DataSource = dt;
            DataTable dt = NegociosEvento.FiltrarDatos(dateTimePicker1.Value, dateTimePicker2.Value, dateTimePicker1.MinDate, dateTimePicker2.MinDate, CBCriticidad.Text, CBEvento.SelectedValue, CBLogin.Text, CBModulo.SelectedValue);

            foreach (DataRow dr in dt.Rows)
            {
                // Manejar columna 4
                string claveCol4 = dr[4]?.ToString() ?? "default"; // Evitar null
                if (dict.TryGetValue(claveCol4, out string valorTraducido4))
                {
                    dr[4] = valorTraducido4;
                }
                else
                {
                    dr[4] = "Sin traducción"; // Valor por defecto
                }

                // Manejar columna 5
                string claveCol5 = dr[5]?.ToString() ?? "default"; // Evitar null
                if (dict.TryGetValue(claveCol5, out string valorTraducido5))
                {
                    dr[5] = valorTraducido5;
                }
                else
                {
                    dr[5] = "Sin traducción";
                }
            }

            dataGridView1.DataSource = dt;
        }

        public void LlenarCombobox()
        {
            //Logins de usuarios
            CBLogin.DataSource = negocios.ObtenerTabla("Username", "Usuario");
            CBLogin.DisplayMember = "Username";
            CBLogin.ValueMember = "Username";

            //Modulos traducidos
            CBModulo.DataSource = NegociosEvento.ObtenerModulos();
            CBModulo.DisplayMember = "Display";
            CBModulo.ValueMember = "ValorReal";
        }

        private void BTNLimpiar_Click(object sender, EventArgs e)
        {
            VaciarCampos();
            Actualizar();
        }

        private void CBLogin_TextChanged(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void CBModulo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CBEvento.DataSource = NegociosEvento.ObtenerEventos(CBModulo.SelectedValue.ToString());
                CBEvento.DisplayMember = "Display";
                CBEvento.ValueMember = "ValorReal";
            }
            catch (Exception)
            {
                CBEvento.DataSource = null;
            }

            Actualizar();
        }

        private void CBEvento_TextChanged(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void CBCriticidad_TextChanged(object sender, EventArgs e)
        {
            Actualizar();
        }
        private void ValidarFechas()
        {
            try
            {
                NegociosEvento.ValidarFechas(dateTimePicker1.Value, dateTimePicker2.Value);

                Actualizar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                dataGridView1.DataSource = null;
            }
        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            ValidarFechas();
        }

        private void dateTimePicker2_CloseUp(object sender, EventArgs e)
        {
            ValidarFechas();
        }

        private void BTNImprimir_Click(object sender, EventArgs e)
        {
            FRMUI parent = this.MdiParent as FRMUI;

            try
            {
                DataTable dt = negocios.ObtenerTabla("DNI, Username, (Nombre + ' ' + Apellido), Rol, FechaNac, Email, NumTelefono", "Usuario", $"Username = '{dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value}'");

                ReportesPDF.ReporteEvento(dataGridView1.Rows.Count, NegociosEvento.FiltrarDatos(dateTimePicker1.Value, dateTimePicker2.Value, dateTimePicker1.MinDate, dateTimePicker2.MinDate, CBCriticidad.Text, CBEvento.SelectedValue, CBLogin.Text, CBModulo.SelectedValue), dt);

                NegociosEvento.RegistrarEvento(new Evento(SessionManager.ObtenerInstancia().ObtenerDatosUsuario().Username, DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("HH:mm:ss"), "Ventas", "Generación de reporte de factura de venta", 5));

                Actualizar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FRMBitacoraEventos_VisibleChanged(object sender, EventArgs e)
        {
            LlenarCombobox();
            VaciarCampos();
            Actualizar();
        }

        private void FRMBitacoraEventos_Load(object sender, EventArgs e)
        {
            parent = this.MdiParent as FRMUI;
        }
    }
}
