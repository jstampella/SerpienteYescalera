using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace guia4
{
    public partial class Form1 : Form
    {
        PolimorfisGamer juego;
        int limitJugadores = 4;
        int jugadorH = 1;
        int jugadorM = 1;
        JugadorForm jugadorForm = new JugadorForm();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            int cantidadH = Convert.ToInt16(inpHum.Value);
            int cantidadM = Convert.ToInt16(inpMaq.Value);
            string[] nombres = new string[cantidadH];
            bool cancelJuego = false;

            int count=0;
            while (count< cantidadH)
            {
                jugadorForm.txtNombre.Text = "";
                jugadorForm.title.Text = "Jugador: "+(count+1);
                if(jugadorForm.ShowDialog() == DialogResult.OK)
                {
                    nombres[count] = jugadorForm.txtNombre.Text;
                    count++;
                }
                else
                {
                    cancelJuego = true;
                    break;
                }
            }
            if (!cancelJuego)
            {
                int cantJugadores = cantidadH + cantidadM;
                juego = new PolimorfisGamer(cantJugadores,nombres);
                this.Hide();
                while(juego.ShowDialog() == DialogResult.OK)
                {
                    juego = new PolimorfisGamer(cantJugadores, nombres);
                }
                this.Show();
            }
            
            //Jugadores[0] = new Jugador("jose");
        }

        private void numericUpDown1_KeyUp(object sender, KeyEventArgs e)
        {
            if (jugadorH + jugadorM + 1 <= limitJugadores)
                if(((NumericUpDown)sender).Name == "inpHum")
                    jugadorH = Convert.ToInt16(((NumericUpDown)sender).Value);
                else
                {
                    jugadorM = Convert.ToInt16(((NumericUpDown)sender).Value);
                }
            else
            {
                MessageBox.Show("Limite maximo 4 en total");
                ((NumericUpDown)sender).Value = jugadorH;
            }
        }

        private void numericUpDown1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right || e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                NumericUpDown np = null;
                NumericUpDown np2 = null;
                if (((NumericUpDown)sender).Name == "inpHum")
                    np = (NumericUpDown)sender;
                else
                {
                    np2 = (NumericUpDown)sender;
                }

                if (jugadorH + jugadorM + 1 <= limitJugadores)
                    if (np !=null)
                        jugadorH = Convert.ToInt16(np.Value);
                    else
                    {
                        jugadorM = Convert.ToInt16(np2.Value);
                    }
                else
                {
                    MessageBox.Show("Limite maximo 4 en total");
                    if (np != null)
                        np.Value = jugadorH;
                    else
                    {
                        np2.Value = jugadorM;
                    }
                }
            }
        }
    }
}
