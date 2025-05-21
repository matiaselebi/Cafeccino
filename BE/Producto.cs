using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Producto
    {
        public int CodProducto;
        public string Nombre;
        public string Tipo;
        public int Precio;
        public int Stock;
        public int StockMaximo;
        public int StockMinimo;

        public Producto(int codProducto, string nombre, string tipo, int precio, int stock, int stockMaximo, int stockMinimo)
        {
            CodProducto = codProducto;
            Nombre = nombre;
            Tipo = tipo;
            Precio = precio;
            Stock = stock;
            StockMaximo = stockMaximo;
            StockMinimo = stockMinimo;
        }
    }
}
