using AirWar.GameObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AirWar
{
    public partial class Form1 : Form
    {
        private bool buttonDown;
        private int charge { get; set; }
        private Random random;
        private Grafo grafo;
        private List<Control> gameObjects;

        public Form1()
        {
            InitializeComponent();
            random = new Random();
            grafo = new Grafo();
            gameObjects = new List<Control>();
            AddRandomAvionesAndPortaviones();
            CreateRoutes();
        }

        // Evento que se dispara al hacer clic en pictureBox1
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        // Evento que se dispara al hacer clic en btn1
        private void btn1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        // Evento que se dispara al presionar el botón del mouse en btn1
        private void btn1_MouseDown(object sender, MouseEventArgs e)
        {
            buttonDown = true;
            charge = 0;

            // Bucle que incrementa la carga mientras el botón está presionado
            do
            {
                charge++;
                label1.Text = charge.ToString();

                Application.DoEvents();
            } while (buttonDown);
        }

        // Evento que se dispara al soltar el botón del mouse en btn1
        private void btn1_MouseUp(object sender, MouseEventArgs e)
        {
            CreateAndAddBala();
            UpdateLabel2();
            buttonDown = false;
        }

        // Crea una nueva instancia de Bala y la agrega al formulario
        private void CreateAndAddBala()
        {
            Bala bala = new Bala(charge / 300);
            bala.Location = new Point(15 + pistola1.Location.X + pistola1.Width / 2, pistola1.Location.Y);
            bala.Size = new Size(18, 32);
            bala.BackgroundImage = Properties.Resources.bala;
            bala.BackgroundImageLayout = ImageLayout.Stretch;
            this.Controls.Add(bala);
        }

        // Actualiza el texto de label2 con el valor de la carga
        private void UpdateLabel2()
        {
            label2.Text = (charge / 300).ToString();
        }

        // Añade aviones y portaviones en posiciones aleatorias
        private void AddRandomAvionesAndPortaviones()
        {
            for (int i = 0; i < 5; i++)
            {
                AddRandomAvion();
                AddRandomPortaviones();
            }
        }

        // Añade un avión en una posición aleatoria
        private void AddRandomAvion()
        {
            Avion avion = new Avion();
            Point location;
            do
            {
                location = new Point(random.Next(0, this.ClientSize.Width - avion.Width), random.Next(0, this.ClientSize.Height - avion.Height));
            } while (IsOverlapping(location, avion.Size));

            avion.Location = location;
            avion.Size = new Size(70, 69);
            avion.BackgroundImage = Properties.Resources.Avion;
            avion.BackgroundImageLayout = ImageLayout.Stretch;
            this.Controls.Add(avion);
            gameObjects.Add(avion);
        }

        // Añade un portaviones en una posición aleatoria
        private void AddRandomPortaviones()
        {
            Portaviones portaviones = new Portaviones();
            Point location;
            do
            {
                location = new Point(random.Next(0, this.ClientSize.Width - portaviones.Width), random.Next(0, this.ClientSize.Height - portaviones.Height));
            } while (IsOverlapping(location, portaviones.Size));

            portaviones.Location = location;
            portaviones.Size = new Size(109, 109);
            portaviones.BackgroundImage = Properties.Resources.Portaviones;
            portaviones.BackgroundImageLayout = ImageLayout.Stretch;
            this.Controls.Add(portaviones);
            gameObjects.Add(portaviones);
        }

        // Verifica si una nueva posición se superpone con algún objeto existente
        private bool IsOverlapping(Point location, Size size)
        {
            Rectangle newRect = new Rectangle(location, size);
            foreach (Control control in gameObjects)
            {
                if (newRect.IntersectsWith(control.Bounds))
                {
                    return true;
                }
            }
            return false;
        }

        // Crear rutas utilizando un grafo
        private void CreateRoutes()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                grafo.AddVertice(i);
            }

            for (int i = 0; i < gameObjects.Count; i++)
            {
                int destino = random.Next(0, gameObjects.Count);
                if (destino != i)
                {
                    grafo.AddArista(i, destino);
                }
            }
        }

        // Sobrescribir el método OnPaint para dibujar las rutas
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black, 2);

            foreach (var vertice in grafo.GetVertices())
            {
                Point origen = new Point(gameObjects[vertice].Location.X + gameObjects[vertice].Width / 2, gameObjects[vertice].Location.Y + gameObjects[vertice].Height / 2);
                foreach (var destino in grafo.GetAdyacentes(vertice))
                {
                    Point destinoPoint = new Point(gameObjects[destino].Location.X + gameObjects[destino].Width / 2, gameObjects[destino].Location.Y + gameObjects[destino].Height / 2);
                    g.DrawLine(pen, origen, destinoPoint);
                }
            }
        }
    }
}
