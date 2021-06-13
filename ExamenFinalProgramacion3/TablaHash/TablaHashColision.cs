using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenFinalProgramacion3.TablaHash.ListaEnlazada;

namespace ExamenFinalProgramacion3.TablaHash
{
    public class TablaHashColision
    {
        public static readonly int M = 99;
        public static readonly double R = 0.618034;
        int Posicion;
        public int cont { get; set; }

        public ListaEnlazada.ListaEnlazada[] tabla = new ListaEnlazada.ListaEnlazada[M];


        public int DispersionMod(String Clave)
        {
            double x;
            x = Convert.ToDouble(Clave.Substring(0, 4));
            return Convert.ToInt16(x % M);
        }

        public void Insertar(Object Dato, String Clave)
        {
            Posicion = DispersionMod(Clave);
            if (tabla[Posicion] == null)
            {
                tabla[Posicion] = new ListaEnlazada.ListaEnlazada();
            }
            tabla[Posicion].insertarCabezaLista(Dato);
            cont++;
        }

        public void Eliminar(String Clave)
        {
            Posicion = DispersionMod(Clave);
            tabla[Posicion] = null;
        }

        public object Buscar(String Clave)
        {
            Posicion = DispersionMod(Clave);

            if (tabla[Posicion] == null)
                return null;
            else
                return tabla[Posicion].BuscarNodo(Clave);
        }

       
                
    }
}
