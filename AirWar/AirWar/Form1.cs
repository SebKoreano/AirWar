using AirWar.GameObjects;

namespace AirWar
{
    public partial class Form1 : Form
    {
        private bool buttonDown;
        private int charge { get; set; }

        public Form1()
        {
            InitializeComponent();
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

            //Bucle que incrementa la carga mientras el botón esté presiona
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

    }
}
