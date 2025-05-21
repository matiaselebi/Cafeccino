using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;

namespace DAL
{
    public static class Conexion
    {
        //public static string cadena = ConfigurationManager.ConnectionStrings["cadena_conexion"].ConnectionString;
        public static string cadena = @"Data Source=.;Initial Catalog=Cafeccino;Integrated Security=True";
    }
}
