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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void btn1_MouseDown(object sender, MouseEventArgs e)
        {
            buttonDown = true;

            charge = 0;
            do
            {
                charge++;
                label1.Text = charge.ToString();

                Application.DoEvents();
            } while (buttonDown);
        }

        private void btn1_MouseUp(object sender, MouseEventArgs e)
        {
            CreateAndAddBala();
            UpdateLabel2();
            buttonDown = false;
        }

        private void CreateAndAddBala()
        {
            Bala bala = new Bala(charge / 300);
            bala.Location = new Point(15 + pistola1.Location.X + pistola1.Width / 2, pistola1.Location.Y);
            bala.Size = new Size(18, 32);
            bala.BackgroundImage = Properties.Resources.bala;
            bala.BackgroundImageLayout = ImageLayout.Stretch;
            this.Controls.Add(bala);
        }

        private void UpdateLabel2()
        {
            label2.Text = (charge / 300).ToString();
        }

    }
}
