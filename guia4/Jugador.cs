using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace guia4
{
    internal class Jugador
    {
        public readonly string nombre;
        private int posicion;
        private int posicionAnt;
        private int avance;
        private TipoElemento elementoAfectado;
        static private Random rnd = new Random();

        public Jugador(string nombre)
        {
            this.nombre = nombre;
        }

        public void ModificarPosicion(TipoElemento elemen, int pos)
        {
            elementoAfectado = elemen;
            posicion = pos;
        }

        public TipoElemento ElementoAfectado
        {
            get { return elementoAfectado; }
        }

        public int Posicion {
            get{ return posicion; }
        }

        public int PosicionAnt
        {
            get { return posicionAnt; }
        }

        public int Dado
        {
            get { return avance; }
        }

        public int Mover()
        {
            int dado =  rnd.Next(1,7);
            avance = dado;
            return avance;
        }

        public int Avanzar()
        {
            posicionAnt = posicion;
            posicion += avance;
            return posicion;
        }
    }
}
