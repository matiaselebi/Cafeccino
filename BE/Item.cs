using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Item
    {
        public int Cantidad;
        public int CodFactura;
        public int CodProducto;

        public Item(int codFactura, int codProducto, int cantidad)
        {
            Cantidad = cantidad;
            CodFactura = codFactura;
            CodProducto = codProducto;
        }
    }
}
