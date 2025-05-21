﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Servicio;
using BLL;

namespace Cafeccinoo
{
    public partial class FRMReporteInteligente : Form, IObserver
    {
        Negocios negocios = new Negocios();
        DataTable dt = null;
        public FRMReporteInteligente()
        {
            InitializeComponent();
        }
        public void ActualizarIdioma()
        {
            LanguageManager.ObtenerInstancia().CambiarIdiomaControles(this);
        }

        private void FRMReporteInteligente_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
        private void BTNGenerarReporte_Click(object sender, EventArgs e)
        {
            try
            {
                ReportesPDF.ReporteInteligente(dt, comboBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    dt = negocios.ObtenerTablaConsulta("SELECT Tipo, COUNT(i.CodProducto) AS TotalProductosVendidos, SUM(f.PrecioTotal) AS TotalDineroGenerado FROM Producto l INNER JOIN Item i ON l.CodProducto = i.CodProducto INNER JOIN Factura f ON i.CodFactura = f.CodFactura GROUP BY Tipo ORDER BY TotalDineroGenerado DESC");
                    break;
                case 1:
                    dt = negocios.ObtenerTablaConsulta("SELECT CodProducto, Nombre, Stock, MinStock FROM Producto WHERE Stock < MinStock");
                    break;
                case 2:
                    dt = negocios.ObtenerTablaConsulta("SELECT c.Nombre, c.Email, MAX(f.Fecha) AS UltimaCompra FROM Cliente c LEFT JOIN Factura f ON c.DNI = f.DNI GROUP BY c.Nombre, c.Email HAVING MAX(f.Fecha) < DATEADD(MONTH, -6, GETDATE())");
                    break;
                case 3:
                    dt = negocios.ObtenerTablaConsulta("SELECT l.Nombre AS Producto, SUM(i.Cantidad) AS TotalProductosVendidos FROM Producto l LEFT JOIN Item i ON l.CodProducto = i.CodProducto GROUP BY l.Nombre ORDER BY TotalProductosVendidos ASC");
                    break;
                case 4:
                    dt = negocios.ObtenerTablaConsulta("SELECT c.Nombre, c.Apellido, SUM(f.PrecioTotal) AS TotalDineroGastado FROM Cliente c INNER JOIN Factura f ON c.DNI = f.DNI GROUP BY c.Nombre, c.Apellido ORDER BY TotalDineroGastado DESC");
                    break;
                case 5:
                    dt = negocios.ObtenerTablaConsulta("SELECT io.CodOrdenCompra, AVG(l.Precio) AS PromedioPrecio FROM ItemOrden io INNER JOIN Producto l ON io.CodProducto = l.CodProducto GROUP BY io.CodOrdenCompra");
                    break;
                case 6:
                    dt = negocios.ObtenerTablaConsulta("SELECT p.RazonSocial, COUNT(ps.CodSolicitud) AS TotalSolicitudes FROM Proveedor p INNER JOIN ProveedorSolicitud ps ON p.CUIT = ps.CUIT GROUP BY p.RazonSocial ORDER BY TotalSolicitudes DESC");
                    break;
                case 7:
                    dt = negocios.ObtenerTablaConsulta("SELECT p.RazonSocial, COUNT(oc.CodOrdenCompra) AS TotalOrdenes FROM Proveedor p INNER JOIN OrdenCompra oc ON p.CUIT = oc.CUIT GROUP BY p.RazonSocial ORDER BY TotalOrdenes DESC;");
                    break;
                case 8:
                    dt = negocios.ObtenerTablaConsulta("SELECT oc.CodOrdenCompra, p.CUIT, p.RazonSocial FROM OrdenCompra oc INNER JOIN ItemOrden io ON io.CodOrdenCompra = oc.CodOrdenCompra INNER JOIN Proveedor p ON p.CUIT = oc.CUIT WHERE io.FechaEntrega IS NULL GROUP BY oc.CodOrdenCompra, p.CUIT, p.RazonSocial");
                    break;
                case 9:
                    dt = negocios.ObtenerTablaConsulta("WITH VentasRecientes AS (SELECT i.Producto, SUM(i.Cantidad) AS VentasUltimos3Meses FROM Factura f INNER JOIN Item i ON f.CodFactura = i.CodFactura WHERE f.Fecha >= DATEADD(MONTH, -3, GETDATE())GROUP BY i.CodProducto), StockFuturo AS (SELECT l.CodProducto, l.Nombre AS Producto, l.Stock - vr.VentasUltimos3Meses AS StockEstimado, l.MinStock FROM  Producto l LEFT JOIN VentasRecientes vr ON l.CodProducto = vr.CodProducto) SELECT Producto, StockEstimado, MinStock, CASE WHEN StockEstimado < MinStock THEN 'Crítico' ELSE 'Suficiente' END AS EstadoStock FROM StockFuturo ORDER BY StockEstimado ASC;");
                    break;
                case 10:
                    dt = negocios.ObtenerTablaConsulta("WITH VentasRecientes AS ( SELECT l.Producto, l.Nombre AS Producto, SUM(i.Cantidad) AS TotalVendidos, SUM(i.Cantidad * l.Precio) AS IngresoReciente FROM Producto l INNER JOIN Item i ON l.CodProducto = i.CodProducto INNER JOIN Factura f ON i.CodFactura = f.CodFactura WHERE f.Fecha >= DATEADD(MONTH, -6, GETDATE()) GROUP BY l.CodProducto, l.Nombre, l.Precio ), PromedioVentas AS ( SELECT CodProducto, Producto, IngresoReciente / 6 AS PromedioMensual FROM VentasRecientes ) SELECT Producto, PromedioMensual, CASE WHEN PromedioMensual > 5000 THEN 'Alta probabilidad de rentabilidad' ELSE 'Probabilidad moderada' END AS Prediccion FROM PromedioVentas ORDER BY PromedioMensual DESC;");
                    break;
                case 11:
                    dt = negocios.ObtenerTablaConsulta("WITH MetodosPago AS ( SELECT f.MetodoPago, COUNT(f.CodFactura) AS TotalUsos, COUNT(f.CodFactura) * 1.0 / SUM(COUNT(f.CodFactura)) OVER () AS PorcentajeUso FROM Factura f WHERE f.Fecha >= DATEADD(MONTH, -6, GETDATE()) GROUP BY f.MetodoPago ) SELECT MetodoPago, PorcentajeUso * 100 AS ProbabilidadUsoFuturo FROM MetodosPago ORDER BY ProbabilidadUsoFuturo DESC;");
                    break;
                case 12:
                    dt = negocios.ObtenerTablaConsulta("WITH VentasPorMes AS ( SELECT YEAR(f.Fecha) AS Anio, MONTH(f.Fecha) AS Mes, SUM(f.PrecioTotal) AS VentasTotales FROM Factura f GROUP BY YEAR(f.Fecha), MONTH(f.Fecha) ), PromedioVentasMensuales AS ( SELECT Mes, AVG(VentasTotales) AS PromedioMensual FROM VentasPorMes GROUP BY Mes ) SELECT Mes, PromedioMensual, CASE WHEN PromedioMensual > (SELECT AVG(PromedioMensual) FROM PromedioVentasMensuales) THEN 'Alta demanda' ELSE 'Demanda normal' END AS Prediccion FROM PromedioVentasMensuales ORDER BY PromedioMensual DESC;");
                    break;
                default:
                    dt = null;
                    dataGridView1.DataSource = null;
                    break;

                    //PARA COPIAR Y AGREGAR NUEVOS REPORTES
                    //case :
                    //    dt = negocios.ObtenerTablaConsulta("");
                    //    break;
            }

            dt = TraducirTabla(dt);
            dataGridView1.DataSource = dt;
        }
        DataTable TraducirTabla(DataTable dt)
        {
            foreach (DataColumn c in dt.Columns)
            {
                c.ColumnName = LanguageManager.ObtenerInstancia().ObtenerTexto($"dgv.{c.ColumnName}");
            }

            return dt;
        }
    }
}
