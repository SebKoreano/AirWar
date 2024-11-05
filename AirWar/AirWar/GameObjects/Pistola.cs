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
    public partial class Pistola : UserControl
    {
        private int speed = 3;
        public Pistola()
        {
            InitializeComponent();
        }

        private void Update(object sender, EventArgs e)
        {
            Point p = this.Location;

            float tempX = p.X + speed;

            if (tempX >= 650 || tempX <= 40)
            {
                speed = -speed;
            }

            Location = new Point(p.X + speed, p.Y);
        }
    }
}
