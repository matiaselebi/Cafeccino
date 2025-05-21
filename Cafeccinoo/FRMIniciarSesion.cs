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

    public partial class FRMIniciarSesion : Form, IObserver
    {
        BLLUsuario NegociosUsuario = new BLLUsuario();
        BLLFamilia NegociosFamilia = new BLLFamilia();

        bool MostrarContraseña = false;

        public FRMIniciarSesion()
        {
            InitializeComponent();
            LanguageManager.ObtenerInstancia().Agregar(this);
            
            textBox1.Text = "mati";
            textBox2.Text = "aaaa1111";
        }
        public void ActualizarIdioma()
        {
            LanguageManager.ObtenerInstancia().CambiarIdiomaControles(this);
        }

        void VaciarCampos()
        {
            textBox1.Text = "";
            textBox2.Text = "";

            pictureBox.BackgroundImage = Properties.Resources._441052332573ef178f06755d5d93ef94;
            MostrarContraseña = false;
            textBox2.PasswordChar = '*';
        }

        private void BTNIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                NegociosUsuario.IniciarSesion(textBox1.Text, textBox2.Text);

                Usuario user = NegociosUsuario.ObtenerUsuario(textBox1.Text);

                MessageBox.Show(LanguageManager.ObtenerInstancia().ObtenerTexto("FRMIniciarSesion.Etiquetas.LogIn") + user.Rol);

                ModificarMenu(user.Rol, user.Nombre + " " + user.Apellido);

                this.Hide();
                VaciarCampos();
            }
            catch (Exception ex)
            {
                if (ex is TaskCanceledException)
                {
                    if (SessionManager.ObtenerInstancia().ObtenerDatosUsuario().Rol == "Admin")
                    {
                        FRMUI parent = this.MdiParent as FRMUI;
                        parent.FormReparacionBD.TablaError = ex.Message;
                        parent.FormReparacionBD.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("FRMIniciarSesion.Etiquetas.SistemaNoDisponible");
                    }
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void ModificarMenu(string rol, string nombre)
        {
            FRMUI parent = this.MdiParent as FRMUI;

            foreach (ToolStripMenuItem itemMenu in parent.menuStrip1.Items)
            {
                foreach (ToolStripItem subItem in itemMenu.DropDownItems)
                {
                    if (subItem is ToolStripMenuItem)
                    {
                        subItem.Visible = false;

                        ToolStripMenuItem si = subItem as ToolStripMenuItem;

                        foreach (ToolStripItem subSubItem in si.DropDownItems)
                        {
                            if (subSubItem is ToolStripMenuItem)
                            {
                                subSubItem.Visible = false;
                            }
                        }
                    }
                }
            }

            parent.cambiarIdiomaToolStripMenuItem.Visible = true;
            parent.cerrarSesiónToolStripMenuItem.Visible = true;
            parent.cambiarContraseñaToolStripMenuItem.Visible = true;

            parent.usuarioToolStripMenuItem1.Visible = true;
            parent.iniciarSesionToolStripMenuItem.Visible = true;
            parent.cambiarIdiomaToolStripMenuItem1.Visible = true;
            parent.cerrarSesionToolStripMenuItem.Visible = true;
            parent.cambiarContraseñaToolStripMenuItem1.Visible = true;
            parent.manualDeUsuarioToolStripMenuItem.Visible = true;

            foreach (DataRow dr in NegociosFamilia.ObtenerPermisosPorNombreFamilia(rol).Rows)
            {
                OtorgarVisibilidad(parent.menuStrip1.Items, dr[0].ToString(), parent);
            }

            foreach (DataRow dr in NegociosFamilia.ObtenerFamiliasPerfilPorNombre(rol).Rows)
            {
                foreach (DataRow dr2 in NegociosFamilia.ObtenerPermisosPorNombreFamilia(dr[0].ToString()).Rows)
                {
                    OtorgarVisibilidad(parent.menuStrip1.Items, dr2[0].ToString(), parent);
                }

                MostrarPermisosSubFamilias(dr);
            }

            parent.nombreToolStripMenuItem.Text = nombre;
        }

        private void MostrarPermisosSubFamilias(DataRow dr1)
        {
            FRMUI parent = this.MdiParent as FRMUI;

            foreach (DataRow dr in NegociosFamilia.ObtenerFamiliasPerfilPorNombre(dr1[0].ToString()).Rows)
            {
                foreach (DataRow dr2 in NegociosFamilia.ObtenerPermisosPorNombreFamilia(dr[0].ToString()).Rows)
                {
                    OtorgarVisibilidad(parent.menuStrip1.Items, dr2[0].ToString(), parent);
                }

                MostrarPermisosSubFamilias(dr);
            }
        }

        public void OtorgarVisibilidad(ToolStripItemCollection items, string NombrePermiso, FRMUI parent)
        {
            foreach (ToolStripMenuItem item in items)
            {
                if (item.Name == (NombrePermiso + "ToolStripMenuItem") || item.Name == (NombrePermiso + "ToolStripMenuItem1"))
                {
                    item.Visible = true;
                    item.OwnerItem.Visible = true;
                }
                OtorgarVisibilidad(item.DropDownItems, NombrePermiso, parent);
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            if (MostrarContraseña == false)
            {
                pictureBox.BackgroundImage = Properties.Resources._425bd415577a278e49f19c19843d20b2;
                MostrarContraseña = true;
                textBox2.PasswordChar = '\0';
            }
            else
            {
                pictureBox.BackgroundImage = Properties.Resources._441052332573ef178f06755d5d93ef94;
                MostrarContraseña = false;
                textBox2.PasswordChar = '*';
            }
        }

        private void Iniciar_Sesion_Load(object sender, EventArgs e)
        {

        }

        private void FRMIniciarSesion_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }

            VaciarCampos();
        }
    }
}
