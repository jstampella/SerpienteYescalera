using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace guia4
{
    internal class Juego
    {
        #region Atributos
        private Jugador[] jugadores;
        private int cantJuegadores;
        public readonly Color[] colores = new Color[4];
        private ArrayList ganadores;
        private Elemento[] elementos;
        #endregion

        #region Propiedades
        public Jugador[] Jugadores
        {
            get { return jugadores; }
        }
        public int Ganadores
        {
            get { return ganadores.Count; }
        }
        public int CantidadJugadores
        {
            get { return cantJuegadores; }
        }
        #endregion

        #region constructor
        public Juego(int countJug, string[] nombres)
        {
            cantJuegadores = countJug;
            jugadores = new Jugador[countJug];
            ganadores = new ArrayList();
            int maquinas = countJug - nombres.Length;
            CrearColores();
            int tmp = 0;
            for (int i = 0; i < countJug; i++)
            {
                if (i < maquinas)
                {
                    jugadores[i] = new Jugador("Maquina (" + (i + 1) + ")");
                }
                else
                {
                    jugadores[i] = new Jugador(nombres[tmp]);
                    tmp++;
                }
            }
            CrearElementos();
        }
        #endregion

        #region indexadores
        public string this[int i]
        {
            get { return jugadores[i].nombre.ToString(); }
        }
        #endregion

        #region Metodos privados
        private void CrearElementos()
        {
            elementos = new Elemento[8];
            elementos[0] = new Elemento(TipoElemento.Escalera, 73, 91);
            elementos[1] = new Elemento(TipoElemento.Escalera, 67,100);
            elementos[2] = new Elemento(TipoElemento.Escalera, 19,66);
            elementos[3] = new Elemento(TipoElemento.Escalera, 32,53);
            elementos[4] = new Elemento(TipoElemento.Serpiente, 52, 74);
            elementos[5] = new Elemento(TipoElemento.Serpiente, 76, 88);
            elementos[6] = new Elemento(TipoElemento.Serpiente, 12, 46);
            elementos[7] = new Elemento(TipoElemento.Serpiente, 6, 25);
        }

        private void ComprobarElementos(Jugador jugador)
        {
            int pos = jugador.Posicion;
            int ind = 0;
            int temp = jugador.Posicion;
            while (ind < elementos.Length && pos == temp)
            {
                temp = elementos[ind].Evaluar(jugador);
                if (pos != temp)
                {
                    jugador.ModificarPosicion(elementos[ind].Tipo, temp);
                }
                ind++;
            }
        }

        private void CrearColores()
        {
            colores[0] = Color.FromArgb(204, 0, 0);
            colores[1] = Color.FromArgb(204, 204, 0);
            colores[2] = Color.FromArgb(0, 102, 204);
            colores[3] = Color.FromArgb(0, 255, 0);
        }
        #endregion

        public void Ronda()
        {
            for (int i = 0; i < cantJuegadores; i++)
            {
                if (jugadores[i].Posicion < 100)
                {
                    int dado = jugadores[i].Mover();
                    if ((dado + jugadores[i].Posicion) <= 100)
                    {
                        int pos = jugadores[i].Avanzar();
                        if (pos == 100)
                        {
                            ganadores.Add(jugadores[i].nombre);
                        }
                    }
                }
            }
        }

        public void RondaAvanzada()
        {
            for (int i = 0; i < cantJuegadores; i++)
            {
                if (jugadores[i].Posicion < 100)
                {
                    int dado = jugadores[i].Mover();
                    if ((dado + jugadores[i].Posicion) <= 100)
                    {
                        jugadores[i].Avanzar();
                        ComprobarElementos(jugadores[i]);
                        //int pos = jugadores[i].Posicion;
                        //if (pos == 100)
                        //{
                        //    ganadores.Add(jugadores[i].nombre);
                        //}
                        if (jugadores[i].Hallegado)
                        {
                            ganadores.Add(jugadores[i].nombre);
                        }
                    }
                }
            }
        }

        private void ComprobarElementos(Jugador jugador)
        {
            int pos = jugador.Posicion;
            for (int i = 0; i < elementos.Length; i++)
            {
                int temp = elementos[i].Evaluar(jugador);
                if (pos != temp)
                {
                    jugador.ModificarPosicion(elementos[i].Tipo, temp);
                    break;
                }
            }
            
        }
        public Jugador[] Jugadores
        {
            get { return jugadores; }
        }
        public int Ganadores
        {
            get { return ganadores.Count; }
        }

        public string Ganador(int pos)
        {
            return ganadores[pos].ToString();
        }

        public Jugador[] JugadoresAfectados()
        {
            ArrayList afectados = new ArrayList();
            for (int i = 0; i < jugadores.Length; i++)
            {
                if(jugadores[i].ElementoAfectado != null)
        {
                    if (!jugadores[i].Hallegado)
                        afectados.Add(jugadores[i]);
        }
        public string this[int i]
        {
            get { return jugadores[i].nombre.ToString(); }
        }
            Jugador[] jAfectados = (Jugador[])afectados.ToArray(typeof(Jugador));
            return jAfectados;
        }

    }
}
