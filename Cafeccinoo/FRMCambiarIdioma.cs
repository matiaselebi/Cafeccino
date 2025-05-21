using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Servicio;

namespace Cafeccinoo
{
    public partial class FRMCambiarIdioma : Form, IObserver
    {
        public FRMCambiarIdioma()
        {
            InitializeComponent();
            LanguageManager.ObtenerInstancia().Agregar(this);
        }

        public void ActualizarIdioma()
        {
            LanguageManager.ObtenerInstancia().CambiarIdiomaControles(this);
        }

        private void FRMCambiarIdioma_Load(object sender, EventArgs e)
        {

        }

        private void BTNCambiarIdioma_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                SessionManager.ObtenerInstancia().IdiomaActual = comboBox1.Text;
                MessageBox.Show(LanguageManager.ObtenerInstancia().ObtenerTexto("FRMCambiarIdioma.Etiquetas.IdiomaCambiado") + comboBox1.Text);
                this.Hide();
            }
            else
            {
                MessageBox.Show(LanguageManager.ObtenerInstancia().ObtenerTexto("FRMCambiarIdioma.Etiquetas.SeleccionarIdioma"));
            }
        }
        private void FRMCambiarIdioma_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }

            comboBox1.SelectedItem = null;
        }
        private void FRMCambiarIdioma_VisibleChanged_1(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = null;
        }
    }
}
