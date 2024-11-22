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
        public Portaviones()
        {
            InitializeComponent();
        }

        public Avion CreateAvion()
        {
            Avion avion = new Avion();
            avion.Location = new Point(this.Location.X + this.Width / 2 - avion.Width / 2, this.Location.Y - avion.Height);
            this.Parent.Controls.Add(avion);
            return avion;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
