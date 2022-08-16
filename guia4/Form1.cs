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
    }
}
