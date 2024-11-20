namespace AirWar.GameObjects
{
    public partial class Pistola : UserControl
    {
        private int speed = 3;

        // Constructor de la clase Pistola
        public Pistola()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
        }

        // Método que actualiza la posición del objeto Pistola
        private void Update(object sender, EventArgs e)
        {
            Point p = this.Location;
            float tempX = p.X + speed;

            // Cambia la dirección del movimiento si se alcanza el límite
            if (tempX >= 650 || tempX <= 40)
            {
                speed = -speed;
            }

            // Actualiza la ubicación del objeto
            Location = new Point(p.X + speed, p.Y);
        }

        private void Pistola_Load(object sender, EventArgs e)
        {

        }
    }
}
