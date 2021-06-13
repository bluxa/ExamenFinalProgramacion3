using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenFinalProgramacion3.ArbolAvl
{
    public class ArbolAvl : ArbolBinario
    {
        protected NodoAvl arbolRaiz;

        public int factorEquilibrio { get; set; }

        
        public ArbolAvl()
        {
            arbolRaiz = null;
        }

        public NodoAvl raizArbol()
        {
            return arbolRaiz;
        }

        private NodoAvl rotacionII(NodoAvl n, NodoAvl n1)
        {
            n.ramaIzq(n1.subarbolDch());
            n1.ramaDch(n);
            // Verifica que que el arbol este en equilibrio
            if (n1.fe == -1) // de ser asi se cumplira esta funcion
            {
                n.fe = 0;
                n1.fe = 0;
            }
            else
            {
                n.fe = -1;//De lo contrario hara una rotacion izquierda izquierda
                n1.fe = 1;
            }
            return n1;
        }


        private NodoAvl rotacionDD(NodoAvl n, NodoAvl n1)
        {
            n.ramaDch(n1.subarbolIzq());
            n1.ramaIzq(n);
            // Verifica que que el arbol este en equilibrio
            if (n1.fe == +1) // de ser asi se cumplira esta funcion
            {
                n.fe = 0;
                n1.fe = 0;
            }
            else
            {
                n.fe = +1;//De lo contrario hara una rotacion derecha,derecha
                n1.fe = -1;
            }
            return n1;
        }


        private NodoAvl rotacionID(NodoAvl n, NodoAvl n1)
        {
            NodoAvl n2;
            n2 = (NodoAvl)n1.subarbolDch();
            n.ramaIzq(n2.subarbolDch());
            n2.ramaDch(n);
            n1.ramaDch(n2.subarbolIzq());
            n2.ramaIzq(n1);
            // Se actualizan para la equilibracion
            if (n2.fe == +1)
                n1.fe = -1;
            else
                n1.fe = 0;
            if (n2.fe == -1)
                n.fe = 1;
            else
                n.fe = 0;
            n2.fe = 0;
            return n2;
        }


        private NodoAvl rotacionDI(NodoAvl n, NodoAvl n1)
        {
            NodoAvl n2;
            n2 = (NodoAvl)n1.subarbolIzq();
            n.ramaDch(n2.subarbolIzq());
            n2.ramaIzq(n);
            n1.ramaIzq(n2.subarbolDch());
            n2.ramaDch(n1);
            // factores de equilibrio en actualizacion
            if (n2.fe == +1)
                n.fe = -1;
            else
                n.fe = 0;
            if (n2.fe == -1)
                n1.fe = 1;
            else
                n1.fe = 0;
            n2.fe = 0;
            return n2;
        }


        public void insertar(Object valor)
        {
            InterfazComparador dato;
            Logical h = new Logical(false); // Aca utlizamos la clase logical y for defecto falso
            dato = (InterfazComparador)valor;//El comprador que nos ayudara a comprar datos del arbol
            arbolRaiz = insertarAvl(arbolRaiz, dato, h);//metodo recursivo para la insercion de los datos
        }

        private NodoAvl insertarAvl(NodoAvl raiz, InterfazComparador dt, Logical h)
        {
            NodoAvl n1;
            if (raiz == null)
            {
                raiz = new NodoAvl(dt);
                h.enviarLogica(true);
            }

            else if (dt.UsuarioMenor(raiz.valorNodo()))
            {
                NodoAvl iz;
                iz = insertarAvl((NodoAvl)raiz.subarbolIzq(), dt, h);
                raiz.ramaIzq(iz);
                //De verificar la rama izquierda en donde se insertara el nodo
                if (h.valorLogico())//obtiene un dato para verificar si hay datos
                {
                    switch (raiz.fe)
                    {
                        case 1:
                            raiz.fe = 0;
                            factorEquilibrio = 0;
                            //archivoPlano.vitacoraArbol(factorEquilibrio, "Raiz", raiz);

                            h.enviarLogica(false);
                            break;
                        case 0:
                            raiz.fe = -1;
                            factorEquilibrio = -1;
                            //archivoPlano.vitacoraArbol(factorEquilibrio, "Se inserta en la izquierda", raiz);
                            break;
                        case -1: // aplicar rotación a la izquierda
                            n1 = (NodoAvl)raiz.subarbolIzq();
                            if (n1.fe == -1)
                            {
                                factorEquilibrio = -2;
                                raiz = rotacionII(raiz, n1);
                                //archivoPlano.vitacoraArbol(factorEquilibrio, "Rotacion Izquierda Izquierda", raiz);

                            }
                            else
                            {
                                raiz = rotacionID(raiz, n1);
                                //archivoPlano.vitacoraArbol(factorEquilibrio, "Rotacion Izquierda Derecha", raiz);

                                h.enviarLogica(false);
                            }
                            break;
                    }
                }
            }
            else if (dt.UsuarioMayor(raiz.valorNodo()))
            {
                NodoAvl dr;
                dr = insertarAvl((NodoAvl)raiz.subarbolDch(), dt, h);
                raiz.ramaDch(dr);

                if (h.valorLogico())
                {
                    switch (raiz.fe)
                    {
                        case 1: // aplicar rotación a la derecha
                            n1 = (NodoAvl)raiz.subarbolDch();
                            if (n1.fe == +1)
                            {
                                factorEquilibrio = 2;
                                raiz = rotacionDD(raiz, n1);
                                //archivoPlano.vitacoraArbol(factorEquilibrio, " Rotacion derecha derecha", raiz);

                            }
                            else
                            {
                                raiz = rotacionDI(raiz, n1);
                                //archivoPlano.vitacoraArbol(factorEquilibrio, " Rotacion derecha izquierda", raiz);
                                h.enviarLogica(false);
                            }
                            break;
                        case 0:
                            raiz.fe = +1;
                            factorEquilibrio = 1;
                            //archivoPlano.vitacoraArbol(factorEquilibrio, "Hacia la Derecha", raiz);
                            break;
                        case -1:
                            raiz.fe = 0;
                            factorEquilibrio = 0;
                            //archivoPlano.vitacoraArbol(factorEquilibrio, "Equilibrado", raiz);
                            h.enviarLogica(false);
                            break;
                    }
                }
            }
            return raiz;
        }

        
    }
}
