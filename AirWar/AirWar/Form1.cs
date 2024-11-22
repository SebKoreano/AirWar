using AirWar.GameObjects;

namespace AirWar
{
    public partial class Form1 : Form
    {
        private bool buttonDown;
        private int charge { get; set; }
        private Random random;
        private Grafo grafo;
        private LinkedList<Control> gameObjects;
        private int timer = 1000;
        private CustomDictionary<(int, int), int> routeWeights;
        private Bitmap routesBitmap;
        private System.Windows.Forms.Timer chargeTimer;
        private System.Windows.Forms.Timer avionTimer;
        private List<Avion> aviones;

        public Form1()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
            random = new Random();
            grafo = new Grafo();
            gameObjects = new LinkedList<Control>();
            routeWeights = new CustomDictionary<(int, int), int>();
            AddRandomPortavionesAguaAndPortaviones();
            CreateRoutes();
            routesBitmap = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            DrawRoutes(); // Dibujar las rutas una vez después de crear las rutas
            this.BackgroundImage = routesBitmap;

            // Inicializar el Timer
            chargeTimer = new System.Windows.Forms.Timer();
            chargeTimer.Interval = 10; // Intervalo de 10 ms
            chargeTimer.Tick += ChargeTimer_Tick;

            aviones = new List<Avion>();

            // Inicializar el Timer para mover los aviones
            avionTimer = new System.Windows.Forms.Timer();
            avionTimer.Interval = 50; // Intervalo de 50 ms
            avionTimer.Tick += AvionTimer_Tick;
            avionTimer.Start();
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
            chargeTimer.Start();
        }

        // Evento que se dispara al soltar el botón del mouse en btn1
        private void btn1_MouseUp(object sender, MouseEventArgs e)
        {
            buttonDown = false;
            CreateAndAddBala();
            UpdateLabel2();
        }

        // Crea una nueva instancia de Bala y la agrega al formulario
        private void CreateAndAddBala()
        {
            if (charge / 10 < 1)
            {
                return;
            }

            Bala bala = new Bala(charge / 10);
            bala.Location = new Point(15 + pistola1.Location.X + pistola1.Width / 2, pistola1.Location.Y);
            bala.Size = new Size(18, 32);
            bala.BackgroundImage = Properties.Resources.bala;
            bala.BackgroundImageLayout = ImageLayout.Stretch;
            this.Controls.Add(bala);
        }

        // Actualiza el texto de label2 con el valor de la carga
        private void UpdateLabel2()
        {
            label2.Text = (charge / 10).ToString();
        }

        // Añade aviones y portaviones en posiciones aleatorias
        private void AddRandomPortavionesAguaAndPortaviones()
        {
            for (int i = 0; i < 5; i++)
            {
                AddRandomPortavionesAgua();
                AddRandomPortaviones();
            }
        }

        // Añade un avión en una posición aleatoria
        private void AddRandomPortavionesAgua()
        {
            PortavionesAgua portavionesagua = new PortavionesAgua();
            Point location;
            do
            {
                location = new Point(
                    random.Next(0, this.ClientSize.Width - portavionesagua.Width),
                    random.Next(0, this.ClientSize.Height - portavionesagua.Height - 120)
                );
            } while (IsOverlapping(location, portavionesagua.Size));

            portavionesagua.Location = location;
            portavionesagua.Size = new Size(70, 69);
            portavionesagua.BackgroundImage = Properties.Resources.PortavionesAgua;
            portavionesagua.BackgroundImageLayout = ImageLayout.Stretch;
            this.Controls.Add(portavionesagua);
            gameObjects.Add(portavionesagua);
        }

        // Añade un portaviones en una posición aleatoria
        private void AddRandomPortaviones()
        {
            Portaviones portaviones = new Portaviones();
            Point location;
            do
            {
                location = new Point(
                    random.Next(0, this.ClientSize.Width - portaviones.Width),
                    random.Next(0, this.ClientSize.Height - portaviones.Height - 120)
                );
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
                    int weight = CalculateRouteWeight(i, destino);
                    routeWeights.Add((i, destino), weight);
                }
            }
        }

        private void DrawRoutes()
        {
            using (Graphics g = Graphics.FromImage(routesBitmap))
            {
                Pen pen = new Pen(Color.Black, 2);

                foreach (var vertice in grafo.GetVertices())
                {
                    Point origen = new Point(gameObjects[vertice].Location.X + gameObjects[vertice].Width / 2, gameObjects[vertice].Location.Y + gameObjects[vertice].Height / 2);
                    foreach (var destino in grafo.GetAdyacentes(vertice))
                    {
                        Point destinoPoint = new Point(gameObjects[destino].Location.X + gameObjects[destino].Width / 2, gameObjects[destino].Location.Y + gameObjects[destino].Height / 2);
                        g.DrawLine(pen, origen, destinoPoint);

                        // Dibujar el peso de la ruta
                        int weight = routeWeights[(vertice, destino)];
                        Point midPoint = new Point((origen.X + destinoPoint.X) / 2, (origen.Y + destinoPoint.Y) / 2);
                        DrawWeightLabel(midPoint, weight);
                    }
                }
            }
        }

        private void DrawWeightLabel(Point location, int weight)
        {
            Label weightLabel = new Label
            {
                Text = weight.ToString(),
                BackColor = Color.White,
                ForeColor = Color.Black,
                AutoSize = true,
                Location = location
            };
            this.Controls.Add(weightLabel);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Crear aviones desde Portaviones y PortavionesAgua
            Portaviones portaviones = new Portaviones();
            portaviones.Location = new Point(100, 400);
            this.Controls.Add(portaviones);
            aviones.Add(portaviones.CreateAvion());

            PortavionesAgua portavionesAgua = new PortavionesAgua();
            portavionesAgua.Location = new Point(300, 400);
            this.Controls.Add(portavionesAgua);
            aviones.Add(portavionesAgua.CreateAvion());
        }

        //Metodo para regular el tiempo de juego
        private void Timer(object sender, EventArgs e)
        {
            label4.Text = timer.ToString();
            timer--;
            if (timer == 0)
            {
                MessageBox.Show("Game Over");
            }
        }
        private int CalculateRouteWeight(int origen, int destino)
        {
            Control origenControl = gameObjects[origen];
            Control destinoControl = gameObjects[destino];
            double distance = Math.Sqrt(Math.Pow(destinoControl.Location.X - origenControl.Location.X, 2) + Math.Pow(destinoControl.Location.Y - origenControl.Location.Y, 2));
            int baseWeight = (int)(distance / 10); // Peso basado en la distancia

            // Peso adicional basado en el tipo de destino
            int additionalWeight = destinoControl is PortavionesAgua ? 50 : 20;

            return baseWeight + additionalWeight;
        }
        private void ChargeTimer_Tick(object sender, EventArgs e)
        {
            if (buttonDown)
            {
                charge++;
                label1.Text = charge.ToString();
            }
            else
            {
                chargeTimer.Stop();
            }
        }

        private void AvionTimer_Tick(object sender, EventArgs e)
        {
            foreach (var avion in aviones)
            {
                avion.Location = new Point(avion.Location.X, avion.Location.Y - 5);
                if (avion.Location.Y + avion.Height < 0)
                {
                    this.Controls.Remove(avion);
                }
            }
            aviones.RemoveAll(a => a.Location.Y + a.Height < 0);
        }
    }
}
