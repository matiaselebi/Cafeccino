using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ItemSolicitud
    {
        public int CodProducto;
        public int CodSolicitud;

        public ItemSolicitud(int codProducto, int codSolicitud)
        {
            CodProducto = codProducto;
            CodSolicitud = codSolicitud;
        }
    }
}
