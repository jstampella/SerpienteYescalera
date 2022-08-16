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

        private void button1_Click(object sender, EventArgs e)
        {
            panelPuntos.Controls.Clear();
            panelDados.Controls.Clear();
            Juego.RondaAvanzada();
            for (int i = 0; i < Juego.CantidadJugadores; i++)
            {
                int pos = Juego.Jugadores[i].Posicion;
                int posY = 9- ((pos - 1) / 10);
                int posX = ((pos - 1) % 10);
                CrearLabels(i, pos, Juego.Jugadores[i].Dado);
                // verifica si existe un panel en el row and col
                MoverFicha(i,posX,posY);
            }
            if (Juego.Ganadores >= Juego.CantidadJugadores - 1)
            {
                ((Button)sender).Visible = false;
                string msg = "";
                for (int i = 0; i < Juego.Ganadores; i++)
                {
                    if (msg != "") msg += ", ";
                    msg += String.Format("El Ganador {0}: {1}", i+1,Juego.Ganador(i));
                }
                MessageBox.Show(msg, "Ganadores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnNuevo.Visible = true;
            }
            ModificarTamanio();
            if (((Button)sender).Text == "Iniciar Ronda") ((Button)sender).Text = "Proxima Ronda";
        }

        private void ModificarTamanio()
        {
            FlowLayoutPanel panel;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    panel = (FlowLayoutPanel)tablero.GetControlFromPosition(i, j);

                    if (panel != null)
                    {
                        int wid = (panel.Size.Width - 10);
                        int hei = (panel.Size.Height - 10);
                        if (panel.Controls.Count > 0)
                        {
                            wid = wid / (panel.Controls.Count);
                            hei = hei / (panel.Controls.Count);
                        }

                        foreach (Panel item in panel.Controls)
                        {
                            item.Size = new Size(wid, hei);
                        }
                    }
                    
                }
            }
        }

        private void MoverFicha(int i,int posX,int posY)
        {
            Control itemPan;
            FlowLayoutPanel panel;
            itemPan = tablero.GetControlFromPosition(posX, posY);
            if (!(itemPan is FlowLayoutPanel))
            {
                FlowLayoutPanel flp = new FlowLayoutPanel();
                flp.BackColor = Color.Transparent;
                flp.Dock = DockStyle.Fill;

                tablero.Controls.Add(flp, posX, posY);
            }

            panel = (FlowLayoutPanel)tablero.GetControlFromPosition(posX, posY);

            int wid = (panel.Size.Width - 10);
            int hei = (panel.Size.Height - 10);
            if (panel.Controls.Count > 0)
            {
                wid = wid / (panel.Controls.Count + 1);
                hei = hei / (panel.Controls.Count + 1);
            }

            foreach (Panel item in panel.Controls)
            {
                item.Size = new Size(wid, hei);
            }

            switch (i + 1)
            {
                case 1:
                    panel.Controls.Add(panel1);
                    panel1.Size = new Size(wid, hei);
                    break;
                case 2:
                    panel.Controls.Add(panel2);
                    panel2.Size = new Size(wid, hei);
                    break;
                case 3:
                    panel.Controls.Add(panel3);
                    panel3.Size = new Size(wid, hei);
                    break;
                case 4:
                    panel.Controls.Add(panel4);
                    panel4.Size = new Size(wid, hei);
                    break;
                default:
                    break;
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
                int thickness = 3;//it's up to you
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
