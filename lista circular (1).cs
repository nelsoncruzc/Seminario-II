using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListaCircular1
{
    public class ListaCircular
    {
        class Nodo
        {
            public int info;
            public Nodo ant, sig;
        }

        private Nodo raiz;

        public ListaCircular()
        {
            raiz = null;
        }

        public void InsertarPrimero(int x)
        {
            Nodo nuevo = new Nodo();
            nuevo.info = x;
            if (raiz == null)
            {
                nuevo.sig = nuevo;
                nuevo.ant = nuevo;
                raiz = nuevo;
            }
            else
            {
                Nodo ultimo = raiz.ant;
                nuevo.sig = raiz;
                nuevo.ant = ultimo;
                raiz.ant = nuevo;
                ultimo.sig = nuevo;
                raiz = nuevo;
            }
        }

        public void InsertarUltimo(int x)
        {
            Nodo nuevo = new Nodo();
            nuevo.info = x;
            if (raiz == null)
            {
                nuevo.sig = nuevo;
                nuevo.ant = nuevo;
                raiz = nuevo;
            }
            else
            {
                Nodo ultimo = raiz.ant;
                nuevo.sig = raiz;
                nuevo.ant = ultimo;
                raiz.ant = nuevo;
                ultimo.sig = nuevo;
            }
        }

        public bool Vacia()
        {
            if (raiz == null)
                return true;
            else
                return false;
        }

        public void Imprimir()
        {
            if (!Vacia())
            {
                Nodo reco = raiz;
                do
                {
                    Console.Write(reco.info + "-");
                    reco = reco.sig;
                } while (reco != raiz);
                Console.WriteLine();
            }
        }

        public int Cantidad()
        {
            int cant = 0;
            if (!Vacia())
            {
                Nodo reco = raiz;
                do
                {
                    cant++;
                    reco = reco.sig;
                } while (reco != raiz);
            }
            return cant;
        }

        public void Borrar(int pos)
        {
            if (pos <= Cantidad())
            {
                if (pos == 1)
                {
                    if (Cantidad() == 1)
                    {
                        raiz = null;
                    }
                    else
                    {
                        Nodo ultimo = raiz.ant;
                        raiz = raiz.sig;
                        ultimo.sig = raiz;
                        raiz.ant = ultimo;
                    }
                }
                else
                {
                    Nodo reco = raiz;
                    for (int f = 1; f <= pos - 1; f++)
                        reco = reco.sig;
                    Nodo anterior = reco.ant;
                    reco = reco.sig;
                    anterior.sig = reco;
                    reco.ant = anterior;
                }
            }
        }

        static void Main(string[] args)
        {
            ListaCircular lc=new ListaCircular();
            lc.InsertarPrimero(40);
            lc.InsertarPrimero(30);
            lc.InsertarPrimero(20);
            lc.InsertarPrimero(10);
            Console.WriteLine("Paso 1: Se insertaron 4 nodos al principio");
            lc.Imprimir();
            Console.WriteLine("");
            //Insertado de los 4 primeros nodos
            
            
            
            lc.InsertarUltimo(100);
            lc.InsertarUltimo(200);
            Console.WriteLine("Paso 2: Se le agregaron 2 nodos al final");
            lc.Imprimir();
            Console.WriteLine("La Cantidad de nodos en total son:"+ lc.Cantidad());
            Console.WriteLine("");
            //Agregado de nodos en la posicion final y listado del total de nodos
            
            
            Console.WriteLine("Paso 3: Se borra el nodo de la primera posición");
            lc.Borrar(1);
            lc.Imprimir();
            Console.WriteLine("La Cantidad de nodos en total ahora son:"+ lc.Cantidad());
            Console.WriteLine("");
            //Eliminado de nodo en la posicion inicial y listado del total de nodos
            
            Console.WriteLine("Paso 4: Se borra el nodo de la cuarta posición");
            lc.Borrar(4);
            lc.Imprimir();
            Console.WriteLine("La Cantidad de nodos en total ahora son:"+ lc.Cantidad());
            Console.WriteLine("");
            //Eliminado de nodo en la posicion cuatro y listado del total de nodos
            Console.ReadKey();
        }
    }        
}