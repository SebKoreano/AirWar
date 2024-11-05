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
    public partial class Bala : UserControl
    {
        public int speed;
        public Bala(int speed)
        {
            this.speed = speed;
            InitializeComponent();
        }

        private void Update(object sender, EventArgs e)
        {
            Point p = this.Location;

            float tempY = p.Y - speed;

            if (tempY <= 0)
            {
                this.Dispose();
                return;
            }

            Location = new Point(p.X, p.Y - speed);
        }
    }
}
