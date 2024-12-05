namespace AirWar
{
    public class Grafo
    {
        private CustomDictionary<int, LinkedList<int>> adyacencias;
        private CustomDictionary<(int, int), int> routeWeights;
        private CustomDictionary<int, Point> vertexPositions;

        public Grafo()
        {
            adyacencias = new CustomDictionary<int, LinkedList<int>>();
            routeWeights = new CustomDictionary<(int, int), int>();
            vertexPositions = new CustomDictionary<int, Point>();
        }

        public void AddVertice(int vertice, Point position)
        {
            if (!adyacencias.ContainsKey(vertice))
            {
                adyacencias.Add(vertice, new LinkedList<int>());
                vertexPositions.Add(vertice, position);
            }
        }

        public void AddArista(int origen, int destino, int weight)
        {
            if (adyacencias.ContainsKey(origen) && adyacencias.ContainsKey(destino))
            {
                adyacencias[origen].Add(destino);
                routeWeights[(origen, destino)] = weight;
            }
        }

        public LinkedList<int> GetAdyacentes(int vertice)
        {
            return adyacencias.ContainsKey(vertice) ? adyacencias[vertice] : new LinkedList<int>();
        }

        public IEnumerable<int> GetVertices()
        {
            return adyacencias.Keys;
        }

        public int GetRouteWeight(int origen, int destino)
        {
            return routeWeights.ContainsKey((origen, destino)) ? routeWeights[(origen, destino)] : 0;
        }

        public Point GetVertexPosition(int vertice)
        {
            return vertexPositions.ContainsKey(vertice) ? vertexPositions[vertice] : Point.Empty;
        }
    }
}