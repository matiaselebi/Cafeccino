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
using BE;
using BLL;

namespace Cafeccinoo
{
    public partial class FRMCerrarSesion : Form, IObserver
    {
        BLLUsuario NegociosUsuario = new BLLUsuario();
        public FRMCerrarSesion()
        {
            InitializeComponent();
            LanguageManager.ObtenerInstancia().Agregar(this);
        }

        public void ActualizarIdioma()
        {
            LanguageManager.ObtenerInstancia().CambiarIdiomaControles(this);
        }
        private void FRMCerrarSesion_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
        private void FRMCerrarSesion_Load(object sender, EventArgs e)
        {

        }

        private void BTNConfirmar_Click(object sender, EventArgs e)
        {
            NegociosUsuario.CerrarSesion();

            ModificarMenu();

            MessageBox.Show(LanguageManager.ObtenerInstancia().ObtenerTexto("FRMCerrarSesion.Etiquetas.SesionCerrada"));

            Hide();
        }

        private void BTNCancelar_Click(object sender, EventArgs e)
        {
            Hide();
            
        }
        public void ModificarMenu()
        {
            FRMUI parent = this.MdiParent as FRMUI;

            foreach (ToolStripMenuItem itemMenu in parent.menuStrip1.Items)
            {
                itemMenu.Visible = false;

                foreach (ToolStripItem subItem in itemMenu.DropDownItems)
                {
                    if (subItem is ToolStripMenuItem)
                    {
                        subItem.Visible = false;
                    }
                }
            }

            parent.nombreToolStripMenuItem.Visible = true;
            parent.usuarioToolStripMenuItem.Visible = true;
            parent.ayudaToolStripMenuItem.Visible = true;

            parent.iniciarSesiónToolStripMenuItem.Visible = true;
            parent.cambiarIdiomaToolStripMenuItem.Visible = true;

            parent.usuarioToolStripMenuItem1.Visible = true;
            parent.iniciarSesionToolStripMenuItem.Visible = true;
            parent.cambiarIdiomaToolStripMenuItem1.Visible = true;

            //parent.nombreToolStripMenuItem.Text = LanguageManager.ObtenerInstancia().ObtenerTexto("FRMCerrarSesion.Etiquetas.SinSesionIniciada");

            Console.WriteLine("Actualizando texto del ToolStripMenuItem");
            LanguageManager.ObtenerInstancia().CargarIdioma();
            parent.nombreToolStripMenuItem.Text = LanguageManager.ObtenerInstancia().ObtenerTexto("FRMCerrarSesion.Etiquetas.SinSesionIniciada");
            Console.WriteLine($"Texto actualizado: {parent.nombreToolStripMenuItem.Text}"); // Mensaje de depuración

            foreach (Form frm in Application.OpenForms.Cast<Form>().ToArray())
            {
                if (!(frm is FRMUI))
                {
                    frm.Hide();
                }
            }
        }
    }
}
