using AirWar.GameObjects;

namespace AirWar
{
    public class Core
    {
        public Grafo Grafo { get; private set; }
        public LinkedList<Avion> Aviones { get; private set; }

        public Core()
        {
            Grafo = new Grafo();
            Aviones = new LinkedList<Avion>();
        }

        public void AddAvion(Avion avion)
        {
            Aviones.Add(avion);
        }

    }
}
