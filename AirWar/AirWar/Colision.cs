using System.Drawing;
using System.Windows.Forms;
using AirWar.GameObjects;

namespace AirWar
{
    public static class Colision
    {
        public static void DetectarColisiones(Control parent)
        {
            foreach (Control control1 in parent.Controls)
            {
                if (control1 is Avion avion)
                {
                    foreach (Control control2 in parent.Controls)
                    {
                        if (control2 is Bala bala)
                        {
                            if (avion.Bounds.IntersectsWith(bala.Bounds))
                            {
                                // Destruir el avión y la bala
                                parent.Controls.Remove(avion);
                                parent.Controls.Remove(bala);
                                avion.Dispose();
                                bala.Dispose();
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}