using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace guia4
{
    public enum TipoElemento
    {
        Escalera,Serpiente
    }

    internal class Elemento
    {
        private TipoElemento tipo;
        private int posInit;
        private int posFinal;
        private Random rnd;
        public Elemento(TipoElemento tipo)
        {
            this.tipo = tipo;
            if (tipo == TipoElemento.Serpiente)
                IniciarComoSerpiente();
            else if (tipo == TipoElemento.Escalera)
                IniciarComoEscalera();
        }

        public Elemento(TipoElemento tipo,int posI,int posF)
        {
            this.tipo = tipo;
            posInit = posI; posFinal = posF;
        }

        public int Evaluar(Jugador jugador)
        {
            if (tipo == TipoElemento.Serpiente)
            {
                if (posFinal == jugador.Posicion) return posInit;
            }
            else
            {
                if (posInit == jugador.Posicion) return posFinal;
            }
            return jugador.Posicion;
        }

        private void IniciarComoSerpiente()
        {
            rnd = new Random();
            int num = rnd.Next(1, 101);
            posInit = num;
            num = rnd.Next(1, num);
            posFinal = num;
        }
        private void IniciarComoEscalera()
        {
            rnd = new Random();
            int num = rnd.Next(1, 101);
            posInit = num;
            num = rnd.Next(num+1,101);
            posFinal = num;
        }

        public int PosInit
        {
            get { return posInit; }
        }

        public int PosFinal
        {
            get { return posFinal; }
        }

        public TipoElemento Tipo
        {
            get { return this.tipo; }
        }
    }
}
