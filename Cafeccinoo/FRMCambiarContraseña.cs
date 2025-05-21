using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Servicio;
using BE;
using BLL;

namespace Cafeccinoo
{
    public partial class FRMCambiarContraseña : Form, IObserver
    {
        bool MostrarContraseña1 = false;
        bool MostrarContraseña2 = false;
        bool MostrarContraseña3 = false;
        BLLUsuario NegociosUsuario = new BLLUsuario();
        BLLEvento NegociosEvento = new BLLEvento();
        CryptoManager Encriptar = new CryptoManager();

        public FRMCambiarContraseña()
        {
            InitializeComponent();
            LanguageManager.ObtenerInstancia().Agregar(this);
        }
        public void ActualizarIdioma()
        {
            LanguageManager.ObtenerInstancia().CambiarIdiomaControles(this);
        }

        private void FRMCambiarContraseña_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }

            VaciarCampos();
        }
        private void VaciarCampos()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            pictureBox1.BackgroundImage = Properties.Resources._441052332573ef178f06755d5d93ef94;
            MostrarContraseña1 = false;
            textBox2.PasswordChar = '*';

            pictureBox2.BackgroundImage = Properties.Resources._441052332573ef178f06755d5d93ef94;
            MostrarContraseña2 = false;
            textBox3.PasswordChar = '*';

            pictureBox3.BackgroundImage = Properties.Resources._441052332573ef178f06755d5d93ef94;
            MostrarContraseña3 = false;
            textBox4.PasswordChar = '*';
        }

        private void FRMCambiarContraseña_Load(object sender, EventArgs e)
        {

        }

        private void BTNCambiarContraseña_Click(object sender, EventArgs e)
        {
            try
            {
                NegociosUsuario.CambiarContraseñaPropia(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);

                MessageBox.Show(LanguageManager.ObtenerInstancia().ObtenerTexto("FRMCambiarContraseña.Etiquetas.Exito"));

                ModificarMenu();

                this.Hide();

                VaciarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MostrarContraseña1 == false)
            {
                pictureBox1.BackgroundImage = Properties.Resources._425bd415577a278e49f19c19843d20b2;
                MostrarContraseña1 = true;
                textBox2.PasswordChar = '\0';
            }
            else
            {
                pictureBox1.BackgroundImage = Properties.Resources._441052332573ef178f06755d5d93ef94;
                MostrarContraseña1 = false;
                textBox2.PasswordChar = '*';
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (MostrarContraseña2 == false)
            {
                pictureBox2.BackgroundImage = Properties.Resources._425bd415577a278e49f19c19843d20b2;
                MostrarContraseña2 = true;
                textBox3.PasswordChar = '\0';
            }
            else
            {
                pictureBox2.BackgroundImage = Properties.Resources._441052332573ef178f06755d5d93ef94;
                MostrarContraseña2 = false;
                textBox3.PasswordChar = '*';
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (MostrarContraseña3 == false)
            {
                pictureBox3.BackgroundImage = Properties.Resources._425bd415577a278e49f19c19843d20b2;
                MostrarContraseña3 = true;
                textBox4.PasswordChar = '\0';
            }
            else
            {
                pictureBox3.BackgroundImage = Properties.Resources._441052332573ef178f06755d5d93ef94;
                MostrarContraseña3 = false;
                textBox4.PasswordChar = '*';
            }
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

            parent.nombreToolStripMenuItem.Text = LanguageManager.ObtenerInstancia().ObtenerTexto("FRMCambiarContraseña.Etiquetas.SinSesionIniciada");

            foreach (Form frm in Application.OpenForms.Cast<Form>().ToArray())
            {
                if (!(frm is FRMUI))
                {
                    frm.Hide();
                }
            }
        }
        private void FRMCambiarContraseña_VisibleChanged_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            pictureBox1.BackgroundImage = Properties.Resources._441052332573ef178f06755d5d93ef94;
            MostrarContraseña1 = false;
            textBox2.PasswordChar = '*';

            pictureBox2.BackgroundImage = Properties.Resources._441052332573ef178f06755d5d93ef94;
            MostrarContraseña2 = false;
            textBox3.PasswordChar = '*';

            pictureBox3.BackgroundImage = Properties.Resources._441052332573ef178f06755d5d93ef94;
            MostrarContraseña3 = false;
            textBox4.PasswordChar = '*';
        }
    }
}
