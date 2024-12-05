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
    public partial class Portaviones : UserControl
    {
        private int maxAviones;
        private int avionesCreados;
        private static Random random = new Random();
        private Grafo grafo;
        private int vertice;

        public Portaviones(Grafo grafo, int vertice)
        {
            InitializeComponent();
            this.grafo = grafo;
            this.vertice = vertice;
            maxAviones = random.Next(1, 6); // Genera un número aleatorio entre 1 y 5
            avionesCreados = 0;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void GenerarAviones(object sender, EventArgs e)
        {
            if (avionesCreados >= maxAviones)
            {
                return; // No crear más aviones si se ha alcanzado el límite
            }

            Avion avion = new Avion(grafo);
            avion.VerticeActual = vertice;
            avion.Location = new Point(this.Location.X + this.Width / 2 - avion.Width / 2, this.Location.Y - avion.Height);
            this.Parent.Controls.Add(avion);
            avion.BringToFront(); // Asegurar que el avión esté al frente
            avionesCreados++;
        }
    }
}
