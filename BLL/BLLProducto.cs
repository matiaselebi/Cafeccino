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


namespace BLL
{
    public class BLLProducto
    {
        Datos Data = new Datos();
        Negocios negocios = new Negocios();
        DALProducto DataProducto = new DALProducto();
        BLLDV NegociosDV = new BLLDV();

        public void RegistrarProducto(Producto Product)
        {
            Data.EjecutarComando("InsertarProducto", $"'{Product.CodProducto}', '{Product.Nombre}', '{Product.Tipo}', {Product.Precio}, {Product.Stock}, {Product.StockMaximo}, {Product.StockMinimo}");

            NegociosDV.RecalcularDVTabla("Producto");
            NegociosDV.RecalcularDVTabla("Producto_C");
        }

        public void ModificarProducto(Producto Product)
        {
            Data.EjecutarComando("InsertarProducto", $"'{Product.CodProducto}', '{Product.Nombre}', '{Product.Tipo}', {Product.Precio}, {Product.Stock}, {Product.StockMaximo}, {Product.StockMinimo}");

            NegociosDV.RecalcularDVTabla("Producto");
            NegociosDV.RecalcularDVTabla("Producto_C");
        }

        public void DesactivarProducto(int CodProducto)
        {
            DataProducto.DesactivacionProducto(CodProducto, 0);

            NegociosDV.RecalcularDVTabla("Producto");
            NegociosDV.RecalcularDVTabla("Producto_C");
        }

        public void ActivarProducto(int CodProducto)
        {
            DataProducto.DesactivacionProducto(CodProducto, 1);

            NegociosDV.RecalcularDVTabla("Producto");
            NegociosDV.RecalcularDVTabla("Producto_C");
        }

        public bool RevisarDesactivado(int CodProducto)
        {
            return DataProducto.RevisarDesactivado(CodProducto, "CodProducto, Activo");
        }

        public void ValidarProductoParaVenta(string Cantidad, int Stock)
        {
            bool ValidarNumero = Cantidad.All(char.IsDigit);

            if (Cantidad.Length >= 11)
            {
                Cantidad = Cantidad.Substring(0, 11);
            }

            if (ValidarNumero == false || Cantidad == "" || Convert.ToInt64(Cantidad) > 2147483647)
            {
                throw new Exception(LanguageManager.ObtenerInstancia().ObtenerTexto("FRMSeleccionarProductos.Etiquetas.NumeroInvalido"));
            }
            else if (Convert.ToInt32(Stock) < Convert.ToInt32(Cantidad))
            {
                throw new Exception(LanguageManager.ObtenerInstancia().ObtenerTexto("FRMSeleccionarProductos.Etiquetas.SinStock"));
            }
        }

        public DataTable ActualizarTablaSeleccion()
        {
            DataTable dt = negocios.ObtenerTabla("*", "Producto", "Activo = 1");

            dt.Columns[0].ColumnName = LanguageManager.ObtenerInstancia().ObtenerTexto("dgv.CodProducto", dt);
            dt.Columns[1].ColumnName = LanguageManager.ObtenerInstancia().ObtenerTexto("dgv.Nombre", dt);
            dt.Columns[2].ColumnName = LanguageManager.ObtenerInstancia().ObtenerTexto("dgv.Tipo", dt);
            dt.Columns[3].ColumnName = LanguageManager.ObtenerInstancia().ObtenerTexto("dgv.Precio", dt);
            dt.Columns[4].ColumnName = LanguageManager.ObtenerInstancia().ObtenerTexto("dgv.Stock", dt);
            dt.Columns[5].ColumnName = LanguageManager.ObtenerInstancia().ObtenerTexto("dgv.Activo", dt);
            dt.Columns[6].ColumnName = LanguageManager.ObtenerInstancia().ObtenerTexto("dgv.MaxStock", dt);
            dt.Columns[7].ColumnName = LanguageManager.ObtenerInstancia().ObtenerTexto("dgv.MinStock", dt);

            return dt;
        }
    }
}
