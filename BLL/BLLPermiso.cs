using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using BE;
using DAL;
using Servicio;

namespace BLL
{
    public class BLLPermiso
    {
        DALFamilia DatosPerfil = new DALFamilia();
        Datos Datos = new Datos();

        public DataTable ObtenerPermisos()
        {
            return Datos.LlenarTabla("CodPermiso, Nombre", "Permiso");
        }
    }
}
