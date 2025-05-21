﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class SolicitudCotizacion
    {
        public DateTime FechaEmision;
        public List<ItemSolicitud> Items = new List<ItemSolicitud>();
        public List<Proveedor> Proveedores = new List<Proveedor>();

        public SolicitudCotizacion(DateTime fechaEmision)
        {
            FechaEmision = fechaEmision;
        }
    }
}
