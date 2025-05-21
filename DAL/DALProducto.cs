using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DAL
{
    public class DALProducto
    {
        private readonly string _cadenaConexion = Conexion.cadena;
        private Datos Data = new Datos();

        public bool RevisarDesactivado(int CodProducto, string Columnas)
        {
            DataTable dt = Data.LlenarTabla(Columnas, "Producto");

            foreach (DataRow row in dt.Rows)
            {
                if (Convert.ToInt32(row[0]) == CodProducto)
                {
                    return Convert.ToBoolean(row[1]);
                }
            }
            return false;
        }

        public void DesactivacionProducto(int CodProducto, int Activo)
        {
            using (SqlConnection conexion = new SqlConnection(_cadenaConexion))
            {
                string query = "SELECT CodProducto, Activo FROM Producto";
                SqlDataAdapter da = new SqlDataAdapter(query, conexion);
                SqlCommandBuilder builder = new SqlCommandBuilder(da); 

                DataTable dt = new DataTable();
                da.Fill(dt); 

                DataRow[] fila = dt.Select($"CodProducto = {CodProducto}");
                if (fila.Length > 0)
                {
                    fila[0]["Activo"] = Activo; 
                    da.Update(dt); 
                }
            }
        }
    }
}
