using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio
{
    public class Producto_C
    {
        public int CodProducto;
        public string Fecha;
        public string Hora;
        public string Tipo;
        public string Nombre;
        public int Precio;
        public int Stock;
        public int MaxStock;
        public int MinStock;
        public bool Activo;

        public Producto_C(int codProducto, string fecha, string hora, string tipo, string nombre, int precio, int stock, int maxStock, int minStock, bool activo)
        {
            CodProducto = codProducto;
            Fecha = fecha;
            Hora = hora;
            Tipo = tipo;
            Nombre = nombre;
            Precio = precio;
            Stock = stock;
            MaxStock = maxStock;
            MinStock = minStock;
            Activo = activo;
        }
    }
}
