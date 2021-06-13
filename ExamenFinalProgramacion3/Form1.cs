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
        TablaHash.TablaHashColision TablaHash = new TablaHash.TablaHashColision();

        private void button1_Click(object sender, EventArgs e)
        {
            var reader = new StreamReader(File.OpenRead(@"ListadoEstudiantes.csv"), Encoding.Default);
            try
            {
                var linea0 = reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var linea = reader.ReadLine();
                    var valor = linea.Split(';');

                    Estudiante objEstudiante = new Estudiante(valor[0], valor[1], valor[2], valor[3], valor[4], valor[5], valor[6], valor[7]);
                    miArbolAvl.insertar(objEstudiante);
                }
                MessageBox.Show("DOCUMENTO LEIDO E INSERTADO EN EL ARBOL AVL");
            }
            catch (Exception ex)
            {
                MessageBox.Show("OCURRIO UN ERROR "+ex);
            }
            
           
            
        }


        //---RECORRIDO INORDEN
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                textBox2.Clear();
                textBox3.Clear();
                textBox2.Text = ArbolAvl.ArbolAvl.rcInorden(miArbolAvl.raizArbol());
                
                ArbolAvl.ArbolAvl.recorridoInOrden(miArbolAvl.raizArbol());
                foreach (var item in Program.miTablaInOrden.tabla)
                {
                    if (item != null)
                    {
                        string message = item.MuestraLista().ToString();

                        textBox3.Text = textBox3.Text + message;
                    }
                }
                button2.Enabled = false;
                MessageBox.Show("RECORRIDO INORDEN CORRECTAMENTE");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR EN EL RECORRIDO INORDEN "+ex);
            }
            
        }

        //---RECORRIDO PREORDEN
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                textBox2.Clear();
                textBox3.Clear();
                textBox2.Text = ArbolAvl.ArbolAvl.rcPreorden(miArbolAvl.raizArbol()).ToString();

                ArbolAvl.ArbolAvl.recorridoPreOrden(miArbolAvl.raizArbol());
                foreach (var item in Program.miTablaPreOrden.tabla)
                {
                    if (item != null)
                    {
                        string message = item.MuestraLista().ToString();

                        textBox3.Text = textBox3.Text + message;
                    }
                }
                button3.Enabled = false;
                MessageBox.Show("RECORRIDO PREORDEN CORRECTAMENTE");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR EN EL PREORDEN INORDEN " + ex);
            }
            
        }


        //---RECORRIDO POSTORDEN
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                textBox2.Clear();
                textBox3.Clear();
                textBox2.Text = ArbolAvl.ArbolAvl.rcpostOrden(miArbolAvl.raizArbol()).ToString();

                ArbolAvl.ArbolAvl.recorridoPostOrden(miArbolAvl.raizArbol());
                
                foreach (var item in Program.miTablaPostOrden.tabla)
                {
                    if (item != null)
                    {
                        string message = item.MuestraLista().ToString();

                        textBox3.Text = textBox3.Text + message;
                    }
                }
                button4.Enabled = false;
                MessageBox.Show("RECORRIDO POSTORDEN CORRECTAMENTE");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR EN EL POSTORDEN INORDEN " + ex);
            }
            
        }
    }
}
