using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ItemOrden
    {
        public int CodProducto;
        public int CodOrdenCompra;
        public double Cotizacion;
        public int StockCompra;
        public int StockRecepcion;
        public DateTime FechaEntrega;
        public string CodFactura;

        public ItemOrden(int codProducto, int codOrdenCompra, double cotizacion, int stockCompra)
        {
            CodProducto = codProducto;
            CodOrdenCompra = codOrdenCompra;
            Cotizacion = cotizacion;
            StockCompra = stockCompra;
        }

        public ItemOrden(int codProducto, int codOrdenCompra, double cotizacion, int stockCompra, int stockRecepcion, DateTime fechaEntrega, string codFactura)
        {
            CodProducto = codProducto;
            CodOrdenCompra = codOrdenCompra;
            Cotizacion = cotizacion;
            StockCompra = stockCompra;
            StockRecepcion = stockRecepcion;
            FechaEntrega = fechaEntrega;
            CodFactura = codFactura;
        }
    }
}
