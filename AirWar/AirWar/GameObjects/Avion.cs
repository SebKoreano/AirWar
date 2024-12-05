using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirWar.GameObjects
{
    public partial class Avion : UserControl
    {
        public int VerticeActual { get; set; }
        public int Combustible { get; set; }
        private Grafo grafo;
        private Random random;
        private System.Windows.Forms.Timer movimientoTimer;
        private Point destino;
        private int pasos;
        private int pasosActuales;

        public Avion(Grafo grafo)
        {
            InitializeComponent();
            this.grafo = grafo;
            this.Combustible = 1000;
            this.random = new Random();
            this.movimientoTimer = new System.Windows.Forms.Timer();
            this.movimientoTimer.Interval = 50; // Intervalo de tiempo para el movimiento
            this.movimientoTimer.Tick += MovimientoTimer_Tick;
        }


        public void MoverAvion(Point destino, int pasos)
        {
            this.destino = destino;
            this.pasos = pasos;
            this.pasosActuales = 0;
            this.movimientoTimer.Start();
        }

        private void MovimientoTimer_Tick(object sender, EventArgs e)
        {
            if (pasosActuales >= pasos)
            {
                movimientoTimer.Stop();
                return;
            }

            int deltaX = (destino.X - this.Location.X) / (pasos - pasosActuales);
            int deltaY = (destino.Y - this.Location.Y) / (pasos - pasosActuales);

            this.Location = new Point(this.Location.X + deltaX, this.Location.Y + deltaY);
            pasosActuales++;
        }

        private void MoverTimer(object sender, EventArgs e)
        {
            //if (Combustible <= 0)
            //{
            //    return; // No moverse si no hay combustible
            //}

            var adyacentes = grafo.GetAdyacentes(VerticeActual);

            if (adyacentes.Count == 0)
            {
                return; // No moverse si no hay vértices adyacentes
            }

            int destinoVertice = adyacentes.ElementAt(random.Next(adyacentes.Count));
            int pesoRuta = grafo.GetRouteWeight(VerticeActual, destinoVertice);

            if (Combustible >= pesoRuta)
            {
                Combustible -= pesoRuta;
                VerticeActual = destinoVertice;
                Point destino = grafo.GetVertexPosition(destinoVertice);
                MoverAvion(destino, 20); // Número de pasos para llegar al destino
            }
        }
    }
}
