namespace AirWar.GameObjects
{
    // Clase parcial Bala que hereda de UserControl
    public partial class Bala : UserControl
    {
        public int speed;

        // Constructor que inicializa la velocidad de la bala
        public Bala(int speed)
        {
            this.speed = speed;
            InitializeComponent();
        }

        // Método que actualiza la posición de la bala
        private void Update(object sender, EventArgs e)
        {
            // Obtiene la ubicación actual de la bala
            Point p = this.Location;

            // Calcula la nueva posición en Y
            float tempY = p.Y - speed;

            // Si la bala sale de la pantalla, se elimina
            if (tempY <= 0)
            {
                this.Dispose();
                return;
            }

            // Actualiza la ubicación de la bala
            Location = new Point(p.X, p.Y - speed);
            this.BringToFront();
        }
    }
}
