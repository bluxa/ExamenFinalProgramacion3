using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenFinalProgramacion3.ArbolAvl
{
    public class ArbolBinario
    {
        protected Nodo arbolRaiz;

        public ArbolBinario()
        {
            arbolRaiz = null;
        }
        //Estos metodos nos serviran para comprobar si la raiz
        //esta vacia, o si quieremos devolver la raiz

        public ArbolBinario(Nodo raiz) { arbolRaiz = raiz; }
        public Nodo raizArbol() { return arbolRaiz; }
        public bool rabolVacio() { return arbolRaiz == null; }

        //Aca creamos nuestro arbol con los  parametros de un arbol raiz , izquierda, derecha
        public static Nodo nuevoArbol(Nodo ramaIzq, object datoRaiz, Nodo ramaDho)
        {
            return new Nodo(ramaIzq, datoRaiz, ramaDho);
        }

        //En la parte de los recorridos el inorden es esencial para mostrar o recorrer el arbol

        public static string rcInorden(Nodo r)
        {
            if (r != null)
            {
                return rcInorden(r.subarbolIzq()) + r.visitarNodo() + rcInorden(r.subarbolDch());

            }
            return "";
        }

        public static string rcpostOrden(Nodo r)
        {
            if (r != null)
            {
                return rcpostOrden(r.subarbolIzq()) + rcpostOrden(r.subarbolDch()) + r.visitarNodo();

            }
            return "";
        }

        public static string rcPreorden(Nodo r)
        {
            if (r != null)
            {
                return r.visitarNodo() + rcPreorden(r.subarbolIzq()) + rcPreorden(r.subarbolDch());


            }
            return "";
        }

        public static string rcpostOrdens(Nodo r)
        {
            if (r != null)
            {
                return rcpostOrdens(r.subarbolIzq()) + rcpostOrdens(r.subarbolDch()) + r.visitarNodo();

            }
            return "";
        }


        public static void recorridoInOrden(Nodo r)
        {
            if (r != null)
            {
                recorridoInOrden(r.subarbolIzq());
                Estudiante miUsuario = (Estudiante)r.valorNodo();
                Program.miTablaInOrden.Insertar(miUsuario, Convert.ToString(converId(miUsuario.Id)));
                recorridoInOrden(r.subarbolDch());
            }
        }
        public static void recorridoPreOrden(Nodo r)
        {
            if (r != null)
            {
                Estudiante miUsuario = (Estudiante)r.valorNodo();
                Program.miTablaPreOrden.Insertar(miUsuario, Convert.ToString(converId(miUsuario.Id)));
                recorridoPreOrden(r.subarbolIzq());
                recorridoPreOrden(r.subarbolDch());
            }
        }

        public static void recorridoPostOrden(Nodo r)
        {
            if (r != null)
            {
                recorridoPostOrden(r.subarbolIzq());
                recorridoPostOrden(r.subarbolDch());
                Estudiante miUsuario = (Estudiante)r.valorNodo();
                Program.miTablaPostOrden.Insertar(miUsuario, Convert.ToString(converId(miUsuario.Id)));
            }
        }

        public static string converId(string user)
        {
            byte[] asscInt = Encoding.ASCII.GetBytes(user);
            string cadena = "";
            foreach (byte item in asscInt)
            {
                cadena = cadena + item;
            }
            return cadena;
        }




    }
}
