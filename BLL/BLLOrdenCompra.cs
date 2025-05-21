﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class BLLOrdenCompra
    {
        Datos Data = new Datos();
        DALOrdenCompra DatosOrdenCompra = new DALOrdenCompra();
        BLLDV NegociosDV = new BLLDV();

        public void RegistrarOrdenCompra(OrdenCompra orden)
        {
            Data.EjecutarComando("InsertarOrdenCompra", $"'{orden.CUIT}', '{orden.FechaCreacion.ToString("yyyy-MM-ddTHH:mm:ss.fff")}', {orden.PrecioTotal.ToString(System.Globalization.CultureInfo.InvariantCulture)}, '{orden.NumTransaccion}', '{orden.CodFactura}'");

            NegociosDV.RecalcularDVTabla("OrdenCompra");
        }

        public int ObtenerCodOrdenCompra()
        {
            return DatosOrdenCompra.ObtenerCodOrdenCompra();
        }

        public void RegistrarItems(OrdenCompra orden)
        {
            foreach (var item in orden.Items)
            {
                Data.EjecutarComando("RegistrarItemOrden", $"'{item.CodProducto}', {item.CodOrdenCompra}, {item.Cotizacion}, {item.StockCompra}");
            }

            NegociosDV.RecalcularDVTabla("ItemOrden");
        }

        public void RecibirProducto(int CodProducto, int StockRecepcion, DateTime FechaEntrega, string CodFactura)
        {
            Data.EjecutarComando("RecibirProducto", $"'{CodProducto}', {StockRecepcion}, '{FechaEntrega.ToString("yyyy-MM-ddTHH:mm:ss.fff")}', '{CodFactura}'");

            NegociosDV.RecalcularDVTabla("ItemOrden");
            NegociosDV.RecalcularDVTabla("Producto");
            NegociosDV.RecalcularDVTabla("Producto_C");
        }
    }
}
