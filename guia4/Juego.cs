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
        private Jugador[] jugadores;
        private int cantJuegadores;
        public readonly Color[] colores = new Color[4];
        private ArrayList ganadores;
        private Elemento[] elementos;

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

        private void CrearElementos()
        {
            elementos = new Elemento[8];
            elementos[0] = new Elemento(TipoElemento.Escalera, 19, 66);
            elementos[1] = new Elemento(TipoElemento.Escalera, 67, 100);
            elementos[2] = new Elemento(TipoElemento.Escalera, 32, 53);
            elementos[3] = new Elemento(TipoElemento.Escalera, 73, 91);
            elementos[4] = new Elemento(TipoElemento.Serpiente, 6, 25);
            elementos[5] = new Elemento(TipoElemento.Serpiente, 12, 46);
            elementos[6] = new Elemento(TipoElemento.Serpiente, 52, 74);
            elementos[7] = new Elemento(TipoElemento.Serpiente, 73, 88);
        }

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
                        int pos = jugadores[i].Posicion;
                        if (pos == 100)
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

        public int CantidadJugadores
        {
            get { return cantJuegadores; }
        }
        public string this[int i]
        {
            get { return jugadores[i].nombre.ToString(); }
        }
        private void CrearColores()
        {
            colores[0] = Color.FromArgb(204, 0, 0);
            colores[1] = Color.FromArgb(204, 204, 0);
            colores[2] = Color.FromArgb(0, 102, 204);
            colores[3] = Color.FromArgb(0, 255, 0);
        }

    }
}
