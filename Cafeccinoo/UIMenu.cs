using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BE;
using Servicio;

namespace Cafeccinoo
{
    internal static class UIMenu
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            SessionManager.ObtenerInstancia().IdiomaActual = "Español";
            Application.Run(new FRMUI());
        }
    }
}
