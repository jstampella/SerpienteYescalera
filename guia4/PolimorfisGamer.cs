using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace guia4
{
    public partial class PolimorfisGamer : Form
    {
        private Juego Juego;
        public PolimorfisGamer(int countJug, string[] nombres)
        {
            Juego = new Juego(countJug, nombres);
            InitializeComponent();
        }

        private void CrearLabels(int i,int pts=0,int d=0)
        {
            Label txt = new Label();
            Label dado = new Label();
            Panel pColor = new Panel();
            pColor.Size = new Size(15, 15);
            pColor.BackColor = Juego.colores[i];
            txt.Text = "- "+pts+"pts";
            dado.Text = d.ToString();
            panelPuntos.Controls.Add(txt);
            panelPuntos.Controls.Add(pColor);
            pColor.Location = new Point(5, (i * 30) + 10);
            txt.Location = new Point(20, (i * 30)+10);
            panelDados.Controls.Add(dado);
            dado.Location = new Point(10, (i * 30)+10);
        }

        private void PolimorfisGamer_Shown(object sender, EventArgs e)
        {
            panelPuntos.Controls.Clear();
            panelDados.Controls.Clear();
            for (int i = 0; i < Juego.CantidadJugadores; i++)
            {
                CrearLabelTitulo(i, Juego[i]);
                CrearLabels(i);
            }
        }

        private void CrearLabelTitulo(int pos,string nombre)
        {
            Label txt;
            Panel pColor;
            txt = new Label();
            pColor = new Panel();
            pColor.Size = new Size(15, 15);
            pColor.BackColor = Juego.colores[pos];
            CambiarColorPanel(pos);
            txt.Text = nombre;
            panelColores.Controls.Add(pColor);
            panelJugador.Controls.Add(txt);
            txt.Location = new Point(10, pos * 25);
            pColor.Location = new Point(10, pos * 25);
        }
        private void CambiarColorPanel(int pos)
        {
            switch (pos + 1)
            {
                case 1:
                    panel1.BackColor = Juego.colores[pos];
                    // panel1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                    break;
                case 2:
                   panel2.BackColor = Juego.colores[pos];
                    // panel2.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                    break;
                case 3:
                    panel3.BackColor = Juego.colores[pos];
                    // panel3.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                    break;
                case 4:
                    panel4.BackColor = Juego.colores[pos];
                    // panel4.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                    break;
                default:
                    break;
            }
        }


        // Boton para la ronda
        private void button1_Click(object sender, EventArgs e)
        {
            panelPuntos.Controls.Clear();
            panelDados.Controls.Clear();
            Juego.RondaAvanzada();
            for (int i = 0; i < Juego.CantidadJugadores; i++)
            {
                int pos = Juego.Jugadores[i].Posicion;
                int posY = 9 - ((pos - 1) / 10);
                int posX = ((pos - 1) % 10);
                CrearLabels(i, pos, Juego.Jugadores[i].Dado);
                // verifica si existe un panel en el row and col
                //MoverFicha(i,posX,posY);
                TirarRonda(i, posX, posY);
            }
            if (Juego.Ganadores >= Juego.CantidadJugadores - 1)
            {
                ((Button)sender).Visible = false;
                string msg = "";
                for (int i = 0; i < Juego.Ganadores; i++)
                {
                    if (msg != "") msg += ", ";
                    msg += String.Format("El Ganador {0}: {1}", i + 1, Juego.Ganador(i));
                }
                MessageBox.Show(msg, "Ganadores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnNuevo.Visible = true;
            }
            ModificarTamanio();
            MostrarAfectados();
            if (((Button)sender).Text == "Iniciar Ronda") ((Button)sender).Text = "Proxima Ronda";
        }

        private void MostrarAfectados()
        {
            Jugador[] jugadoresAfec = Juego.JugadoresAfectados();
            string messa = "";
            foreach (Jugador jugador in jugadoresAfec)
            {
                messa = String.Format("Jugador {0} afectado por: {1}, posicion: {2} pasa a {3}", jugador.nombre, jugador.ElementoAfectado.ToString(),(jugador.PosicionAnt+jugador.Dado),jugador.Posicion);
                MessageBox.Show(messa, "Afectado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ModificarTamanio()
        {
            Point cuadrado = new Point(tablero2.Size.Width / 10, tablero2.Size.Height / 10);
            int index = 0;
            foreach (Control item in tablero2.Controls)
            {
                if (item is Panel panel)
                {
                    panel.Size = new Size(cuadrado.X -5, cuadrado.Y - 5);
                    tablero2.Controls.SetChildIndex(panel, index + 1);
                    int index2 = 0;
                    foreach (Control item2 in tablero2.Controls)
                    {
                        if(item != item2 && item.Location == item2.Location)
                        {
                            index2++;
                            tablero2.Controls.SetChildIndex(item2, index2 + 2);
                            item2.Left += 6;
                            item2.Top += 6;
                            item2.Size = new Size(cuadrado.X - (6* index2), cuadrado.Y - (6* index2));
                        }
                    }
                }
                index++;
            }
        }

        private void TirarRonda(int i, int posX, int posY)
        {
            Panel Npanel = null;
            Point cuadrado = new Point(tablero2.Size.Width / 10, tablero2.Size.Height / 10);
            switch (i + 1)
            {
                case 1:
                    Npanel = panel1;
                    break;
                case 2:
                    Npanel = panel2;
                    break;
                case 3:
                    Npanel = panel3;
                    break;
                case 4:
                    Npanel = panel4;
                    break;
                default:
                    break;
            }
            if (Npanel != null)
            {
                tablero2.Controls.Add(Npanel);
                Npanel.Size = new Size(cuadrado.X - 5, cuadrado.Y - 5);
                Npanel.Left = (cuadrado.X * posX)+2;
                Npanel.Top = (cuadrado.Y * posY)+5;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        // hacer el borde mas grueso
        private void panel_Paint(object sender, PaintEventArgs e)
        {
            if (((Panel)sender).BorderStyle == BorderStyle.FixedSingle)
            {
                int thickness = 1;//it's up to you
                int halfThickness = thickness / 2;
                using (Pen p = new Pen(Color.Black, thickness))
                {
                    e.Graphics.DrawRectangle(p, new Rectangle(halfThickness,
                                                              halfThickness,
                                                              ((Panel)sender).ClientSize.Width - thickness,
                                                              ((Panel)sender).ClientSize.Height - thickness));
                }
            }
        }
    }
}
