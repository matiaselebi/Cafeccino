using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Threading.Tasks;
using DAL;
using BE;
using Servicio;
using System.Diagnostics;

namespace BLL
{
    public class BLLProducto_C
    {
        Datos Data = new Datos();
        Negocios negocios = new Negocios();
        DALProducto_C DataProducto_C = new DALProducto_C();
        BLLEvento NegociosEvento = new BLLEvento();
        BLLDV NegociosDV = new BLLDV();

        public void ActivarEstado(Producto_C lc)
        {
            Data.EjecutarComando("ActualizarEstadoProducto", $"'{lc.CodProducto}', '{lc.Nombre}', '{lc.Tipo}', {lc.Precio}, {lc.Stock}, {lc.MaxStock}, {lc.MinStock}, {lc.Activo}");

            NegociosDV.RecalcularDVTabla("Producto");
            NegociosDV.RecalcularDVTabla("Producto_C");
        }

        public DataTable ObtenerCambios(int? CodProducto, DateTime FechaInicio, DateTime FechaFin, string Nombre, DateTime FechaInicioDefault, DateTime FechaFinDefault)
        {
            DataTable dt;
            if (FechaInicio == FechaInicioDefault && FechaFin == FechaFinDefault && CodProducto == null && Nombre == "")
            {
                dt = negocios.ObtenerTabla("*", "Producto_C", $"CONVERT(date,Fecha) >= '{DateTime.Now.AddMonths(-1).ToString("yyyy-MM-ddTHH:mm:ss.fff")}'");
            }
            else
            {
                dt = negocios.ObtenerTabla("*", "Producto_C", $"CodProducto LIKE '{CodProducto}%' AND CONVERT(date,Fecha) >= '{FechaInicio.ToString("yyyy-MM-ddTHH:mm:ss.fff")}' AND CONVERT(date,Fecha) <= '{FechaFin.ToString("yyyy-MM-ddTHH:mm:ss.fff")}' AND Nombre LIKE '{Nombre}%' ORDER BY CAST(Fecha + ' ' + Hora AS date) DESC");
            }

            dt.Columns[0].ColumnName = LanguageManager.ObtenerInstancia().ObtenerTexto("dgv.CodProducto");
            dt.Columns[1].ColumnName = LanguageManager.ObtenerInstancia().ObtenerTexto("dgv.Fecha");
            dt.Columns[2].ColumnName = LanguageManager.ObtenerInstancia().ObtenerTexto("dgv.Hora");
            dt.Columns[3].ColumnName = LanguageManager.ObtenerInstancia().ObtenerTexto("dgv.Tipo");
            dt.Columns[4].ColumnName = LanguageManager.ObtenerInstancia().ObtenerTexto("dgv.Nombre");
            dt.Columns[5].ColumnName = LanguageManager.ObtenerInstancia().ObtenerTexto("dgv.Precio");
            dt.Columns[6].ColumnName = LanguageManager.ObtenerInstancia().ObtenerTexto("dgv.Stock");
            dt.Columns[7].ColumnName = LanguageManager.ObtenerInstancia().ObtenerTexto("dgv.EstadoActual");
            dt.Columns[8].ColumnName = LanguageManager.ObtenerInstancia().ObtenerTexto("dgv.MaxStock");
            dt.Columns[9].ColumnName = LanguageManager.ObtenerInstancia().ObtenerTexto("dgv.MinStock");
            return dt;
        }

        public void ValidarFechas(DateTime FechaInicial, DateTime FechaFinal)
        {
            if (FechaInicial > DateTime.Now)
            {
                throw new Exception(LanguageManager.ObtenerInstancia().ObtenerTexto("FRMBitacoraCambios.Etiquetas.FechaMayorActual"));
            }
            else if (FechaInicial > FechaFinal)
            {
                throw new Exception(LanguageManager.ObtenerInstancia().ObtenerTexto("FRMBitacoraCambios.Etiquetas.FechaMayorFinal"));
            }
        }

        public void ActivarProducto_C(int CodProducto, string Fecha, string Hora, string Tipo, string Nombre, int Precio, int Stock, bool EstadoActual, int MaxStock, int MinStock, bool Activo)
        {
            if (EstadoActual)
            {
                throw new Exception(LanguageManager.ObtenerInstancia().ObtenerTexto("FRMBitacoraCambios.Etiquetas.EstadoEnUso"));
            }
            else
            {
                //NegociosProducto_C.ActivarEstado(new Producto_C(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString(), dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString(), dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString(), dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[3].Value.ToString(), dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString(), Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[5].Value), Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[6].Value)));
                //ActivarEstado(new Producto_C("'" + CodProducto + "'", "'" + Fecha + "'", "'" + Hora + "'", "'" + Tipo + "'", "'" + Nombre + "'", Precio, Stock));
                ActivarEstado(new Producto_C(CodProducto, Fecha, Hora, Tipo, Nombre, Precio, Stock, MaxStock, MinStock, Activo));

                NegociosEvento.RegistrarEvento(new Evento(SessionManager.ObtenerInstancia().ObtenerDatosUsuario().Username, DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("HH:mm:ss"), "Productos", "Actualización de estado de producto", 4));
            }
        }
    }
}
