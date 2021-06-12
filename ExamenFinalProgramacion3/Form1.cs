using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExamenFinalProgramacion3.ArbolAvl;

namespace ExamenFinalProgramacion3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ArbolAvl.ArbolAvl miArbolAvl = new ArbolAvl.ArbolAvl();


        private void button1_Click(object sender, EventArgs e)
        {
            var reader = new StreamReader(File.OpenRead(@"ListadoEstudiantes.csv"));
            //List<string> listA = new List<string>();
            //List<string> listB = new List<string>();
            var linea0 = reader.ReadLine();
            while (!reader.EndOfStream)
            {
                var linea = reader.ReadLine();
                var valor = linea.Split(';');

                //listA.Add(values[0]);
                //listB.Add(values[1]);
                Estudiante objEstudiante = new Estudiante(valor[0], valor[1], valor[2], valor[3], valor[4], valor[5], valor[6], valor[7]);
                miArbolAvl.insertar(objEstudiante);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ArbolAvl.ArbolAvl.rcInorden(miArbolAvl.raizArbol()).ToString());
        }
    }
}
