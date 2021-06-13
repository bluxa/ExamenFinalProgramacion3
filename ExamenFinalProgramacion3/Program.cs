using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamenFinalProgramacion3
{
    static class Program
    {
        public static TablaHash.TablaHashColision miTablaInOrden = new TablaHash.TablaHashColision();
        public static TablaHash.TablaHashColision miTablaPostOrden = new TablaHash.TablaHashColision();
        public static TablaHash.TablaHashColision miTablaPreOrden = new TablaHash.TablaHashColision();
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
