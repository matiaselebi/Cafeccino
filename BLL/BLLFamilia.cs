﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Threading.Tasks;
using DAL;
using BE;
using Servicio;

namespace BLL
{
    public class BLLFamilia
    {
        DALFamilia DatosFamilia = new DALFamilia();
        Datos Datos = new Datos();

        public DataTable ObtenerFamilias()
        {
            try
            {
                DataTable dt;
                dt = Datos.LlenarTabla("*", "Familia", "Tipo = 0");

                if (dt.Rows.Count > 0)
                {
                    dt = dt.AsEnumerable().GroupBy(row => row["CodFamilia"]).Select(group => group.First()).CopyToDataTable();

                    dt.Columns.Cast<DataColumn>().Where(c => c.ColumnName != "Nombre" && c.ColumnName != "CodFamilia").ToList().ForEach(c => dt.Columns.Remove(c));
                }

                return dt;
            }
            catch (Exception) { }

            return null;
        }

        public DataTable ObtenerPerfiles()
        {
            try
            {
                DataTable dt;
                dt = Datos.LlenarTabla("*", "Familia", "Tipo = 1");

                if (dt.Rows.Count > 0)
                {
                    dt = dt.AsEnumerable().GroupBy(row => row["CodFamilia"]).Select(group => group.First()).CopyToDataTable();

                    dt.Columns.Cast<DataColumn>().Where(c => c.ColumnName != "Nombre" && c.ColumnName != "CodFamilia").ToList().ForEach(c => dt.Columns.Remove(c));
                }

                return dt;
            }
            catch (Exception) { }

            return null;
        }

        public int ObtenerSiguienteCodigo()
        {
            bool CodExiste = true;
            int cont = 99;

            while (CodExiste == true)
            {
                cont++;
                CodExiste = Datos.RevisarDisponibilidad(cont.ToString(), "CodFamilia", "Familia");
            }

            return cont;
        }

        public void ActualizarFamilia(TreeNode familia, ComboBox permisos, ComboBox familias, ComboBox familias2)
        {
            string CodFamilia = "";
            string NombreFamilia = "";

            bool TienePermisos = false;

            DataTable dt = familias.DataSource as DataTable;

            foreach (DataRow row in dt.Rows)
            {
                if (row.ItemArray.Length > 1 && row.ItemArray[1].ToString() == familia.Text)
                {
                    CodFamilia = row.ItemArray[0].ToString();
                    NombreFamilia = row.ItemArray[1].ToString();

                    Datos.EliminarRegistro(CodFamilia, "CodFamilia", "Familia");
                }
            }

            dt = permisos.DataSource as DataTable;
            DataTable dt2 = familias2.DataSource as DataTable;

            foreach (TreeNode n in familia.Nodes)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (n.Text == row.ItemArray[1].ToString())
                    {
                        string CodPermiso = row.ItemArray[0].ToString();

                        Datos.EjecutarComando("RegistrarFamilia", $"{CodFamilia}, '{NombreFamilia}', 0, {CodPermiso}, null");

                        TienePermisos = true;
                    }
                }

                foreach (DataRow row in dt2.Rows)
                {
                    if (n.Text == row.ItemArray[1].ToString())
                    {
                        string CodFamilia1 = row.ItemArray[0].ToString();

                        Datos.EjecutarComando("RegistrarFamilia", $"{CodFamilia}, '{NombreFamilia}', 0, null, {CodFamilia1}");

                        TienePermisos = true;
                    }
                }
            }

            if (TienePermisos == false)
            {
                Datos.EjecutarComando("RegistrarFamilia", $"{CodFamilia}, '{NombreFamilia}', 0, null, null");
            }
        }

        public void ActualizarPerfil(TreeNode perfil, ComboBox permisos, ComboBox familias, ComboBox perfiles)
        {
            string CodPerfil = "";
            string NombrePerfil = "";

            bool TienePermisos = false;

            DataTable dt = perfiles.DataSource as DataTable;

            foreach (DataRow row in dt.Rows)
            {
                if (row.ItemArray.Length > 1 && row.ItemArray[1].ToString() == perfil.Text)
                {
                    CodPerfil = row.ItemArray[0].ToString();
                    NombrePerfil = row.ItemArray[1].ToString();

                    Datos.EliminarRegistro(CodPerfil, "CodFamilia", "Familia");
                }
            }

            dt = permisos.DataSource as DataTable;
            DataTable dt2 = familias.DataSource as DataTable;

            foreach (TreeNode n in perfil.Nodes)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (n.Text == row.ItemArray[1].ToString())
                    {
                        string CodPermiso = row.ItemArray[0].ToString();

                        Datos.EjecutarComando("RegistrarFamilia", $"{CodPerfil}, '{NombrePerfil}', 1, {CodPermiso}, null");

                        TienePermisos = true;
                    }
                }

                foreach (DataRow row in dt2.Rows)
                {
                    if (n.Text == row.ItemArray[1].ToString())
                    {
                        string CodFamilia = row.ItemArray[0].ToString();

                        Datos.EjecutarComando("RegistrarFamilia", $"{CodPerfil}, '{NombrePerfil}', 1, null, {CodFamilia}");

                        TienePermisos = true;
                    }
                }
            }

            if (TienePermisos == false)
            {
                Datos.EjecutarComando("RegistrarFamilia", $"{CodPerfil}, '{NombrePerfil}', 1, null, null");
            }
        }

        public DataTable ObtenerPermisosFamilia(string CodFamilia)
        {
            return Datos.LlenarTabla("Permiso.Nombre", "Familia INNER JOIN Permiso ON Familia.CodPermiso = Permiso.CodPermiso", $"CodFamilia = {CodFamilia}");
        }

        public DataTable ObtenerPermisosPorNombreFamilia(string Nombre)
        {
            return Datos.LlenarTabla("Permiso.Nombre", "Familia INNER JOIN Permiso ON Familia.CodPermiso = Permiso.CodPermiso", $"Familia.Nombre = '{Nombre}'");
        }

        public DataTable ObtenerFamiliasPerfil(string CodFamilia)
        {
            return Datos.LlenarTabla("F2.Nombre", "Familia INNER JOIN Familia F2 ON Familia.CodComp = F2.CodFamilia", $"Familia.CodFamilia = {CodFamilia} GROUP BY F2.Nombre");
        }

        public DataTable ObtenerFamiliasPerfilPorNombre(string Nombre)
        {
            return Datos.LlenarTabla("F2.Nombre", "Familia INNER JOIN Familia F2 ON Familia.CodComp = F2.CodFamilia", $"Familia.Nombre = '{Nombre}' GROUP BY F2.Nombre");
        }

        public void CrearComponente(int CodFamilia, string Nombre, bool Tipo)
        {
            Datos.EjecutarComando("RegistrarFamilia", $"{CodFamilia}, '{Nombre}', {Tipo}, null, null");
        }

        public void EliminarRegistro(string ID, string Columna, string Tabla)
        {
            Datos.EliminarRegistro(ID, Columna, Tabla);
        }

        public bool VerificarTipo(string Nombre)
        {
            return DatosFamilia.VerificarTipo(Nombre);
        }
    }
}
